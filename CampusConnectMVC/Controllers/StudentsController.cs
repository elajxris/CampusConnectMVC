using Microsoft.AspNetCore.Mvc;
using CampusConnectMVC.Data;
using CampusConnectMVC.Models;
using CampusConnectMVC.Models.Entities;

namespace CampusConnectMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddStudentViewModel viewModel)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Email = viewModel.Email,
                Course = viewModel.Course,
                Phone = viewModel.Phone
            };

            dbContext.Students.Add(student);

            dbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = dbContext.Students.ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var student = dbContext.Students.Find(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student viewModel)
        {
            var student = dbContext.Students.Find(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Course = viewModel.Course;
                student.Phone = viewModel.Phone;

                dbContext.SaveChanges();
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(Student viewModel)
        {
            var student = dbContext.Students.Find(viewModel.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(student);

                dbContext.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}