using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AlpataBusiness.Abstract;
using Business.Abstract;

namespace YourNamespace.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                ModelState.AddModelError(string.Empty, userToLogin.Message);
                return View(userForLoginDto);
            }
            return RedirectToAction("Index", "Dashboard"); 
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var userExists = _authService.UserExists(userForRegisterDto.Email);
                if (!userExists.Success)
                {
                    ModelState.AddModelError(string.Empty, userExists.Message);
                    return View(userForRegisterDto); // Hata durumunda register formunu tekrar göster
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                if (registerResult.Success)
                {
                    await _emailService.SendWelcomeEmailAsync(userForRegisterDto.Email);
                    // Başarılı ise gerekli işlemleri yapabilirsiniz, örneğin kullanıcıyı login sayfasına yönlendirebilirsiniz
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, registerResult.Message);
                }
            }

            return View(userForRegisterDto); // ModelState geçerli değilse register formunu tekrar göster
        }
    }
}
