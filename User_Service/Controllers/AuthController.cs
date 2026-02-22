using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using User_Service.DTOs.AuthDTOs;
using User_Service.Mappers.AuthM;
using User_Service.Services.Auth;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthHandler authHandler;
        private IEmailSender sender;
        private IWebHostEnvironment _env;
        public AuthController(IAuthHandler authHandler, IEmailSender sender, IWebHostEnvironment _env)
        {
            this.authHandler = authHandler;
            this.sender = sender;
            this._env = _env;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok();
        }

        //[HttpPost("register-client")]
        //public async Task<IActionResult> RegisterClient(RegisterDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return StatusCode(422);
        //    }

        //    var user = RegisterM.ToApplicationUser(dto);
        //    var checkExistingClient = await authHandler.CheckExistingUser(user, "Client");
        //    if (checkExistingClient == false)
        //    {
        //        return NotFound();
        //    }

        //    var createdUser = await authHandler.RegisterHandler(user, dto.Mot_passe);
        //    if (createdUser == false)
        //    {
        //        return BadRequest();
        //    }

        //    var userResponse = RegisterM.ToRegisterResponse(user);
        //    return CreatedAtAction(nameof(GetUser), new { userResponse.Id }, userResponse);
        //}

        //[Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var admin = RegisterM.FromDTOAdminToApplicationUser(dto);

            var checkExistingAdmin = await authHandler.CheckExistingUser(admin, "Admin");
            if (checkExistingAdmin == false)
            {
                return NotFound();
            }

            // Insert the admin in DB
            var createdAdmin = await authHandler.RegisterAdminHandler(admin);
            if (createdAdmin == false)
            {
                return BadRequest();
            }

            // Generate stateless token to ensure that the targeted admin who enter in the url
            var token = await authHandler.GenerateToken(admin);
            
            // Geneate url, that call activate account end point
            var link = Url.Action("ActivateAdmin", "Auth", new { userId = admin.Id, token = token }, Request.Scheme);

            // The function accepete 3 params : created email, email subject, html body
            //await sender.SendEmailAsync(admin.Email,
            //    "Activation de compte", $"Clicker ici: <a href='{link}'>Activer</a>");

            var templatePath = Path.Combine(_env.ContentRootPath, "EmailTemplates", "email-activation-gearoil.html");

            // Option B — si le fichier est à la racine du projet (ContentRootPath)
            //var templatePath = Path.Combine(_env.ContentRootPath, "EmailTemplates", "email-activation-gearoil.html");

            string html = System.IO.File.ReadAllText(templatePath)
                .Replace("{link}", link)
                .Replace("{Nom de l'administrateur}", admin.Nom + " " +  admin.Prenom);

            await sender.SendEmailAsync(admin.Email, "Activation de compte", html);

            var adminResponse = RegisterM.ToRegisterAdminResponse(admin);
            //return CreatedAtAction(nameof(GetUser), new {UserId = adminResponse.Id}, adminResponse);
            return Ok(new { Token = token, UserId = admin.Id });
        }

        [HttpPatch]
        //public IActionResult ActivateAdmin(string token, string userId, ActivateAdminDTO dto)
        public async Task<IActionResult> ActivateAdmin(ActivateAdminDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var admin = await authHandler.FindAdmin(dto);
            if (admin == null)
            {
                return NotFound();
            }

            var checkToken = await authHandler.CheckeValidateToken(admin, dto.Token);
            var checkUpdated = await authHandler.ActivateAdminAccount(admin, dto.Mot_passe);
            if (checkToken == false || checkUpdated == false)
            {
                return BadRequest();
            }

            //if (checkUpdated == false)
            //{
            //    return BadRequest();
            //}

            return NoContent();
        }
    }
}
