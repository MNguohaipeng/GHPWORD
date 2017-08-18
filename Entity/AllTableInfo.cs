using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class AllTableInfo
    {

        /// <summary>
        /// 表明
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 100)]
        public string TableName { get; set; }

        /// <summary>
        /// 创建表时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime CreateTableTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }


    }
}
