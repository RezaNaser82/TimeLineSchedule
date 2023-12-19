using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Resume.Core.Security;
using System.Security.Claims;
using TimeLineSchedule.Core.DTOs.User;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;


        }

        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _userService.IsExistUserName(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده استفاده شده است");
                return View(model);
            }

            User user = new User()
            {
                UserName = model.UserName,
                Password = PasswordHelper.EncodePasswordMd5(model.Password),
                RoleId = 4
            };
            await _userService.AddUser(user);

            TempData["Register"] = true;
            return RedirectToAction("Login");
        }

        #endregion

        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            ViewBag.Register = TempData["Register"];
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userService.LogInUser(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                return View();
            }
            var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role , user.UserRole.RoleName)


                };
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync(principal);

            return Redirect("/");
        }
        #endregion

    }
}

