using System.Linq;
using AspMVC.DataContext;
using AspMVC.Models;
using AspMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration; 
        private readonly ILogger<AccountController> _logger;

        public AccountController(IConfiguration configuration, ILogger<AccountController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// 로그인 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspNoteDbContext(_configuration))
                {
                    // Linq - 메서드 체이닝 
                    // => : A Go to B 
                    // var user = db.Users
                    //     .FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);

                    // == : Memory 누수가 발생하기 때문에 equals를 활용해야 함. 
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        // HttpContext.Session.SetInt32(key, value); - key: 식별자 
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        // 로그인에 성공 
                        _logger.LogInformation($@"LoginSuccess - {model.UserId}");
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }
            }

            // 로그인에 실패
            _logger.LogInformation($@"LoginFail - {model.UserId}");
            ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
                    
            return View(model);
        }

        public IActionResult Logout()
        {
            // HttpContext.Session.Clear(); - 모든 세션 삭제  
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// 회원 가입 
        /// </summary>
        /// <returns></returns>
        /// 별도 명시 안 되어 있으면 HttpGet
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            // ModelState.IsValid : Model에 정의한 값 
            if (ModelState.IsValid)
            {
                using (var db = new AspNoteDbContext(_configuration))
                {
                    db.Users.Add(model); // Memory
                    db.SaveChanges(); // Database 
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}