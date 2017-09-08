using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class AMultiQuery : IQuery
    {
        public SQLiteConnection Connection { get; set; }
        public SQLiteCommand Command { get; set; }

        public List<string> Queries { get; set; }
        public bool Result { get; set; }

        public AMultiQuery(SQLiteConnection conn)
        {
            Queries = new List<string>();
            Result = false;
            Connection = conn;
            Command = new SQLiteCommand();
        }

        public abstract bool Exec();
        
        public Exception DoQuery(string query)
        {
            throw new NotImplementedException();
        }

        public Exception DoQuery()
        {
            if (Connection == null)
            {
                return new SQLiteException(SQLiteErrorCode.CantOpen, "Connection 객체가 없습니다.");
            }
            if (Queries.Count == 0)
            {
                return new SQLiteException(SQLiteErrorCode.Empty, "지정된 쿼리가 없습니다.");
            }

            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }

            SQLiteTransaction transaction = Connection.BeginTransaction();
            Command.Transaction = transaction;
            Command.Connection = Connection;

            foreach (string query in Queries)
            {
                Command.CommandText = query;
                try
                {
                    Result = Exec();
                }
                catch (Exception e)
                {
                    Result = false;
                    transaction.Rollback();
                    Command.Dispose();
                    transaction.Dispose();

                    return e;
                }
            }

            transaction.Commit();
            Command.Dispose();
            transaction.Dispose();

            return null;
        }
    }
}
