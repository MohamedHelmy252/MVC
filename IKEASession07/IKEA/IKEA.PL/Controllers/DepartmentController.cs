using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController
        (IDepartmentService departmentService,
        ILogger<DepartmentController> logger)
    {
        _departmentService = departmentService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var departments = _departmentService
            .GetAllDepartments().ToList();

        return View("Index", departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreatedDepartmentDto depatmentDto)
    {
        if (!ModelState.IsValid)
            return View(depatmentDto);

        var message = string.Empty;
        try
        {
            var department = _departmentService
                    .CreateDepartment(depatmentDto);

            if (department > 0)
                return RedirectToAction("Index");
            else
            {
                message = "Department Has Not been Created";
                ModelState
                    .AddModelError(string.Empty, message);

                return View(department);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return View(ex.Message);
        }

    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id is null)
            return BadRequest();

        var department = _departmentService
            .GetDepartmentById(id.Value);

        if (department is null)
            return NotFound();

        return View("Details", department);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null)
            return BadRequest();

        var department = _departmentService
            .GetDepartmentById(id.Value);

        if (department is null)
            return NotFound();

        var departmentDto = new UpdatedDepartmentDto
        {
            Code = department.Code,
            Name = department.Name,
            Description = department.Description,
            CreationDate = department.CreationDate,
        };
        return View(departmentDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(UpdatedDepartmentDto departmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var message = string.Empty;
        try
        {
            var updatedDepartment = _departmentService
                .UpdateDepartment(departmentDto) > 0;

            if (updatedDepartment)
                return RedirectToAction("Index");

            message = "Sorry an Error During Update";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return View(ex.Message);
        }

        ModelState.AddModelError(string.Empty, message);
        return View(departmentDto);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null)
            return BadRequest();

        var department = _departmentService
            .GetDepartmentById(id.Value);

        if (department is null)
            return NotFound();

        return View("Delete", department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        try
        {
            var message = string.Empty;

            var departmentDeleted = _departmentService
                .DeleteDepartment(id);

            if (departmentDeleted)
                return RedirectToAction("Index");

            message = "Sorry an Error During Delete";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        return RedirectToAction("Index");
    }
}
