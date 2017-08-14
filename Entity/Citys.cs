using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class Citys:B_EntityBase
    {

        [SugarColumn(IsNullable = false)]
        public int cityID { get; set; }


        [SugarColumn(IsNullable = false,Length =70)]
        public string cityName { get; set; }


        [SugarColumn(IsNullable = false)]
        public int cityFather { get; set; }


    }
}
