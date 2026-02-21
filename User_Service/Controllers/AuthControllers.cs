using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User_Service.DTOs;
using User_Service.Mappings;
using User_Service.Models;
using User_Service.Services;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService _emailService;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            EmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        // 🔹 Register Client
        [HttpPost("register-client")]
        public async Task<IActionResult> RegisterClient(RegisterClientDto dto)
        {
            var user = UserMapping.ToClientUser(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("Client"))
                await _roleManager.CreateAsync(new IdentityRole("Client"));

            await _userManager.AddToRoleAsync(user, "Client");

            return Ok("Client created successfully.");
        }

        // 🔹 Create Admin
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(CreateAdminDto dto)
        {
            var user = UserMapping.ToAdminUser(dto);

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            await _userManager.AddToRoleAsync(user, "Admin");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var frontendUrl = _configuration["FrontendUrl"];

            var activationLink =
                $"{frontendUrl}/set-password?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var templatePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "EmailTemplates",
                "AdminActivation.html");

            var body = await System.IO.File.ReadAllTextAsync(templatePath);
            body = body.Replace("{{ActivationLink}}", activationLink);

            await _emailService.SendEmailAsync(
                user.Email,
                "Activate your admin account",
                body
            );

            return Ok("Admin created and email sent successfully.");
        }

        // 🔹 Confirm Email
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);

            if (user == null)
                return BadRequest("Invalid user.");

            var result = await _userManager
                .ConfirmEmailAsync(user, dto.Token);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Email confirmed successfully.");
        }

        //chongment nta3 password d admin jded

        [HttpPost("set-password")]
        public async Task<IActionResult> SetPassword(SetPasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);

            if (user == null)
                return BadRequest("Invalid user.");

            var result = await _userManager
                .ResetPasswordAsync(user, dto.Token, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return Ok("Password set successfully.");
        }
    }
}