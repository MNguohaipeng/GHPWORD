using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MenuButton : B_EntityBase
    {
        public int ButtonId { get; set; }

        public int MenuId { get; set; }
        [SugarColumn(IsNullable = false, Length = 100)]
        public string JurisdictionCode { get; set; }//权限代码

    }
}
