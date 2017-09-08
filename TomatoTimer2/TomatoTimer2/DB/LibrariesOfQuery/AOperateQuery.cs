using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class AOperateQuery : ASingleQuery
    {
        public int AffectedRows { get; set; }
        public object ID { get; set; }

        private bool m_returnId;

        public AOperateQuery(SQLiteConnection conn, bool returnID = false)
            : base(conn)
        {
            m_returnId = returnID;

            AffectedRows = 0;
            ID = null;
        }

        public override bool Exec()
        {
            Result = false;
            
            SQLiteTransaction transaction = Connection.BeginTransaction();
            Command.Transaction = transaction;

            try
            {
                AffectedRows = Command.ExecuteNonQuery();

                if (m_returnId)
                {
                    Command.CommandText = "SELECT LAST_INSERT_ID();";
                    ID = Command.ExecuteScalar();
                }

                transaction.Commit();
                Result = true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                Command.Dispose();
            }

            return Result;
        }
    }
}
