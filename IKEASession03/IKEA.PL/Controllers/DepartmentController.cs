using AspNetCoreGeneratedDocument;
using BLL.Models.Department;
using BLL.Services;
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
            #endregion

            #endregion
        }

    }
}
