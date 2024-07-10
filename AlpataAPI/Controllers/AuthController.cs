using System.Threading.Tasks;
using AlpataBusiness.Abstract;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result); 
            }

            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(UserRegisterDto userForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var userExists = _authService.UserExists(userForRegisterDto.Email);
                if (!userExists.Success)
                {
                    ModelState.AddModelError(string.Empty, "User with this email already exists."); // Örnek bir hata mesajı
                    return BadRequest(ModelState);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                if (registerResult.Success)
                {
                    await _emailService.SendWelcomeEmailAsync(userForRegisterDto.Email);
                    return Ok(registerResult);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to register user."); // Örnek bir hata mesajı
                }
            }

            return BadRequest(ModelState);
        }

    }
}
