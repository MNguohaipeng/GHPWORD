using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using SqlSugar;
using Entity;
using System.Reflection;
using System.Configuration;

namespace GHPWEB.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Views()
        {
            return View();
        }

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

        [HttpPost]
        public JsonResult GetMenu()
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    var list = db.Queryable<Entity.Menu>().Where(T => T.IsDeleted == false).ToList();
                    return Json(new { start = 0, data = list, msg = "" }, JsonRequestBehavior.DenyGet);

                }
                catch (Exception)
                {

                    throw;
                }
        }

        [HttpPost]
        public JsonResult GetSelectData(string TableName, string Where, string FildName)
        {

            using (var db = LinkDBHelper.CreateDB())
                try
                {

                    string EntityFileUrl = ConfigurationManager.ConnectionStrings["EntityFileUrl"].ToString();
                    string Sql = "";

                    #region  处理获取字段问题
                    string[] FildArrey = FildName.Split(',');
                    //for (int i = 0; i < FildArrey.Length; i++)
                    //{
                    //    if (!string.IsNullOrEmpty(FildArrey[i])) {
                    //        FildName += FildArrey[i] + ",";
                    //    }

                    //}
                    //FildName.TrimEnd(',');
                    #endregion

                    if (TableName.ToLower().Contains("sys"))
                    {
                        Sql = string.Format("SELECT {1} FROM {0} where 1=1 ", TableName, FildName);
                    }
                    else
                    {
                        Sql = string.Format("SELECT {1} FROM {0} where Isdeleted='false' ", TableName, FildName);
                    }


                    if (!string.IsNullOrEmpty(Where))
                    {
                        Sql += " AND " + Where;
                    }

                    var data = db.Ado.GetDataTable(Sql);

                    AssemblyName assembly = new AssemblyName("Entity"); // 加载程序集（EXE 或 DLL） 
                    var result = Assembly.Load(assembly);


                    List<object> list = new List<object>();


 
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        object obj = result.CreateInstance("Entity." + TableName); // 创建类的实例 






                        for (int a = 0; a < FildArrey.Length; a++)
                        {

                            foreach (PropertyInfo pi in obj.GetType().GetProperties())
                            {
                                if (pi.Name == FildArrey[a])
                                {
                                    if (!string.IsNullOrEmpty(data.Rows[i][pi.Name].ToString()))
                                    {
                                        pi.SetValue(obj, Common.Common.ConvertType(data.Rows[i][pi.Name].ToString(), pi.PropertyType));
                                    }
                                }

                            }


                        }
                        list.Add(obj);

                    }



                    return Json(new { start = 0, data = list, msg = "" }, JsonRequestBehavior.DenyGet);

                }
                catch (Exception ex)
                {

                    throw;
                }

        }
    }
}