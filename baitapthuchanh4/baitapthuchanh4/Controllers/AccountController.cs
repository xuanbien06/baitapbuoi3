using Microsoft.AspNetCore.Mvc;

namespace baitapthuchanh4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login - Hiển thị form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login - Nhận dữ liệu và kiểm tra
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Kiểm tra điều kiện đăng nhập
            if (username == "admin" && password == "123")
            {
                ViewBag.Message = "Login success";
                ViewBag.CssClass = "text-success"; // Class màu xanh của Bootstrap
            }
            else
            {
                ViewBag.Message = "Login failed";
                ViewBag.CssClass = "text-danger"; // Class màu đỏ của Bootstrap
            }

            return View();
        }
    }
}