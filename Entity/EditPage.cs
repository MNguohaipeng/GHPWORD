using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class EditPage:B_EntityBase
    {
        [SugarColumn(IsNullable = false, Length = 80)]
        public string YSName { get; set; }


        [SugarColumn(IsNullable = false, Length = 1500)]
        public string YSValue { get; set; }


        [SugarColumn(IsNullable = false)]
        public int YSType { get; set; }

 

    }
}
