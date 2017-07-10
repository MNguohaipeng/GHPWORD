using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
 
    public class B_CodeTable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string TestId { get; set; }
    }
}
