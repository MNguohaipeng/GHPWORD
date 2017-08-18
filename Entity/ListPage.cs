using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 列配置表
    /// </summary>
    public class ListPage : B_EntityBase
    {

        /// <summary>
        /// 表明
        /// </summary>
        [SugarColumn(IsNullable=false, Length = 100)]
        public string TableName { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 100)]
        public string ColnumName { get; set; }

        /// <summary>
        /// 是否替换原值 0是1否
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int IsReplaceOriginal { get; set; }

        /// <summary>
        /// 替换参数
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1000)]
        public string ReplaceParameter { get; set; }

        /// <summary>
        /// 是否外接数据 0是1否
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int IsWaiJieData { get; set; }

        /// <summary>
        /// 外接表明
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 100)]
        public string OtherTableName { get; set; }

        /// <summary>
        /// 外接字段名
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 100)]
        public string OtherTableFieldZS { get; set; }

        /// <summary>
        /// 外接条件
        /// </summary>
        [SugarColumn(IsNullable = false,Length =1000)]
        public string OtherTableWhere { get; set; }


 


    }
}
