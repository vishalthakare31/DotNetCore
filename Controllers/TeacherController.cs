using CoreCrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using CoreCrudOperation.Data;
using System.Diagnostics;
namespace CoreCrudOperation.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherDbContext _db;
        public TeacherController(TeacherDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Teacher> objTeacherList = _db.Teachers.ToList();
            return View(objTeacherList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher obj)
        {

            _db.Teachers.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Teacher studentfromDb = _db.Teachers.Find(Id);
            if (studentfromDb == null)
            {
                return NotFound();
            }
            return View(studentfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Teacher TeacherfromDb = _db.Teachers.Find(Id);
            if (TeacherfromDb == null)
            {
                return NotFound();
            }
            return View(TeacherfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Teacher? obj = _db.Teachers.Find(Id);
            if (ModelState.IsValid)
            {
                _db.Teachers.Remove(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
