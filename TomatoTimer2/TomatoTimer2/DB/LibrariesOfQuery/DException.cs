using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public class DException : Exception
    {
        public DException(string reason)
        {
            this.Reason = reason;
        }

        public string Reason { get; set; }
    }
}
