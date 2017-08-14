using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ImageTable:B_EntityBase
    {
        [SugarColumn(IsNullable = false)] 
        public int UserId { get; set; }

        [SugarColumn(IsNullable = false,Length =1000)]
        public string ImageAddress { get; set; }



    }
}
