using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*自定义异常捕捉类
* 创建人:郭海鹏
* 创建时间:2017年7月15日09:56:07
*/
  
namespace Core
{

    public class RuntimeAbnormal : Exception
    {

        public RuntimeAbnormal(string _ErrorMessage)
        {
            ErrorMessage = _ErrorMessage;
            OccurrenceTime = DateTime.Now;

        }

        public string ErrorMessage { get; set; }//错误信息

        public DateTime OccurrenceTime { get; set; }//发生时间
 
    }
}
