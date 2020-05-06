using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //[Route("~/Home")]
       // [Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetallEmployees();
            return View(model);
        }
       // [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModels homeDetailsViewModels = new HomeDetailsViewModels()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee details"
            };
            return View(homeDetailsViewModels) ;
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
