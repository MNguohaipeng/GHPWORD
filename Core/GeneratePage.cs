using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
namespace Core
{
    public class GeneratePage
    {

        public static string ProjectFileUrl = ConfigurationManager.ConnectionStrings["ProjectFileUrl"].ToString();

        public static void Gpage()
        {
            using (var db = LinkDBHelper.CreateDB())

                try
                {
                    var data = db.Queryable<Entity.PageUrl>().Where(T => T.IsDeleted == false).ToList();//获取所有生成的页面信息

                    for (int i = 0; i < data.Count; i++)
                    {

                        if (Directory.Exists(ProjectFileUrl + data[i].HtmlUrl) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(ProjectFileUrl + data[i].HtmlUrl);
                        }
                        if (Directory.Exists(ProjectFileUrl + data[i].ControllerUrl) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(ProjectFileUrl + data[i].ControllerUrl);
                        }

                        string entityName = data[i].EntityName;

                        #region 创建html
                        using (StreamWriter sw = new StreamWriter(ProjectFileUrl + data[i].HtmlUrl + "/Add.cshtml", false, Encoding.UTF8))//创建文件
                        {



                            var TableString = db.Queryable<Entity.TableString>().Where(T => T.IsDeleted == false && T.TableName == entityName).ToList();

                            if (TableString != null)
                            {

                                string input = "";


                                foreach (var item in TableString)
                                {
                                    var one = db.Queryable<Entity.EditPage>().Where(T => T.IsDeleted == false && T.YSName == item.InputType).First();
                                    if (one == null)
                                    {
                                        //throw new Exception("没有对应的数据类型");
                                    }
                                    else
                                    {
                                        input = string.Format(one.YSValue, item.FieldShowMing, item.FieldName);

                                    }
                                }


                                //读取模板
                                string cshtml = File.ReadAllText(ProjectFileUrl + @"\Models\cshtml模版.txt");

                                string PageName = data[i].PageName;

                                string title = "@{Layout = \"~/Views/Shared/_Layout.cshtml\";}";

                                string AddHtml = string.Format(cshtml, PageName, entityName + "AddForm", input, title);

                                byte[] bs = Encoding.UTF8.GetBytes(AddHtml);
                                AddHtml = Encoding.UTF8.GetString(bs);

                                sw.Write(AddHtml);


                            }
                        }
                        #endregion


                        #region 创建控制器
                        using (StreamWriter zs = new StreamWriter(ProjectFileUrl + data[i].ControllerUrl + "/" + entityName + "Controller.cs", false, Encoding.UTF8))//创建文件
                        {






                            //读取模板
                            //string controllertxt = string.Format(File.ReadAllText(ProjectFileUrl + @"\Models\Controller模板.txt", Encoding.UTF8), entityName);
                            using (StreamReader sr = new StreamReader(ProjectFileUrl + @"\Models\Controller模板.txt"))
                            {
                                string msg=sr.ReadToEnd();
                                msg=msg.Replace("{0}", entityName);
                                zs.Write(msg);
                            }






                            #endregion

                        }
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }


        }




    }
}
