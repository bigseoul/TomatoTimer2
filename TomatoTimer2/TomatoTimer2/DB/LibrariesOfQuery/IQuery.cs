using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public interface IQuery
    {
        Exception DoQuery(string query);
        Exception DoQuery();
    }
}
