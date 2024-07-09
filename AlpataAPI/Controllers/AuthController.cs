using System.Threading.Tasks;
using AlpataBusiness.Abstract;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        // GET: /auth/login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /auth/login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                ModelState.AddModelError(string.Empty, userToLogin.Message);
                return View(userForLoginDto);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                // Örneğin token veya kullanıcı bilgileri ile birlikte yönlendirme yapabilirsiniz
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(userForLoginDto);
        }

        // GET: /auth/register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /auth/register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserRegisterDto userForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var userExists = _authService.UserExists(userForRegisterDto.Email);
                if (!userExists.Success)
                {
                    ModelState.AddModelError(string.Empty, userExists.Message);
                    return View(userForRegisterDto);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                if (registerResult.Success)
                {
                    await _emailService.SendWelcomeEmailAsync(userForRegisterDto.Email);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, registerResult.Message);
                }
            }

            return View(userForRegisterDto);
        }

        // POST: /auth/logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // Oturumu sonlandırma işlemleri
            // Örneğin, JWT token tabanlı oturumu sonlandırabilirsiniz

            return RedirectToAction("Index", "Home");
        }

        // GET: /auth/resetpassword
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

     
    }
}
