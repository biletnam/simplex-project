using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS
{
    public class CommandPattern
    {
        System.Windows.Forms.Button _sender = null;
        public CommandPattern(System.Windows.Forms.Button sender)
        {
            _sender = sender;
        }
        public void Execute()
        {


        }
    }
}
