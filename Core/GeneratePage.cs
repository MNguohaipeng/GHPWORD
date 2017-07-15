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


        //生成  视图和控制器
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


                        string EntityName = data[i].EntityName;

                        var xxx = db.Queryable<Entity.TableString>().Where(T => T.IsDeleted == false && T.TableName == EntityName).ToSql();

                        List < Entity.TableString> TableString = db.Queryable<Entity.TableString>().Where(T => T.IsDeleted == false && T.TableName == EntityName).ToList();

                        //创建list
                        ListHtml(TableString, data[i].EntityName, ProjectFileUrl + data[i].HtmlUrl);
                        //创建Add
                        AddHtml(TableString, data[i].EntityName, ProjectFileUrl + data[i].HtmlUrl, data[i].PageName);
                        //创建Controller
                        Controller(TableString, data[i].EntityName, ProjectFileUrl + data[i].ControllerUrl);


                    }

                }
                catch (Exception ex)
                {
                    throw;
                }

        }


 
        //加载list
        private static void ListHtml(List<Entity.TableString> TableString, string entityName, string HtmlUrl) {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    #region 创建Listhtml
                    using (StreamWriter listhtml = new StreamWriter( HtmlUrl + @"\List.cshtml", false, Encoding.UTF8))//创建文件
                    {
                        string cshtml = File.ReadAllText(ProjectFileUrl + @"\Models\cshtmlList模板.txt");

                        string scriptCode = File.ReadAllText(ProjectFileUrl + @"\Models\ListScript模板.txt");
                        string thead = "";
                        foreach (var item in TableString)
                        {
                            thead += "{";
                            thead += "name:'" + item.FieldShowMing+"',";
                            thead += "value:'" + item.FieldName + "',";
                            thead += "IsOrder:false" + ",";
                            thead += "},";
                        }
                        thead = thead.TrimEnd(',');

                        int[] ButtonIdList = new int[3] { 1, 4, 3 };  //TODO

                        string button = "";

                        for (int i = 0; i < ButtonIdList.Length; i++)
                        {

                            var item = db.Ado.GetDataTable("select * from Button where Id=" + ButtonIdList[i]);

                            if (item.Rows.Count <= 0) {
                                throw new RuntimeAbnormal("没有查询到对应的按钮信息");
                            } else if (item.Rows.Count > 1) {
                                throw new RuntimeAbnormal("查询到多个按钮信息");
                            }

                            button += "{";
                            button += "name:'" + item.Rows[0]["ButtonName"] + "',";
                            button += "click:'" + item.Rows[0]["Click"] + "',";
                            button += "class:'"+ item.Rows[0]["Class"] + "',";
                            button += "type:'" + item.Rows[0]["Type"] + "'";
                            button += "},";

                        }
                        button = button.TrimEnd(',');

                        scriptCode = string.Format(scriptCode, thead, "List", button);
                        scriptCode = scriptCode.Replace("^|", "{");
                        scriptCode = scriptCode.Replace("|^", "}");
                        string ListhtmlString = string.Format(cshtml, entityName,scriptCode);

                        listhtml.Write(ListhtmlString);
                    }
                    #endregion
                }
                catch (RuntimeAbnormal ex) {
                    throw;
                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        private static void AddHtml(List<Entity.TableString> TableString, string entityName, string HtmlUrl,string pageName) {
            using (var db=LinkDBHelper.CreateDB())

            using (StreamWriter sw = new StreamWriter(HtmlUrl + "/Add.cshtml", false, Encoding.UTF8))//创建文件
            {

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

                            switch (one.YSType)
                            {
                                case "6"://Select
                                    if (item.IsOtherTable == false)
                                        throw new Exception("生成下拉框必须要关联到其他表的数据");

                                    //OtherTableWhere


                                    string option = string.Format("<option value='0'>--请选择{0}--</option>", item.FieldShowMing);
                                    string Bc = item.OtherTableFieldBC;
                                    string Zs = item.OtherTableFieldZS;

                                    var dt = db.Ado.GetDataTable(string.Format("select {0} as [Key],{1}  as [Value] from {2} {3}", Zs, Bc, item.OtherTableName, item.OtherTableWhere));
                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        option += "<option value='" + dt.Rows[a]["Value"] + "'>" + dt.Rows[a]["Key"] + "</option>";
                                    }
                                    input += string.Format(one.YSValue, item.FieldShowMing, item.FieldName, option);

                                    break;
                                default:
                                    input += string.Format(one.YSValue, item.FieldShowMing, item.FieldName);
                                    break;

                            }
                        }
                    }

                    #region 创建script

                    string Script = "";

                    Script = "$('#" + TableString[0].TableName + "EditForm').validate({";

                    Script += "rules: {";

                    //Script
                    foreach (Entity.TableString item in TableString)
                    {

                        //判断是否有表单验证 
                        if (!string.IsNullOrEmpty(item.AddWhere))
                        {

                            Script += item.FieldName + ":{ \n";

                            string[] AddWhere = item.AddWhere.Split(',');

                            for (int s = 0; s < AddWhere.Length; s++)
                            {

                                Script += AddWhere[s] + ",\n";

                            }

                            Script = Script.TrimEnd(',');

                            Script += "},\n";

                        }

                    }

                    Script = Script.TrimEnd(',');

                    Script += "}    });";

                    #endregion

                    //读取模板

                    string cshtml = File.ReadAllText(ProjectFileUrl + @"\Models\cshtml模版.txt");

                    string PageName = pageName;

                    string title = "@{Layout = \"~/Views/Shared/_Layout.cshtml\";}";
 
                    string AddHtml = string.Format(cshtml, PageName, entityName + "EditForm", input, title, Script);

                    byte[] bs = Encoding.UTF8.GetBytes(AddHtml);

                    AddHtml = Encoding.UTF8.GetString(bs);

                    sw.Write(AddHtml);

                }
            }
        }

        private static void Controller(List<Entity.TableString> TableString, string entityName, string ControllerUrl)
        {
            using (StreamWriter zs = new StreamWriter(ControllerUrl + "/" + entityName + "Controller.cs", false, Encoding.UTF8))//创建文件
            {

                //读取模板
                //string controllertxt = string.Format(File.ReadAllText(ProjectFileUrl + @"\Models\Controller模板.txt", Encoding.UTF8), entityName);
                using (StreamReader sr = new StreamReader(ProjectFileUrl + @"\Models\Controller模板.txt"))
                {
                    string msg = sr.ReadToEnd();
                    msg = msg.Replace("{0}", entityName);
                    zs.Write(msg);
                }

            }
        }
        }
}
