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
            var students = studentRepository.GetAllStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            studentRepository.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var student = studentRepository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(int id, Student student)
        {
            studentRepository.UpdateStudent(student.Id, student.Name, student.Surname);
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