using Microsoft.AspNetCore.Http;
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
        public AuthController(IAuthHandler authHandler)
        {
            this.authHandler = authHandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var user = RegisterM.ToApplicationUser(dto);
            var createdUser = await authHandler.RegisterHandler(user, dto.Mot_passe);
            var userResponse = RegisterM.ToRegisterResponse(user);
            return CreatedAtAction(nameof(GetUser), new { userResponse.Id }, userResponse);
        }
    }
}
