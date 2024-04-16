using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using UserManagement.DataAccess.Data;
using UserManagement.Models.Models;
using UserManagement.Utility.XmlHelper;

namespace UserManagement.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private static string _Search = "";
        protected int iDValue
        {
            get { return _db.Users.Count; }
        }

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objUserList = _db.Users;
            //return View(objUserList);
            return View();
        }

        

        [HttpPost]
        public void ExportToXML()
        {
            List<User> result;

            if (string.IsNullOrEmpty(_Search) || _Search.Length<3)
            {
                result = _db.Users;
                
            }
            else
            {
                result = _db.FindAll(a =>
                a.UserName.ToLower().Contains(_Search)
                || a.FirstName.ToString().Contains(_Search)
                || a.LastName.ToString().Contains(_Search));
            }

            XmlFileHandler.WriteEntitiesToXMLFile("users", result);

        }

        public PartialViewResult SearchUsers(string searchText)
        {
            
            if (searchText != null)
            {
                _Search = searchText;

                if (searchText.Length >= 3)
                {

                    var result = _db.FindAll(a =>
                                    a.UserName.ToLower().Contains(searchText)
                                    || a.FirstName.ToString().Contains(searchText)
                                    || a.LastName.ToString().Contains(searchText));
                    
                    return PartialView("_UserGrid", result);
                }
            }

            return PartialView("_UserGrid", _db.Users);
        }

        #region Create

        public IActionResult Create()
        {
            return View(new User(_db.Users.Count+1, "","","","",DateTime.Now,"",""));
        }
        [HttpPost]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);

                TempData["success"] = "User created successfully";
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            User? UserFromDb = _db.Users.FirstOrDefault(u => u.Id == id);

            if (UserFromDb == null) { return NotFound(); }

            return View(UserFromDb);
        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);

                TempData["success"] = "User updated successfully";
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            User? userFromDb = _db.Users.FirstOrDefault(u => u.Id == id);

            if (userFromDb == null) { return NotFound(); }

            return View(userFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            User? obj = _db.Users.Find(u => u.Id == id);
            if (obj == null) { return NotFound(); }

            _db.Remove(obj);

            TempData["success"] = "User deleted successfully";

            return RedirectToAction("Index", "User");
        }

        #endregion
    }
}
