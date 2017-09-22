using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class SetterViewModel : BindableBase
    {
        //Shared에 있는 세터 객체 불러오기
        public Setter Setter
        {
            get
            {
                return SharedPreference.Instance.Setter;
            }
        }

        //타이머뷰로 화면 전환을 하기 위한 커맨드
        public DelegateCommand ShowTimerViewCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   var window = WindowHelper.GetWindow<MainWindow>();
                   var dc = window.DataContext as MainWindowViewModel;
                   dc.showTimerView();
               });
            }
        }


        public DelegateCommand SaveCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Setter.saveSetterValue();
               });
            }
        }


        public DelegateCommand DefaultCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
               {
                   Setter.saveSetterDefaultValue();
               });
            }
        }



    }
}
