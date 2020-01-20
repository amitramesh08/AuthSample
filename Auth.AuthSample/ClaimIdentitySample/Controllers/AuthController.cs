using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.AuthSample.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
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
        [HttpGet]
        [Route("RegisterUser")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            
            if (user != null)
            {
                // Sign in user
                //var loginIn = await _signInManager.PasswordSignInAsync(user, password, true,false);
                //if (loginIn.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new IdentityUser()
            {
                UserName = username,
                PasswordHash = password
            };

            var result = await _userManager.CreateAsync(user);
            if ( result.Succeeded )
            {
                var userResult = await _userManager.FindByNameAsync(username);
                if (userResult != null)
                {
                    // Sign in user
                    await _signInManager.SignInAsync(userResult,isPersistent:false);
                    //var loginIn = await _signInManager.PasswordSignInAsync(user, password, true, false);
                }
            }
            return RedirectToAction("Index");
        }

        [Route("LogoutUser")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}