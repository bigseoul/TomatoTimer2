using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    [Serializable]
    public abstract class AResultSet : IResultSet
    {
        public void Fetch(System.Data.SQLite.SQLiteDataReader reader)
        {
            PropertyInfo[] pis = this.GetType().GetProperties();
            for (int i=0; i<reader.FieldCount; ++i)
            {
                var pi = pis.SingleOrDefault(p => p.Name.Equals(reader.GetName(i)));
                if (pi == null)
                {
                    string line = string.Format("[Oledb.sqlite.AResultSet] reader:{0} -> no property", reader.GetName(i));
                    Console.Out.WriteLineAsync(line);
                }
                else
                {
                    if (reader[pi.Name].GetType() != typeof(DBNull))
                    {
                        pi.SetValue(this, reader[pi.Name]);
                    }
                }
            } // end for
        }
    }
}
