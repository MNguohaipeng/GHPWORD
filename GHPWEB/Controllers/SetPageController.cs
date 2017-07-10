using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHPWEB.Controllers
{
    public class SetPageController : Controller
    {
        // GET: SetPage
        public ActionResult Index()
        {
            return View();
        }

        //编辑页面配置
        public ActionResult EditPage() {
            return View();

        }
        //获取 EditPage  数据列表
        public JsonResult GetEditPageList()
        {
            using (var db=LinkDBHelper.CreateDB())
                try
                {

                 var list=   db.Queryable<Entity.EditPage>().ToList();

                    return Json(new { start = 0, data = list, msg = "" }, JsonRequestBehavior.DenyGet);

                }
                catch (Exception ex)
                {

                    throw;
                }
 
        }
    }
}