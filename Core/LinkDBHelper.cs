using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LinkDBHelper
    {
        #region 链接字符串
     
       
 

        #endregion

        #region 创建链接


        public static SqlSugarClient CreateDB() {


            try
            {

                ConnectionConfig LinkConfig = new ConnectionConfig();
                LinkConfig.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                LinkConfig.IsAutoCloseConnection = true;//是否自动释放数据库，设为true我们不需要close或者Using的操作，
                LinkConfig.InitKeyType = InitKeyType.Attribute;
                switch (ConfigurationManager.ConnectionStrings["ConnectionStringType"].ToString())//数据库类型
                {
                    case "MYSQL":
                        LinkConfig.DbType = DbType.MySql;
                        break;
                    case "SQLSERVER":
                        LinkConfig.DbType = DbType.SqlServer;
                        break;
                    default:
                        throw new Exception("未知数据库类型");
 
                }

                SqlSugarClient db = new SqlSugarClient(LinkConfig); //初始化主键和自增列信息的方式 默认SystemTable

                return db;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

      


        #endregion



    }
 
}
