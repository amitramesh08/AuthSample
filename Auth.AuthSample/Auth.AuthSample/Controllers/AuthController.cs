using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction("Index");
        }
    }
}