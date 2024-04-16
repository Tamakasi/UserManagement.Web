using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagement.DataAccess.Data;
using UserManagement.Models.Models;
using UserManagement.Web.Models;

namespace UserManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            User u = _db.Users.Find(x => x.UserName == userName);

            if(u != null)
            {
                if(u.Password == password)
                {
                    return RedirectToAction("Index", "User");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection frmobj) //Fake LogIn  
        {
            string username = frmobj["userid"];
            string password = frmobj["pwd"];

            User u = _db.Users.Find(x => x.UserName == username);

            if (u != null)
            {
                if (u.Password == password)
                {
                    return RedirectToAction("Index", "User");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
