using System.ComponentModel.DataAnnotations;

namespace ABCD.Company.ViewModel
{
    public class LogInVM
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
