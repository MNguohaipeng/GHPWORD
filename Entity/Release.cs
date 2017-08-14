using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Release:B_EntityBase
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int UserId { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1000)]
        public string JieShao { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1000)]
        public string BiaoQian { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 1000)]
        public string ShuoMing { get; set; }
        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [SugarColumn(IsNullable = false,Length =1000)]
        public string XingQuAiHao { get; set; }
        /// <summary>
        /// 总时常
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public double TotalDuration { get; set; }
    }
}
