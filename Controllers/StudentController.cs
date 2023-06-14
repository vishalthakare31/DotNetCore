using Microsoft.AspNetCore.Mvc;
using CoreCrudOperation.Data;
using CoreCrudOperation.Models;

namespace CoreCrudOperation.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly StudentDbContext _db;
        public StudentController(StudentDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Student> objStudentList = _db.Students.ToList(); 
            return View(objStudentList);
        }
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Student obj)
        {
            
            _db.Students.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit( int? Id)
        {
            if(Id == null || Id==0)
            {
                return NotFound();
            }
            Student studentfromDb = _db.Students.Find(Id);
            if (studentfromDb == null)
            {
                return NotFound();
            }
            return View(studentfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Update(obj);
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
            Student studentfromDb = _db.Students.Find(Id);
            if (studentfromDb == null)
            {
                return NotFound();
            }
            return View(studentfromDb);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {  Student? obj = _db.Students.Find(Id);
            if (ModelState.IsValid)
            {
                _db.Students.Remove(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
