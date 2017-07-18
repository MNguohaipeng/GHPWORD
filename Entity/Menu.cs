using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Menu:B_EntityBase
    {
        [SugarColumn(IsNullable = false, Length = 30)]
        public string MenuName { get; set; }

        [SugarColumn(IsNullable = true, Length = 30)]
        public string MenuTableName { get; set; }

        [SugarColumn(IsNullable = false)]
        public int Level { get; set; }

        [SugarColumn(IsNullable = false)]
        public int ParentID { get; set; }

        [SugarColumn(IsNullable = false, Length = 150)]
        public string Url { get; set; }

        [SugarColumn(IsNullable = true, Length = 20)]
        public string Type { get; set; }

        [SugarColumn(IsNullable = false)]
        public int Order { get; set; }



    }
}
