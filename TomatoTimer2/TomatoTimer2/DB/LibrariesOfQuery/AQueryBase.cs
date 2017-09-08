using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class AQueryBase<T> : IQueryBase<T> where T : AResultSet
    {
        public abstract void DELETE(T dto);
        public abstract void UPDATE(T dto);
        public abstract void INSERT(T dto);
        public abstract void SaveOrUpdate(T dto);
        public abstract List<T> SELECT(object conditions);
    }
}
