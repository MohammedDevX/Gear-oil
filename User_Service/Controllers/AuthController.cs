using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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
        public AuthController(IAuthHandler authHandler, IEmailSender sender)
        {
            this.authHandler = authHandler;
            this.sender = sender;
        }

        //[HttpGet("{id}")]
        //public IActionResult GetUser(Guid id)
        //{
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var user = RegisterM.ToApplicationUser(dto);
            var createdUser = await authHandler.RegisterHandler(user, dto.Mot_passe);
            if (createdUser == false)
            {
                return Conflict();
            }

            var userResponse = RegisterM.ToRegisterResponse(user);
            return Ok();
            //return CreatedAtAction(nameof(GetUser), new { userResponse.Id }, userResponse);
        }

        //[Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var admin = RegisterM.FromDTOAdminToApplicationUser(dto);
            var createdAdmin = await authHandler.RegisterAdminHandler(admin);
            if (createdAdmin == false)
            {
                return Conflict();
            }

            var token = authHandler.GenerateToken(admin);
            var link = Url.Action("ActivateAdmin", "Auth", new { userId = admin.Id, token = token }, Request.Scheme);

            sender.SendEmailAsync(admin.Email, "Activation de compte", $"Clicker ici: <a href='{link}'>Activer</a>");

            var ResgisterAdminResponse = RegisterM.ToRegisterAdminResponse(admin);
            return Ok();
        }

        //public IActionResult ActivateAdmin(ActivateAdminDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return StatusCode(422);
        //    }


        //    return Ok();
        //}
    }
}
