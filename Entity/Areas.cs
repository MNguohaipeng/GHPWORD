using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Areas:B_EntityBase
    {
        [SugarColumn(IsNullable = false)]
        public int areaID { get; set; }


        [SugarColumn(IsNullable = false,Length =70)]
        public string areaName { get; set; }


        [SugarColumn(IsNullable = false)]
        public int areaFather { get; set; }


    }
}
