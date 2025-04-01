using Microsoft.AspNetCore.Mvc;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Base;

namespace UniversityMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                return View(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[STUDENT INDEX ERROR]");
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Something went wrong.");
            }    
            // var students = studentRepository.GetAllStudents();
            // return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            studentRepository.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var student = studentRepository.GetStudentById(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            studentRepository.UpdateStudent(student.Id, student.Name, student.Surname, student.Grade, student.Email);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
