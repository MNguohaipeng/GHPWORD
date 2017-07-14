using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using SqlSugar;
using Entity;
using System.Reflection;

namespace GHPWEB.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Add()
        {
 
            return View();
        }

        public ActionResult List()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection fm) {
            using (var db=LinkDBHelper.CreateDB())
                try
                {
                    if (fm == null)
                        throw new Exception("编辑数据不能为空");

                    Menu EditMenu = new Menu();

                    Type type = EditMenu.GetType();
 
                    object obj = new object();

                    //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
                    foreach (PropertyInfo pi in type.GetProperties())
                    {
                     
                        string name = pi.Name;
                        if (name != "Id" && name != "IsDeleted" && name != "CreateTime") {
                            //object TypeIF = pi.GetValue(EditMenu, null);//用pi.GetValue获得值
                            if (!string.IsNullOrEmpty(fm[name]))
                            {
                    



                                pi.SetValue(EditMenu, Common.Common.ConvertType(fm[name], pi.PropertyType));
                            }

                        }

                    }

                    EditMenu.IsDeleted = false;
                    EditMenu.CreateTime = DateTime.Now;

                             var t2 = db.Insertable(EditMenu).ExecuteCommand();
                }
                catch (Exception ex)
                {

                    throw;
                }

                 return Content(Common.Common.OutScript("Alert","保存成功","List"));
        }

        [HttpPost]
        public JsonResult List(int pageIndex,int pageSize)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    int totalCount = 0;

                    var page = db.Queryable<Menu>().OrderBy(it => it.Id).ToPageList(pageIndex, pageSize, ref totalCount);

                    return Json(new { start = 0, data = page, totalCount = totalCount, msg = "" }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception ex)
                {

                    throw;
                }

        }


    }
}