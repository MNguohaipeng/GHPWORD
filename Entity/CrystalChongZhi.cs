using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class CrystalChongZhi:B_EntityBase
    {
        //用户ID
        [SugarColumn(IsNullable = false)]
        public int UserId { get; set; }

        //充值数量
        [SugarColumn(IsNullable = false)]
        public int ChongZhiShuLiang { get; set; }


    }
}
