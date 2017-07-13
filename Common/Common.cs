using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;


namespace Common
{
    public class Common
    {

        public static object ConvertType(string Value,Type Type) {
           
 

            object ReturnData = null;
            switch (Type.FullName)
            {
                case "System.Int32":
                    ReturnData = SqlFunc.ToInt32(Value);
                    break;
                case "System.String":
                    ReturnData = SqlFunc.ToString(Value);
                    break;
                case "System.Decimal":
                    ReturnData = SqlFunc.ToDecimal(Value);
                    break;
                case "System.DateTime":
                    ReturnData = SqlFunc.ToDecimal(Value);
                    break;
                case "System.Double":
                    ReturnData = SqlFunc.ToDouble(Value);
                    break;
                default:
                    throw new Exception("不存在"+ Type.FullName+ "类型的转换函数，请联系开发人月");
            }


            return ReturnData;

        }

        public static string OutScript(string Type,string Message,string Url) {

            string Script = "";

            switch (Type)
            {
                case "Jump": //直接跳转
                    Script += "<script>";
                    Script += "location='" + Url + "'";
                    Script += "</script>";
                    break;
                case "AlertJump"://弹出后跳转
                    Script += "<script>";
                    Script += "alert('"+Message+"')";
                    Script += "location='" + Url + "'";
                    Script += "</script>";
                    break;
                case "":
                    Script += "<script>";
                    Script += "alert('" + Message + "')";
                    Script += "</script>";
                    break;
                default:
                    break;
            }
            return Script;

        }
    }
}
