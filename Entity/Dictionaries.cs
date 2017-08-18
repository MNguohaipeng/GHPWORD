using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 字典表
    /// </summary>
    public class Dictionaries:B_EntityBase
    {
        /// <summary>
        /// 键
        /// </summary>
        [SugarColumn(IsNullable = false,Length =150)]
        public string _Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1000)]
        public string Value { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1500)]
        public string _Explain { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1500)]
        public string Note { get; set; }


    }
}
