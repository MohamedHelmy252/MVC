using BLL.Models.Employee;
using BLL.Services;
using IKEA.DAL.Models.Common;
using IKEA.DAL.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees(); // اجلب جميع الأقسام
            return View(employees);

        }
        #region Create

        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Create(CreateEmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var Result = _employeeService.CreateEmployee(employee);
            if (Result > 0)
            {
                TempData["Message"] = "Employee Created Successfully :)";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "Employee Not Created :(";

                ModelState.AddModelError(string.Empty, "Employee Not Create !!");
                return View(employee);
            }
        }
        #endregion

        #endregion
        #region  Details


        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _employeeService.GetById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);

        }

        #endregion

        #region Update
        #region Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var employee = _employeeService.GetById(id.Value);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);

        }

        #endregion
        #region Post
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit([FromRoute]int? id ,EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDTO);
            }
            if (id is null)
            {
                return BadRequest();
            }

            var employee = _employeeService.UpdateEmployee(employeeDTO);
            if (employee > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();

        
        }

        #endregion


        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var delete = _employeeService.DeleteEmployee(id.Value);
            if (delete)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }

        #endregion 
    }

