using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace TomatoTimer2
{
    /// <summary>
    /// 카운터는 시간을 젠다.  
    /// </summary>
    public class Counter : BindableBase
    {
        

        public TimeManager TimeManager
        {
            get
            {
                return SharedPreference.Instance.TimeManager;
            }
        }


        private bool m_isPause;
        public bool IsPause
        {
            get
            {
                return m_isPause;
            }
            set
            {
                m_isPause = value;
                RaisePropertyChanged("IsPause");
            }
        }

        public DispatcherTimer timer;
        //TimeSpan represents a length of time.
        private TimeSpan time;
    
        //얼마나 시간이 남았는지 저장.
        //초기값과 잠시멈춤값을 가지고 있다. 
        private double m_remainingTime;
        public double RemainingTime
        {
            get
            {
                return m_remainingTime;
            }
            set
            {
                m_remainingTime = value;
                RaisePropertyChanged("RemainingTime");
            }
        }

        //화면에 표시하는 역할 
        private string m_displayerForTimerCounting = "00:00";
        public string DisplayerForTimerCounting
        {
            get
            {
                return m_displayerForTimerCounting;
            }
            set
            {
                m_displayerForTimerCounting = value;
                RaisePropertyChanged("DisplayerForTimerCounting");
            }
        }

        #region method
        //시간을 재는 외부인터페이스
        public void startCountDown()
        {
            //1. 시간관리자에게 얼마나 세어야 하는지 메서드
            //2. 시간을 재는 매서드
            tickTimer();
        }

        public void pauseCountDown()
        {
            if(IsPause == false)
            {
                //1. 시계를 멈춘다.
                timer.Stop();
                //2. 상태를 멈춤으로 바꾼다.
                IsPause = true;
                //3. 타이머에 남은 시간을 저장한다. 
                RemainingTime = time.TotalSeconds;
            }              
        }

        //타이머를 중지시키면, 모든 값 디폴트 0로 만든다. 
        public void stopCountDown()
        {
            timer.Stop();
            DisplayerForTimerCounting = "00:00";
            time = TimeSpan.Zero;
        }

        public void skipCountDown()
        {
            //디스패쳐를 멈춘다.
            timer.Stop();
            //다시 틱타이머를 실행한다. 
            tickTimer();
        }

       
        //주어진 초를 줄이는 쓰레드 메서드
        private void tickTimer()
        {
            //1. 일, 잠시휴식, 긴 휴식 시간 정도를 받아온다.
            //잠시멈춤이면, 새로 받아올 필요가 없다. 저장된 남은시간을 쓴다. 
            if (IsPause == false)
            {               
                //시간관리자에게 얼마나 세어야 할지 '초'단위로 물어본다. 
                RemainingTime = TimeManager.informHowLongCountDown();
            }         
            //잠시 멈춤이었을 경우(true), 다시 false로 바꿔준다. 
            IsPause = false;

            //2. 남은 시간을 hh:mm:ss 표시로 바꾼다. 
            time = TimeSpan.FromSeconds(RemainingTime);
            //3. 쓰레드 시작:물어본 시간을 줄이는 스레드 돌림. -1초
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                //hh:mm:ss을 mm:ss으로 바꾸고, 스트링으로 전달함. 시간을 창에 표시. 
                DisplayerForTimerCounting = time.ToString(@"mm\:ss");
                if (time == TimeSpan.Zero)
                {
                    //셀 시간이 끝나면, 디스패쳐 멈춤
                    timer.Stop();
                }
                //-1초 씩 빼줌. 
                time = time.Add(TimeSpan.FromSeconds(-1));
                //Trace.WriteLine(DisplayerForTimerCounting);
            }, Application.Current.Dispatcher);
            timer.Start();
        }
        #endregion method
    } // class end
}
