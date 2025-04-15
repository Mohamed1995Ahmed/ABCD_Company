using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class Session1Controller : Controller
    {
       public IActionResult SetSesstion(string name,string address)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("address", address);
            return Ok("Session values set successfully.");
        }
   
       public IActionResult GetSesstion()
        {
            var name = HttpContext.Session.GetString("name");
            var address = HttpContext.Session.GetString("address");

            return Content($"name : {name} address : {address}");
        }
        public IActionResult Setcookie()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            HttpContext.Response.Cookies.Append("name", "ali",options);

            HttpContext.Response.Cookies.Append("age", "25");
            return Ok("Cookies Save successfully.");
        }

        public IActionResult GetCookie()
        {
           var name= HttpContext.Request.Cookies["name"];

           var age= HttpContext.Request.Cookies["age"];

            return Content($"Name : {name} Age : {age}");
        }
    }
}
