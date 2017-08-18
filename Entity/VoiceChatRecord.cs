using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 语音聊天记录表
    /// </summary>
   public class VoiceChatRecord:B_EntityBase
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int UserId { get; set; }

        /// <summary>
        /// 链接用户ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int LinkUserId { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int Often { get; set; }

        /// <summary>
        /// 产生费用
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public double GenerateExpenses { get; set; }


    }
}
