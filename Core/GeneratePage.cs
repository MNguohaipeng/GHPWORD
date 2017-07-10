using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                    var data = db.Queryable<Entity.PageUrl>().Where(T => T.IsDeleted == false).ToList();

                    for (int i = 0; i < data.Count; i++)
                    {

                        if (Directory.Exists(ProjectFileUrl + data[i].HtmlUrl) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(ProjectFileUrl + data[i].HtmlUrl);
                        }

                        using (StreamWriter sw = new StreamWriter(ProjectFileUrl + data[i].HtmlUrl + "/Add.cshtml", false))
                        {

                            Type type = data[i].GetType();

                            //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
                            foreach (PropertyInfo pi in type.GetProperties())
                            {
                                string name = pi.GetValue(data[i], null).GetType().Name;

                                object value1 = pi.GetValue(data[i], null);//用pi.GetValue获得值
           
                               var one=db.Queryable<Entity.EditPage>().Where(T => T.IsDeleted == false&&T.YSName== name).First();
                                if (one == null)
                                {
                                    //throw new Exception("没有对应的数据类型");
                                }
                                else {
                                    sw.Write(one.YSValue);
                                }



                            }
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
