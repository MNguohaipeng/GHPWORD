using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using SqlSugar;
namespace GHPWEB.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        // Post
        [HttpPost]
        public JsonResult Login(string UserName,string Password)
        {
            using (var db=LinkDBHelper.CreateDB())
                try
                {
                    string password = Encryption.Md5(Password);

                   int count= db.Queryable<Entity.Users>().Where(T => T.LoginName == UserName && T.Password == password).Count();

                    if (count <= 0)
                    {
                        return Json(new { start = 1, msg = "用户名或密码错误" }, JsonRequestBehavior.DenyGet);
                    }
                    else {
                        return Json(new { start = 0, msg = "登陆成功" }, JsonRequestBehavior.DenyGet);
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
        }

    }
}