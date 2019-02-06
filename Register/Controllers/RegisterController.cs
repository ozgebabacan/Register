using Register.DataManager;
using Register.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Register.Common.Helper;
using Register.Repository;

namespace Register.Controllers
{
    //[RoutePrefix("register")]
    public class RegisterController : BaseController
    {
        // GET: Register
        [Route("")]
        public ActionResult List()
        {
            var studentList = _dataManager.List<Student>();

            var studentViewModelList = Mapper.MapStudentStudentViewModel(studentList.ToList());

            return View(studentViewModelList);
        }

        
        [Route("detail/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

       
        [Route("create")]
        [HttpGet]
        public ActionResult Create()
        {
            var student = new Student();
            LoadCityDropDownViewBag();
            return View(student);
        }

       
        [Route("create/{collection?}")]
        [HttpPost]
       
        public ActionResult Create(Student collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // var student = new Student();
                   collection.City = _dataManager.GetById<City>((int)collection.City.Id);
                   collection.District = _dataManager.GetById<District>((int)collection.District.Id);
                    _dataManager.SaveOrChange(collection);
                    return RedirectToAction("List");
                }
                else
                {
                    LoadCityDropDownViewBag();
                    return View(collection);
                }
                   
            }
            catch
            {
                LoadCityDropDownViewBag();
                return View(collection);
            }
        }

        
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            
            var student = _dataManager.GetById<Student>(id); //context.Student.Where(x=>x.Id == id).FirstOrDefault();
            LoadCityDropDownViewBag();
            LoadDistrictDropDownViewBag(student.City.Id);
            return View(student);
        }

       
        [Route("edit/{id?}/{collection?}")]
        [HttpPost]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var student = new Student();
                    collection.City = _dataManager.GetById<City>((int)collection.City.Id);
                    collection.District = _dataManager.GetById<District>((int)collection.District.Id);
                    _dataManager.SaveOrChange(collection);
                    return RedirectToAction("List");
                }
                else
                {
                    LoadCityDropDownViewBag();
                    return View(collection);
                }

            }
            catch
            {
                LoadCityDropDownViewBag();
                return View(collection);
            }
        }

        // GET: Deneme/Delete/5
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var student = _dataManager.GetById<Student>(id);
            return View(student);
        }

        
        [Route("delete/{id?}/{collection?}")]
        [HttpPost]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                var student = _dataManager.GetById<Student>(id);
                _dataManager.Delete(student);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        [Route("districts/{id?}")]
        [HttpPost]
        public JsonResult GetDistricts(int id)
        {
            if (id == default(int))
            {
                return null;
            }
            try
            {

                var districts = _dataManager.FindBy<District>(x => x.City.Id == id);//context.District.Where(x => x.City_Id == id).ToList();
                var list = districts.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null; //ThrowJSONError(exception);
            }
        }
    }
}