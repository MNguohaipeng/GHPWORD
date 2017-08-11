using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class RoleJurisdiction:B_EntityBase
    {
        [SugarColumn(IsNullable = true)]
        public int RoleId { get; set; }//角色ID

        [SugarColumn(IsNullable = true, Length = 1000)]
        public string JurisdictionCode { get; set; }//权限代码

        [SugarColumn(IsNullable = true)]
        public int MenuId { get; set; }//菜单ID

        [SugarColumn(IsNullable = true)]
        public int MenuJurisdiction { get; set; }//菜单权限

    }
}
