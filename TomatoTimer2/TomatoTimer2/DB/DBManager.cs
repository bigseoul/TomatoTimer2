using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oledb.sqlite;
using System.Windows.Media;

namespace TomatoTimer2
{
    public class DBManager : AOleDbManager
    {

        public DBManager() : base(string.Format(@"{0}\{1}", Defines.LOCALREPOSITORY_PATH, Defines.LOCALREPOSITORY_FILENAME), "") { }
        
        #region method

        /// <summary>
        /// 초기화
        /// </summary>
        public void Init()
        {
            if (!System.IO.Directory.Exists(Defines.LOCALREPOSITORY_PATH))
            {
                System.IO.Directory.CreateDirectory(Defines.LOCALREPOSITORY_PATH);
            }

            Open();

            CheckSchema();

           // Preload();
        }
        
        /// <summary>
        /// 로컬저장소 스키마 유효성 검사
        /// </summary>
        private void CheckSchema()
        {

            //계정 테이블 유효성 검사
            //var e = OperateQueryHandler.DoQuery(CreateTableQuery.T_CUSTOMER);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_MENU_ITEM);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

          
            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_RECIPE);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_CLASSROOM);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_STUDENT);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_SCORE);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}

            //e = OperateQueryHandler.DoQuery(CreateTableQuery.T_UNIVERSITY);
            //if (e != null)
            //{
            //    Console.Out.WriteLineAsync(string.Format("{0}", e.ToString()));
            //}


        }

        private void Preload()
        {
            //SharedPreference.Instance.Projects.Clear();

            //var dtos = new ProjectQuery().SelectAll();
            //foreach (var dto in dtos)
            //{
            //    SharedPreference.Instance.Projects.Add(new ProjectVM(dto));
            //}
        }
       
        #endregion

    }
}
