using Register.DataManager;
using Register.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Register.Repository;

namespace Register.Controllers
{
    public class BaseController : Controller
    {
        internal DataManagerHelper _dataManager;
        public BaseController()
        {
            _dataManager = new DataManagerHelper();
        }

        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

        public void LoadCityDropDownViewBag()
        {
            try
            {
               var cities = _dataManager.List<City>();
               var list = new SelectList(cities, "Id", "Name");//cities.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                ViewBag.Cities = list;
            }
            catch (Exception exception)
            {
                throw exception;//new Exception(exception.Message);
            }
        }


        public void LoadDistrictDropDownViewBag(long id)
        {
            try
            {
                var districts = _dataManager.FindBy<District>(x=>x.City.Id == id).ToList();
                var list = new SelectList(districts, "Id", "Name");//cities.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                ViewBag.Districts = list;
            }
            catch (Exception exception)
            {
                throw exception;//new Exception(exception.Message);
            }
        }

    }
}