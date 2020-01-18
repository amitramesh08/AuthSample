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

        [Route("AuthoizeMe")]
        public IActionResult Authorize()
        {
            var gramClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Ruy"),
                new Claim(ClaimTypes.Email,"Ruy@fmail.com"),
                new Claim("gramIdentity","Your Name is Ruy")
            };

            var gramIdentity = new ClaimsIdentity(gramClaim,"Gram Identity");
            var userPrinciple = new ClaimsPrincipal(new[] { gramIdentity });

            HttpContext.SignInAsync(userPrinciple);

            return Ok("Login Successfully");
            //return RedirectToAction("Index");
        }
        [Route("LogoutUser")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}