using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class CrystalLibrary:B_EntityBase
    {
        //用户ID
        [SugarColumn(IsNullable = false)]
        public int UserId { get; set; }

        //水晶数量
        [SugarColumn(IsNullable = false)]
        public int CrystalNumber { get; set; }


    }
}
