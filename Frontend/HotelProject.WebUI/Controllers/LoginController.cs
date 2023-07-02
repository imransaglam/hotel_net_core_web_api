using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            { //üçüncü parametre tarayıcıda hatırlansın mı? sorusunu sorar,dördüncü parametre lockout olsun mu? sorusunu sorar.lockout üste üste hatalı şifre veya kullanıcı adı girdiğinde giriş yapmanı belirli bir süre kısıtlar
                var result= await _signInManager.PasswordSignInAsync(loginUserDto.UserName,loginUserDto.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Staff");
                }
                else
                {
                    return View();
                }
            }
           
            return View();
        }
    }
}
