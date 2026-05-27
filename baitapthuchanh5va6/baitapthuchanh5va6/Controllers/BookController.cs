using Microsoft.AspNetCore.Mvc;
using baitapthuchanh5.Models;

namespace baitapthuchanh5.Controllers
{
    public class BookController : Controller
    {
        // Tạo danh sách sách ảo
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 }
        };

        // 1. Hiển thị danh sách
        public IActionResult Index()
        {
            return View(books);
        }

        // 2. Hiển thị chi tiết một cuốn sách dựa vào ID
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // 3. GET: Hiển thị form thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 4. POST: Xử lý dữ liệu thêm sách
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            // Kiểm tra xem dữ liệu gửi lên có thỏa mãn các Data Annotation bên Model hay không
            if (ModelState.IsValid)
            {
                // Tự động tăng ID
                int newId = books.Any() ? books.Max(b => b.Id) + 1 : 1;
                newBook.Id = newId;

                // Thêm vào danh sách
                books.Add(newBook);

                ViewBag.Message = "Thêm sách thành công!";

                // Xóa dữ liệu cũ trên form sau khi thêm thành công
                ModelState.Clear();
                return View();
            }

            // Nếu dữ liệu bị lỗi (ví dụ: để trống tên, giá <= 0), 
            // nó sẽ trả lại form kèm theo các dòng báo lỗi màu đỏ.
            return View(newBook);
        }
    }
}