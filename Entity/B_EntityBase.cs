using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class B_EntityBase
    {
        public B_EntityBase() {
            IsDeleted = false;
            CreateTime = DateTime.Now;
        }


        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]//自增
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreateTime { get; set; }



    }
}
