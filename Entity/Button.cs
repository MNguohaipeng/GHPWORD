using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Button:B_EntityBase
    {
        [SugarColumn(IsNullable =true,Length =100)]
        public string ButtonName { get; set; }
        [SugarColumn(IsNullable = true, Length = 100)]
        public string Class { get; set; }
        [SugarColumn(IsNullable = true, Length = 100)]
        public string Type { get; set; }
        [SugarColumn(IsNullable = true, Length = 100)]
        public string Click { get; set; }

    }
}
