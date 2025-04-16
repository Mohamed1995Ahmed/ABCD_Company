using ABCD.Company.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View("addrole");
        }
        [HttpPost]
        public async Task <IActionResult> SaveRole(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleVM.RoleName;
                var res = await roleManager.CreateAsync(identityRole);
                if(res.Succeeded)
                {
                    ViewBag.success=true;
                    return View("addrole");
                }
                foreach (var item in res.Errors)
                {
                ModelState.AddModelError("",item.Description);

                }
            }
            return View("addrole",roleVM);
        }
    }
}
