using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Repo;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var result = _departmentRepository.Add(department);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var result = _departmentRepository.Update(department);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            var result = _departmentRepository.Delete(department);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}
