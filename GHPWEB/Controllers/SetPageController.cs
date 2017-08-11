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

        public ActionResult MenuButtonPage() {
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

        //获取菜单
        public JsonResult GetMenu() {
            using (var db=LinkDBHelper.CreateDB())
                try
                {
                    var data = db.Queryable<Entity.Menu>().Where(T => T.IsDeleted == false).ToList();

                    return Json(new { start = 0, data = data }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception)
                {

                    throw;
                }
        }

        //获取按钮
        public JsonResult GetButton()
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    var data = db.Queryable<Entity.Button>().Where(T => T.IsDeleted == false).ToList();

                    return Json(new { start = 0, data = data }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception)
                {

                    throw;
                }
        }

        //获取菜单按钮
        public JsonResult GetMenuButton(int menuId)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    var data = db.Queryable<Entity.MenuButton>().Where(T => T.IsDeleted == false&&T.MenuId== menuId).ToList();

                    return Json(new { start = 0, data = data }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception)
                {

                    throw;
                }
        }

    }
}