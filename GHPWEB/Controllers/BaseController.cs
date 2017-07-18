using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using SqlSugar;
namespace GHPWEB.Controllers
{
    public class BaseController : Controller
    {



        public JsonResult GetButton(string MenuName)
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    var Menu = db.Queryable<Entity.Menu>().Where(T => T.IsDeleted == false && T.MenuTableName == MenuName).Single();
                    if (Menu == null)
                        throw new RuntimeAbnormal("系统出错：没有查询到对应菜单");

                    var MenuButton = db.Queryable<Entity.MenuButton>().Where(T => T.IsDeleted == false && T.MenuId == Menu.Id).ToList();
                    List<Entity.Button> ButtonList = new List<Entity.Button>();

                    if (MenuButton.Count>0)
                    {
                        for (int i = 0; i < MenuButton.Count; i++)
                        {
                            var ButtonId = MenuButton[i].ButtonId;

                            var Btn = db.Queryable<Entity.Button>().Where(T => T.IsDeleted == false && T.Id == ButtonId).First();
                            if (Btn != null)
                                ButtonList.Add(Btn);
                        }

                    }

                    return Json(new { start = 1, data = ButtonList, msg = "" }, JsonRequestBehavior.DenyGet);

                }
                catch (RuntimeAbnormal ex)
                {
                    throw;//TODO
                }
                catch (Exception)
                {

                   throw;
                }



        }


    }
}