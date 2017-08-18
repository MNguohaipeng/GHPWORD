using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Configuration;
using System.Data;

namespace Core
{
    public class CodeFirstHelper
    {

        public CodeFirstHelper()
        {
            UpdateDB();
        }

        /// <summary>
        /// 根据实体类生成表
        /// </summary>
        /// <param name="TableName">库名</param>
        /// <param name="ClassName">实体类名</param>
        /// <returns></returns>
        public bool ProducedTable<T>(T Obj)
        {
            using (var db = LinkDBHelper.CreateDB())

                try
                {

                    db.CodeFirst.InitTables(typeof(T), typeof(Entity.B_CodeTable));


                    return true;
                }
                catch (Exception)
                {
                    throw;
                }



        }

        /// <summary>
        /// 更新所有表结构
        /// </summary>
        /// <returns></returns>
        public bool UpdateDB()
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
 
                    List<object> List = new List<object>();

                    Assembly assembly = Assembly.Load("Entity");

                    Type[] types = assembly.GetTypes();

                    object obj = new object();

                    foreach (Type tp in types)
                    {

                        if (tp.ToString().IndexOf("B_") > 0)
                            continue;


                        db.CodeFirst.InitTables(tp, typeof(B_CodeTable));
                    }

                    GeneratePage.Gpage();//生成

                    GetAllTable();

                    return true;

                }
                catch (Exception ex)
                {

                    throw;
                }


        }

        //获取所有entity
        public static List<object> GetEntityList()
        {

            List<object> List = new List<object>();

            Assembly assembly = Assembly.Load("Entity");
            Type[] types = assembly.GetTypes();
            object obj = new object();

            foreach (Type tp in types)
            {
                if (tp.ToString().IndexOf("B_") > 0)
                    continue;


                List.Add(Activator.CreateInstance(tp));//将所有类放入List
            }
            return List;
        }

        //更新所有页面地址数据
        public static void UpdatePageUrl()
        {


        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        public static void GetAllTable()
        {
            using (var db = LinkDBHelper.CreateDB())
                try
                {
                    string SqlType = ConfigurationManager.ConnectionStrings["ConnectionStringType"].ToString();

                    string SQLType = ConfigurationManager.ConnectionStrings["ConnectionStringType"].ToString();

                    string Sql = "";

                    switch (SQLType)
                    {
                        //INFORMATION_SCHEMA.TABLES      
                        case "MYSQL":
                            Sql = "SELECT TABLE_NAME as name,CREATE_TIME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'GHPWORKDB'";

                            break;
                        case "SQLSERVER":
                            Sql = "select name from sysobjects";
                            break;
                        default:
                            throw new Exception(string.Format("系统中并不包含{0}类型数据库操作", SQLType));

                    }

                    List<Entity.AllTableInfo> list = new List<AllTableInfo>();

                    DataTable table=db.Ado.GetDataTable(Sql);

                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        Entity.AllTableInfo tabledto = new AllTableInfo();

                        tabledto.TableName = table.Rows[i]["name"].ToString();

                        tabledto.IsDeleted = false;

                        tabledto.CreateTableTime = Convert.ToDateTime(table.Rows[i]["CREATE_TIME"]);

                        tabledto.CreateTime = DateTime.Now;

                        list.Add(tabledto);

                    }
 
                    db.Deleteable<Entity.AllTableInfo>().ExecuteCommand();

                    db.Insertable<Entity.AllTableInfo>(list).ExecuteCommand();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

    }
}
