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
    public class ReleaseController : BaseController
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
        public ActionResult Save(FormCollection fm)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    if (fm == null)
                        throw new Exception("编辑数据不能为空");

                    Release EditRelease = new Release();

                    Type type = EditRelease.GetType();

                    object obj = new object();

                    //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
                    foreach (PropertyInfo pi in type.GetProperties())
                    {

                        string name = pi.Name;
                        if (name != "Id" && name != "IsDeleted")
                        {

                            //object TypeIF = pi.GetValue(EditRelease, null);//用pi.GetValue获得值

                            if (!string.IsNullOrEmpty(fm[name]))
                            {

                                pi.SetValue(EditRelease, Common.Common.ConvertType(fm[name], pi.PropertyType));

                            }

                        }

                    }

                    EditRelease.IsDeleted = false;
                    if (EditRelease.CreateTime == null)
                    {
                        EditRelease.CreateTime = DateTime.Now;
                    }

                    int Id ;
                    if (int.TryParse(fm["Id"], out Id))
                    {
                         EditRelease.Id = Id;
                        var t2 = db.Updateable(EditRelease).ExecuteCommand();
                    }
                    else {

                        var t2 = db.Insertable(EditRelease).ExecuteCommand();
                    }

                    return Content(Common.Common.OutScript("AlertJump", "保存成功", "List"));
                }
                catch (Exception ex)
                {

                    throw;
                }


        }

        [HttpPost]
        public JsonResult List(int pageIndex, int pageSize)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    int totalCount = 0;

                    var page = db.Queryable<Release>().Where(T=>T.IsDeleted==false).OrderBy(it => it.Id).ToPageList(pageIndex, pageSize, ref totalCount);

                    return Json(new { start = 0, data = page, totalCount = totalCount, msg = "" }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        [HttpPost]
        public JsonResult GetUpdateData(int Id)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    var data= db.Queryable<Release>().Where(T => T.IsDeleted == false && T.Id == Id).First();

                    return Json(new { start = 0, data = data, msg = "" }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception)
                {

                    throw;
                }
        }

        [HttpPost]
        public JsonResult Delete(string Ids)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                  int [] IdsArrey=Common.Common.OutIntArreyForIds(Ids);

                    List<Release> list = new List<Release>();
                    for (int i = 0; i < IdsArrey.Length; i++)
                    {
                        var Id = IdsArrey[i];
                      var Du= db.Queryable<Release>().Where(T => T.IsDeleted == false && T.Id ==Id).First();
                        Du.IsDeleted = true;
                        list.Add(Du);
                    }

 
                    var num= db.Updateable(list).UpdateColumns(it => new { it.IsDeleted }).ExecuteCommand();
  
                    return Json(new { start = 0, data = "", msg = "" }, JsonRequestBehavior.DenyGet);
                }
                catch (Exception ex)
                {

                    throw;
                }
        }

		}
		
}

 