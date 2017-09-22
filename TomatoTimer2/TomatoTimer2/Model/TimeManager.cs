using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    
    /// <summary>
    /// 시간 관리자는 모드(일/짧은휴식/긴휴식)별 시기를 체크하고 알려준다.
    /// 모드에 맞게 젤 시간을 알고 있다.
    /// 일을 얼만큼 했는지 알고 있다.
    /// </summary>
    public class TimeManager : BindableBase
    {
        private int multiplicationForSecond = 1; //60곱하면 분

        public Setter Setter
        {
            get
            {
                return SharedPreference.Instance.Setter;
            }
        }
       
        public double DurationPerWorking
        {
            get
            {
                return Setter.DurationPerWorking * multiplicationForSecond;
            }
          
        }

        public double DurationPerShortBreak
        {
            get
            {
                return Setter.DurationPerShortBreak * multiplicationForSecond;
            }
           
        }

        public double DurationPerLongBreak
        {
            get
            {
                return Setter.DurationPerLongBreak * multiplicationForSecond;
            }

        }

      
        //일한 횟수
        //세팅이 설정해줌. 
        private int numberOfWorking = 0;

        //일 상태값
        private bool isWork = false;

        //각모드를 나태나는 값s
        //timerViewModel에서 가져다 씀. 
        private string m_statusOfMode = string.Empty;
        public string StatusOfMode
        {
            get
            {
                return m_statusOfMode;
            }
            set
            {
                m_statusOfMode = value;
                RaisePropertyChanged("StatusOfMode");
            }
        }


        public double informHowLongCountDown()
        {
            //1. 기존 상태가 일인가?
            //2. 일이라면, 조건에 맞춰서 A.짧은 휴식, B.긴 휴식을 리턴한다. 
            //      4회 일하면 긴 휴식, 아니면 짧은 휴식 
            //3. 일이 아니었다면, 일할 시간을 리턴해준다.
            //      일한 횟수 증가++, 일상태 true;
            if (isWork == true)
            {   
                if((numberOfWorking % 4) != 0)
                {
                    isWork = false;
                    StatusOfMode = "짧은 휴식 시간";
                    return DurationPerShortBreak;
                }
                else if((numberOfWorking % 4) == 0)
                {
                    isWork = false;
                    StatusOfMode = "긴 휴식 시간";
                    return DurationPerLongBreak;
                }// if end
            }//if end

            numberOfWorking = numberOfWorking + 1;
            isWork = true;
            StatusOfMode = "일 하는 시간";
            return DurationPerWorking;
        }

       
    }
}
