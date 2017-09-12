using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace TomatoTimer2
{
    public class TimerViewModel : BindableBase
    {


        public Counter Counter
        {
            get
            {
                return SharedPreference.Instance.Counter;
            }
        }

        public TimeManager TimeManager
        {
            get
            {
                return SharedPreference.Instance.TimeManager;
            }
        }


        private bool m_isStart;
        public bool IsStart
        {
            get
            {
                return m_isStart;
            }
            set
            {
                m_isStart = value;
                RaisePropertyChanged("IsStart");
            }
        }


        public DelegateCommand StartCountDownCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Counter.startCountDown();
               });
            }
        }


        public DelegateCommand PauseCountDownCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Counter.pauseCountDown();
               });
            }
        }


        public DelegateCommand StopCountDownCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Counter.stopCountDown();
               });
            }
        }


        public DelegateCommand SkipCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Counter.skipCountDown();
               });
            }
        }


        public DelegateCommand ShowSetterViewCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   var window = WindowHelper.GetWindow<MainWindow>();
                   var dc = window.DataContext as MainWindowViewModel;
                   dc.showSetterView();
               });
            }
        }






    }
}
