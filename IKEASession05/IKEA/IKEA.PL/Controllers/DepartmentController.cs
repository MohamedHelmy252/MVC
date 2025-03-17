using AspNetCoreGeneratedDocument;
using BLL.Models.Department;
using BLL.Services;
using IKEA.PL.Models.Department;
using Microsoft.AspNetCore.Mvc;
namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //=======================================================================
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        //=======================================================================


        #region Department Page
        [HttpGet]
     
        public IActionResult Index()
        {
            var departments = _departmentServices.GetDepartments(); // اجلب جميع الأقسام
            return View(departments);
        }

        #endregion
        #region Create Department   
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion 

        #region Post
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTo department)
        //هنا اخذ الداتا من االفورم                                    
        {
            if (!ModelState.IsValid)
            {
                return View(department); //لو مثلا نسيت تكتب الكود هيرجعك 
            }                            //نفس الصفحه تاني عشان تعدل بنفس البيانات    
            //لو البيانات تمام هحفظ بقا وهعرض
            var result = _departmentServices.CreateDepartment(department);
            if (result > 0)//لو البيانات تمام واتحفظت 
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // إضافة الخطأ
                ModelState.AddModelError(string.Empty, "Department Is Not Created");
                return View(department); // يعيد عرض الصفحة مع الخطأ            }

            }
        }
        #endregion

        #endregion
        //========================================================================
        #region Details Department
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            { 
            return NotFound();  
            }
            return View(department);    

        }
        #endregion
        #region  Edit Department

        #region Get
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
            { 
            return BadRequest();
            }

            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            { 
            return NotFound();  
            }
            return View(new DepartmentViewModel() { 
            Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn

            });
            

        }

        #endregion
        #region  Post
        [HttpPost]
        public IActionResult Update([FromRoute] int id, DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            { 
            return View(departmentViewModel);
            }

            try
            {
                var department = new DepartmentUpdateDTO()
                {
                    Id = id,//هنا بجيب الاي دي من الراوت
                    Code = departmentViewModel.Code,
                    Name = departmentViewModel.Name,
                    Description = departmentViewModel.Description
                };


                var UpdatedDepartment = _departmentServices.UpdateDepartment(department);
                if (UpdatedDepartment > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Is Not Updated");
                    return View(departmentViewModel);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Department Is Not Updated");
                return View(departmentViewModel);
            }
   
         

        }
        #endregion


        #endregion
        #region Delete Department     Without View 
        public IActionResult Delete(int id)
        {
            var Result = _departmentServices.DeleteDepartment(id);

            if (Result is true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Department Is Not Deleted");
                return View();
            }

        }
        #endregion
        #region Delete Department     With View 
        //public IActionResult Delete(int? id)
        //{
        //    return View();  
        //}
        #endregion

    }

}

