using PetApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetApp.Controllers
{
    public class HomeController : Controller
    {


        /// <summary>
        /// Controller for main view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Error = "";
            ViewBag.CatModel = null;
            try
            {
                PetInfo pmodel = new PetInfo();
                ViewBag.CatModel = pmodel.GetCatByGender();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occur: "+ex.Message;
            }
            return View();
        }

    }
}