using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    //AllowAnonymous attributiyle proje seviyesindeki bütün kurallarda muaf hale getirir.
    [AllowAnonymous]
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
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			//false veya true kullanıcıyı hatırlasın mı ? Beni Hatırla gibi
			//2. false logout tarafı veritabanında yanlış girilen şifre sayısını tutan alan var. 5 ten fazla yanlış girildi bir süre giriş yapamazsınız gibi. 
			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
			if (result.Succeeded) 
			{
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
