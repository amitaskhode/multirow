using SchoolApp.Services;
using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        ResultModel result = new ResultModel();
        // GET: Student
        public ActionResult Index()
        {
            GetViewBagData();
            IRepository<StudentVM> invRep = new StudentVMService();
            Tuple<ResultModel, StudentVM> result = invRep.GetData();
            if (result.Item1.Result == iResultType.iSuccess)
                return View(result.Item2);
            else
                return View();
        }

        public void GetViewBagData()
        {
            if (ViewBag.StateList == null)
            {
                ViewBag.StateList = new List<SelectListItem>() {
                    new SelectListItem {Text="Maharashtra",Value="1" }
                };
            }

            if (ViewBag.CityList == null)
            {
                ViewBag.CityList = new List<SelectListItem>() {
                    new SelectListItem {Text="Mumbai",Value="1" },
                    new SelectListItem {Text="Nagpur",Value="2" },
                    new SelectListItem {Text="Pune",Value="3" }
                };
            }
        }
        [HttpPost]
        public ActionResult Create(IEnumerable<StudentModel> model)
        {
            GetViewBagData();
            IRepository<StudentModel> sRepo = new StudentService();
            StudentModel student = new StudentModel();
            if (model != null)
            {
                foreach(StudentModel s in model)
                {
                    if(s.StudentID != 0)
                    {
                        result = sRepo.Update(s);
                    }
                    else
                    {
                        result = sRepo.Add(s);
                    }                     
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(StudentModel model)
        {
            IRepository<StudentModel> objRepo = new StudentService();
            result = objRepo.Delete(new StudentModel { StudentID = model.StudentID });                        
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}