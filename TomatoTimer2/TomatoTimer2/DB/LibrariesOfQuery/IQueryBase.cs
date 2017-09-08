using Oledb.sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public interface IQueryBase<T> where T : AResultSet
    {
        void SaveOrUpdate(T dto);
        void DELETE(T dto);
        void UPDATE(T dto);
        void INSERT(T dto);
        List<T> SELECT(object conditions);
    }
}
