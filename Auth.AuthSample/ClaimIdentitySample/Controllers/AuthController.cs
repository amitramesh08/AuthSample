using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace Auth.AuthSample.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("Secret")]
        public IActionResult Secret()
        {
            return Ok("Test");
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("RegisterUser")]
        public IActionResult Register(string userName, string password)
        {
            return RedirectToAction("Index");
        }

        [Route("LogoutUser")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}