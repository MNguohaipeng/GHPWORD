using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Role:B_EntityBase
    {
        [SugarColumn(IsNullable = true, Length = 30)]
        public string RoleName { get; set; }
 
    }
}
