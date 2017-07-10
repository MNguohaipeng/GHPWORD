using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class PageUrl:B_EntityBase
    {
        [SugarColumn(IsNullable = false, Length = 50)]
        public string PageName { get; set; }

        [SugarColumn(IsNullable = false, Length = 50)]
        public string EntityName { get; set; }

        [SugarColumn(IsNullable = false, Length = 500)]
        public string HtmlUrl { get; set; }

        [SugarColumn(IsNullable = false, Length = 500)]
        public string ControllerUrl { get; set; }

        [SugarColumn(IsNullable =false)]
        public bool IsUserEdit { get; set; }


    }
}
