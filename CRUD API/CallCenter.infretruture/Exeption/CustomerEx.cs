using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.infretruture.Exeption
{
    public class ManagerEx:Exception
    {
        public ManagerEx(string message) : base(message)
        {
        }
    }
}
