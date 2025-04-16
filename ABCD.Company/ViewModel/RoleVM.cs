using System.ComponentModel.DataAnnotations;

namespace ABCD.Company.ViewModel
{
    public class RoleVM
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
