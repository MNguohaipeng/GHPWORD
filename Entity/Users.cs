using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Users:B_EntityBase
    { 
        [SugarColumn(IsNullable = false, Length = 21)]
        public string LoginName { get; set; }

        [SugarColumn(IsNullable = false, Length = 21)]
        public string Password { get; set; }

        [SugarColumn(IsNullable = true, Length = 15)]
        public string RealName { get; set; }

        [SugarColumn(IsNullable = true, Length = 11)]
        public string Phone { get; set; }

        [SugarColumn(IsNullable = true, Length = 80)]
        public string Email { get; set; }

        [SugarColumn(IsNullable = true)]
        public int Age { get; set; }

        [SugarColumn(IsNullable = true, Length = 5)]
        public string Gender { get; set; }


    }
}
