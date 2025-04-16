using Microsoft.AspNetCore.Identity;

namespace ABCD.Company.Models
{
    public class AppUser:IdentityUser
    {
        public string? Address { get; set; }
        public bool? Status {  get; set; }
    }
}
