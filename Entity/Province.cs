using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Provinces:B_EntityBase
    {
        [SugarColumn(IsNullable = false)]
        public int ProductID { get; set; }

        [SugarColumn(IsNullable = false, Length = 70)]
        public string ProductName { get; set; }

    
 
    }
}
