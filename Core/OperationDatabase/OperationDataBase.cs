using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OperationDatabase
{
   public class OperationDataBase:CodeFirstHelper
    {

        public OperationDataBase():base() {

        }

        //单条添加
        public static void Add(object Obj, SqlSugarClient db) {
         
                try
                {
                    if (Obj == null)
                        throw new Exception("系统出错：参数Obj不能为NULL，位置：OperationDataBase.Add");
                    db.Insertable(Obj).ExecuteCommand();
                }
                catch (Exception ex)
                {

                    throw;
                }
        }
        //批量添加  带事物
        public static void Add<T>(List<T> List, SqlSugarClient db) {
            try
            {
                db.Ado.BeginTran();
                foreach (var item in List)
                {
                    Add(item,db);
                }

                db.Ado.CommitTran();
            }
            catch (Exception)
            {
                db.Ado.RollbackTran();
                throw;
            }
     
        }


    }
}
