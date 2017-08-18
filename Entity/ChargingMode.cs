using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 计费方式
    /// </summary>
    public class ChargingMode:B_EntityBase
    {

        /// <summary>
        /// 方式 【 0时间 1次数 2不计费 】
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int Type { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string Company { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public double Number { get; set; }


    }
}
