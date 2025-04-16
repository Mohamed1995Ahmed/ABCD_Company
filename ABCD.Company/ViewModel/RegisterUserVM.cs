using System.ComponentModel.DataAnnotations;

namespace ABCD.Company.ViewModel
{
    public class RegisterUserVM
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="ComfirmedPassword")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ComfirmedPassword { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string? SelectedRole { get; set; }
        public List<RoleVM>? Role { get; set; }
        
    }
}
