using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models;
using MvcTest.Util;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        EatContext db = new EatContext();
        UserContext udb = new UserContext();
        
        public ActionResult Index()
        {
            
            // получаем из бд все объекты Book
            IEnumerable<Eats> Eats = db.Eats;
            ViewBag.Eats = Eats;
            return View();

        }

        // GET: Home 
        [Authorize(Roles = "admin, merchant")]
        public ActionResult UploadFiles()
        {
            return View();
        }
        [Authorize(Roles = "admin, merchant")]
        
        [Authorize(Roles = "admin, merchant")]
        [HttpPost]
        public ActionResult AddEat(Eats objbook)
        {

            if (ModelState.IsValid)
            {
                this.db.Eats.Add(objbook);
                this.db.SaveChanges();
                if (ViewBag.Id > 0)
                {
                    ViewBag.Success = "Добавлено";

                }
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles="admin, tenindaja")]
        [HttpGet]
        public ActionResult AddEat()
        {
            IEnumerable<Eats> eats = db.Eats;
            ViewBag.Eats = eats;
            return View();
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult Admin()
        {
            ViewBag.Eats = this.db.Eats.ToList();
            ViewBag.Users = this.udb.Users.ToList();
            ViewBag.Roles = this.udb.Roles.ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Admin(FormCollection formCollection)
        {
            try { string[] ids = formCollection["BookID"].Split(new char[] { ',' }); foreach (string bookid in ids)
                {
                    var book = this.db.Eats.Find(int.Parse(bookid));
                    this.db.Eats.Remove(book);
                    this.db.SaveChanges();
                }
            } catch(Exception) { }
            try { string[] ids1 = formCollection["UserID"].Split(new char[] { ',' }); foreach (string userid in ids1)
                {
                    var user = this.udb.Users.Find(int.Parse(userid));
                    this.udb.Users.Remove(user);
                    this.udb.SaveChanges();
                }
            } catch (Exception) { }
            try { string [] ids2 = formCollection["RoleID"].Split(new char[] { ',' }); foreach (string roleid in ids2)
                {
                    var role = this.udb.Roles.Find(int.Parse(roleid));
                    this.udb.Roles.Remove(role);
                    this.udb.SaveChanges();
                }
            } catch (Exception) { }
            return RedirectToAction("Admin");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        public ActionResult GetVoid(int id)
        {
            if (id > 3)
            {
                return RedirectToAction("Contact");
            }
            return View("About");
        }


        public ActionResult Contact()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult EditEat(int id)
        {
            var Bookdata = db.Eats.Where(b => b.Id == id).FirstOrDefault();
            if (Bookdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Bookdata);
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditEat(Eats objbook)
        {

            int StudentId = (int)TempData["StudentId"];
            var StudentData = this.db.Eats.Where(b => b.Id == StudentId).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.Nimetus = objbook.Nimetus;
                StudentData.Hind = objbook.Hind;
                db.Entry(StudentData).State = EntityState.Modified;
                this.db.SaveChanges();
            }
            return RedirectToAction("Admin");
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditUser(int id)
        {
            var Userdata = udb.Users.Where(u => u.Id == id).FirstOrDefault();
            if (Userdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Userdata);
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditUser(User objbook)
        {

            int StudentId = (int)TempData["StudentId"];
            var StudentData = this.udb.Users.Where(u => u.Id == StudentId).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.Email = objbook.Email;
                StudentData.Password = objbook.Password;
                StudentData.Age = objbook.Age;
                StudentData.RoleId = objbook.RoleId;
                udb.Entry(StudentData).State = EntityState.Modified;
                this.udb.SaveChanges();
            }
            return RedirectToAction("Admin");
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditRole(int id)
        {
            var Userdata = udb.Roles.Where(r => r.Id == id).FirstOrDefault();
            if (Userdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Userdata);
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditRole(Role objbook)
        {

            int StudentId = (int)TempData["StudentId"];
            var StudentData = this.udb.Roles.Where(r => r.Id == StudentId).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.Name = objbook.Name;
                udb.Entry(StudentData).State = EntityState.Modified;
                this.udb.SaveChanges();
            }
            return RedirectToAction("Admin");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Eats(int id)
        {
            ViewBag.User = User.Identity.Name;
            ViewBag.Id = id;
            return View();
            
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Eats(Kokkale kokkale)
        {
            
            if (ModelState.IsValid)
            {
                kokkale.Date = DateTime.Now;
                db.Kokkale.Add(kokkale);
                db.SaveChanges();
                return RedirectToAction("Thanks", kokkale);
            }
            else
            {
                ViewBag.Id = kokkale.EatId;
                return View();
            }
        }

        [Authorize]
        public ActionResult Thanks(Kokkale kokkale)
        {
            
            foreach (Eats b in db.Eats)
                if (b.Id == kokkale.EatId) ViewBag.BookName = b.Nimetus;

            //кодирование
            string passwordOriginal = "Esthete2711";
            byte[] bytesOriginal = Encoding.UTF8.GetBytes(passwordOriginal);
            string passwordBase64 = Convert.ToBase64String(bytesOriginal);
            //декодирование
            byte[] bytesDecode = Convert.FromBase64String(passwordBase64);
            string passwordDecode = Encoding.UTF8.GetString(bytesDecode);

            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(Kokkale kokkale)
        {
            if(ModelState.IsValid)
            {
                return View("Thanks", kokkale);
            }
            else
            {
                return View();
            }
        }
    }
}