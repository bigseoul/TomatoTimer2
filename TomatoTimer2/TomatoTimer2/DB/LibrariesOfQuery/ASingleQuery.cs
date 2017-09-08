using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class ASingleQuery : IQuery
    {
        public SQLiteConnection Connection { get; set; }
        public SQLiteCommand Command { get; set; }

        public string Query { get; set; }
        public bool Result { get; set; }
        
        public ASingleQuery()
        {
            Query = "";
            Result = false;
            Connection = null;
            Command = new SQLiteCommand();
        }

        public ASingleQuery(SQLiteConnection conn)
        {
            Query = "";
            Result = false;
            Connection = conn;
            Command = new SQLiteCommand();
        }

        public abstract bool Exec();

        public Exception DoQuery(string query)
        {
            Query = query;
            return DoQuery();
        }

        public Exception DoQuery()
        {
            if (Connection == null)
            {
                return new SQLiteException(SQLiteErrorCode.CantOpen, "Connection 객체가 없습니다.");
            }

            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                {
                    Connection.Open();
                }

                Command.Connection = Connection;
                Command.CommandText = Query;
                Result = Exec();
            }
            catch (Exception e)
            {
                Result = false;
                return e;
            }

            return null;
        }
    }
}
