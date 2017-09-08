using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oledb.sqlite
{
    public abstract class AOleDbManager
    {
        public AOleDbManager(string fullpath, string password)
        {
            this.DBFileFullPath = string.Format(@"Data Source={0};foreign keys=True;Version=3;Password={1};", fullpath, password);
        }

        public string DBFileFullPath { get; private set; }

        public SQLiteConnection Conn { get; set; }

        /// <summary>
        /// 단일 쿼리 트랜잭션을 제공하는 핸들러
        /// </summary>
        public OperateQueryHandler OperateQueryHandler
        {
            get
            {
                if (Conn == null || Conn.State == System.Data.ConnectionState.Closed)
                {
                    Open();
                }
                return new OperateQueryHandler(Conn);
            }
        }

        /// <summary>
        /// 트랜잭션안에 여러 쿼리를 처리하는 핸들러
        /// </summary>
        public OperateMultiQueryHandler OperateMultiQueryHandler
        {
            get
            {
                if (Conn == null || Conn.State == System.Data.ConnectionState.Closed)
                {
                    Open();
                }
                return new OperateMultiQueryHandler(Conn);
            }
        }

        public void Open()
        {
            Close();


            Conn = new SQLiteConnection(this.DBFileFullPath);
            Conn.Open();
        }

        public void Close()
        {
            if (Conn != null)
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn.Close();
                }

                Conn.Dispose();
                Conn = null;
            }
        }
    }

    public class OperateQueryHandler : AOperateQuery
    {
        public OperateQueryHandler(SQLiteConnection conn) : base(conn) { }
    }

    public class OperateMultiQueryHandler : AMultiOperateQuery
    {
        public OperateMultiQueryHandler(SQLiteConnection conn) : base(conn) { }
    }
    
}
