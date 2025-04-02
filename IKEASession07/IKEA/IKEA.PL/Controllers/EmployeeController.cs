using IKEA.BLL.Models.Employees;
using IKEA.BLL.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController
        (IEmployeeService employeeService,
        IWebHostEnvironment environment, ILogger<EmployeeController> logger)
    {
        _employeeService = employeeService;
        _environment = environment;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var employees = _employeeService.GetAllEmployees();

        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreatedEmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
            return View(employeeDto);

        var message = string.Empty;

        try
        {
            var result = _employeeService.CreateEmployee(employeeDto);

            if (result > 0)
                return RedirectToAction("Index");
            else
            {
                message = "Employee Not Created";

                ModelState.AddModelError(string.Empty, message);

                return View(employeeDto);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            message = _environment.IsDevelopment()
                ? ex.Message
                : "Sorry an Error During Creating the Employee";

            ModelState.AddModelError(string.Empty, message);

            return View(employeeDto);
        }
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id is null) return BadRequest();

        var employee = _employeeService.GetEmployeeById(id.Value);

        if (employee is null) return NotFound();

        return View(employee);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null) return BadRequest();

        var employee = _employeeService.GetEmployeeById(id.Value);

        if (employee is null) return NotFound();

        return View(new UpdateEmployeeDto
        {
            Name = employee.Name,
            Address = employee.Address,
            Email = employee.Email,
            Age = employee.Age,
            Salary = employee.Salary,
            PhoneNumber = employee.PhoneNumber,
            IsActive = employee.IsActive,
            EmployeeType = employee.EmployeeType,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,

        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute] int id, UpdateEmployeeDto employeeDto)
    {
        if (!ModelState.IsValid) return View(employeeDto);

        var message = string.Empty;

        try
        {
            var updated = _employeeService.UpdateEmployee(employeeDto) > 0;

            if (updated) return RedirectToAction("Index");

            message = "Employee is not Updated";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            if (_environment.IsDevelopment())
                message = ex.Message;
            else
                message = "the employee not created";
        }

        ModelState.AddModelError(string.Empty, message);
        return View(employeeDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var message = string.Empty;

        try
        {
            var deleted = _employeeService.DeleteEmployee(id);

            if (deleted) return RedirectToAction("Index");

            message = "Error During Delete";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            message = _environment.IsDevelopment()
                ? ex.Message
                : "Error During Delete";
        }

        return RedirectToAction("Index");
    }
}
