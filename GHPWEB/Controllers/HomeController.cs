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
                    Users us = new Users();
                    us.LoginName = "1";
                    us.Password = "2";
                    us.Age = 1;
                    us.RealName = "ceshi";
                    us.Phone = "123";
                    us.Email = "";
                    us.Gender = "";
                    us.CreateTime = DateTime.Now;
                    db.Insertable(us).ExecuteCommand();
                
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