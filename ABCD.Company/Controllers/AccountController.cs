using System.Security.Claims;
using ABCD.Company.Models;
using ABCD.Company.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signIn;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signIn,
             RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterUserVM vm = new RegisterUserVM
            {
                Role = roleManager.Roles
                .Select(r => new RoleVM { RoleName = r.Name })
                .ToList()
            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserVM registerUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = registerUserVM.UserName;
                appUser.Address = registerUserVM.Address;
                appUser.PasswordHash = registerUserVM.Password;
                appUser.Status = registerUserVM.Status;
              

                

                var identityres = await userManager.CreateAsync(appUser, registerUserVM.Password);
                if (identityres.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, registerUserVM.SelectedRole);

                    await signIn.SignInAsync(appUser, false);
                    return RedirectToAction("index", "department");
                }
                foreach (var item in identityres.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
              registerUserVM.Role = roleManager.Roles
                                .Select(r => new RoleVM { RoleName = r.Name })
                                 .ToList();

            return View("register", registerUserVM);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View("login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM logInVM)
        {
            if (ModelState.IsValid)
            {
                var appUser = await userManager.FindByNameAsync(logInVM.UserName);
                if (appUser is not null)
                {
                    bool found = await userManager.CheckPasswordAsync
                            (appUser, logInVM.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", appUser.Address));
                        await signIn.SignInWithClaimsAsync
                            (appUser, logInVM.RememberMe, claims);
                        //await signIn.SignInAsync (appUser,logInVM.RememberMe);
                        return RedirectToAction("index", "employee");
                    }

                }
                ModelState.AddModelError("", "UserName or Password is Wrong");

            }
            return View("login", logInVM);
        }
        public async Task<IActionResult> SignOut()
        {
            await signIn.SignOutAsync();
            return View("login");
        }
        public IActionResult test()
        {
            if (User.Identity.Name != null)
            {
                string n = User.Identity.Name;
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string address = User.FindFirst("Address")?.Value;
               // string address = User.Claims.FirstOrDefault(c => c.Type == "Address")?.Value;


                return Content($"welcome {n} : id {id} address : {address} ");
            }
            return Content("any thing");

        }
    }
}
