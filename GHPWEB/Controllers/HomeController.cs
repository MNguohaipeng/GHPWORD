using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using SqlSugar;
using Entity;

namespace GHPWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {

                    CodeFirstHelper code = new CodeFirstHelper();
   
                }
                catch (Exception ex)
                {

                    throw;
                }
         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}