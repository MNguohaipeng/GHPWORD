using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CrystalRecord:B_EntityBase
    {
        //用户ID
        [SugarColumn(IsNullable = false)]
        public int UserId { get; set; }

        //类型  0 进  1 出
        [SugarColumn(IsNullable = false)]
        public int Type { get; set; }

        //数量
        [SugarColumn(IsNullable = false)]
        public int Number { get; set; }

        //结余
        [SugarColumn(IsNullable = false)]
        public int JieYu { get; set; }


    }
}
