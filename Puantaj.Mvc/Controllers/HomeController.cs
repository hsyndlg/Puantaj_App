using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;
using Puantaj.Mvc.Models;
using System.Diagnostics;
using System.Security.Policy;

namespace Puantaj.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email veya şifre hatalı");
                        return View(userLoginDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email veya şifre hatalı");
                    return View(userLoginDto);
                }
            }
            return View(userLoginDto);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            _logger.LogDebug("User Getirildi.");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    return View(userAddDto);
                }
            }
            return View(userAddDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}