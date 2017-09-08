using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public interface IResultSet
    {
        void Fetch(SQLiteDataReader reader);
    }
}
