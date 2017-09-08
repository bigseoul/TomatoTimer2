using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class AMultiOperateQuery : AMultiQuery
    {
        public int AffectedRows { get; set; }

        public AMultiOperateQuery(SQLiteConnection conn)
            : base(conn)
        {
            AffectedRows = 0;
        }

        public override bool Exec()
        {
            try
            {
                AffectedRows = Command.ExecuteNonQuery();
                Result = true;
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }
    }
}
