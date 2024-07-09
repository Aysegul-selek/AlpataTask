using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
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
                return View(userForLoginDto);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
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
                    
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, registerResult.Message);
                }
            }

            return View(userForRegisterDto);
        }
    }
    }
