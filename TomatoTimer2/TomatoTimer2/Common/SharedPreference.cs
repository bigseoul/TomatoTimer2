using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    class SharedPreference : BindableBase
    {
        #region singleton

        private SharedPreference()
        {
        }

        private static SharedPreference m_Instance = null;
        public static SharedPreference Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new SharedPreference();
                    m_Instance.DBM = new DBManager();
                    m_Instance.DBM.Init();

                }
                return m_Instance;
            }
            set
            {
                m_Instance = value;
            }
        }

        /// <summary>
        /// 숫자 세는 역할
        /// </summary>
        private Counter m_counter;
        public Counter Counter
        {
            get
            {
                if (m_counter == null)
                {
                    m_counter = new Counter();
                }
                return m_counter;
            }
            set
            {
                m_counter = value;
                RaisePropertyChanged("Counter");
            }
        }

        /// <summary>
        /// 일하는, 휴식 시간등을 관리해주는 애
        /// </summary>
        private TimeManager m_timeManager;
        public TimeManager TimeManager
        {
            get
            {
                if (m_timeManager == null)
                {
                    m_timeManager = new TimeManager();
                }
                return m_timeManager;
            }
            set
            {
                m_timeManager = value;
                RaisePropertyChanged("TimeManager");
            }
        }


        private Setter m_setter;
        public Setter Setter
        {
            get
            {
                if(m_setter == null)
                {
                    m_setter = new Setter();
                }
                return m_setter;
            }
            set
            {
                m_setter = value;
                RaisePropertyChanged("Setter");
            }
        }


        #endregion

        #region property
        /// <summary>
        /// 로컬 데이터베이스 객체
        /// </summary>
        public DBManager DBM { get; set; }
       

        #endregion property

        #region method 


        #endregion

    }
}
