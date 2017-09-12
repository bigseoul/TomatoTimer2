using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TomatoTimer2
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 선택된 유저콘트롤을 MainView에서 보여주기 위해서
        /// 프로퍼티로 선언.
        /// </summary>
        private UserControl m_view;
        public UserControl View
        {
            get
            {
                return m_view;
            }
            set
            {
                m_view = value;
                RaisePropertyChanged("View");
            }
        }


        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   View = new TimerView(); //초기화면은 타미어View
               });
            }
        }


        /// <summary>
        /// View를 선택할 수 있게 하는 메서드
        /// </summary>
        /// 
        public void showTimerView()
        {
            var view = new TimerView();

            //view를 UserContorl View에 넘겨줌
            this.View = view;
        }
        public void showSetterView()
        {
            var view = new SetterView();
            this.View = view;
        }
        //public void ShowStatistics()
        //{
        //    var view = new StatisticsView();
        //    this.View = view;
        //}
        //public void ShowStatisticsItem(string selectedDate)
        //{
        //    var view = new StatisticsItemView(selectedDate);
        //    this.View = view;
        //}
    }
}
