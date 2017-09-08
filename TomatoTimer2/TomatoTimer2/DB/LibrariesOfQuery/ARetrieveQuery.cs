using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public class ARetrieveQuery<T> : ASingleQuery where T : IResultSet, new()
    {
        public List<T> ResultSet { get; set; }

        public ARetrieveQuery(SQLiteConnection conn)
            : base(conn)
        {
            ResultSet = new List<T>();
        }

        public override bool Exec()
        {
            Result = false;

            SQLiteDataReader reader = Command.ExecuteReader();

            try
            {
                ResultSet.Clear();
                while (reader.Read())
                {
                    T rs = new T();
                    rs.Fetch(reader);
                    ResultSet.Add(rs);
                }
                Result = true;
            }
            catch (DException e)
            {
                reader.Close();
                Command.Dispose();

                throw e;
            }
            catch (Exception) { }
            finally
            {
                reader.Close();
                Command.Dispose();
            }

            return Result;
        }
    }
}
