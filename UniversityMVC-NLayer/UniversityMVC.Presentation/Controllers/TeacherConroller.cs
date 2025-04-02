using Microsoft.AspNetCore.Mvc;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Base;

namespace UniversityMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public IActionResult Index()
        {
            var teachers = teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            teacherRepository.AddTeacher(teacher);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var teacher = teacherRepository.GetTeacherById(id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Update(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            teacherRepository.UpdateTeacher(teacher.Id, teacher.Name, teacher.Surname, teacher.Email);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            teacherRepository.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
