using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class Setter : BindableBase
    {

        private long m_durationPerWorking = 4;
        public long DurationPerWorking
        {
            get
            {
                return m_durationPerWorking;
            }
            set
            {
                m_durationPerWorking = value;
                RaisePropertyChanged("DurationPerWorking");
            }
        }

        private long m_durationPerShortBreak = 2;
        public long DurationPerShortBreak
        {
            get
            {
                return m_durationPerShortBreak;
            }
            set
            {
                m_durationPerShortBreak = value;
                RaisePropertyChanged("DurationPerShortBreak");
            }
        }

        private long m_durationPerLongBreak = 3;
        public long DurationPerLongBreak
        {
            get
            {
                return m_durationPerLongBreak;
            }
            set
            {
                m_durationPerLongBreak = value;
                RaisePropertyChanged("DurationPerLongBreak");
            }
        }


        private long m_intervalOfLongBreak = 4;
        public long IntervalOfLongBreak
        {
            get
            {
                return m_intervalOfLongBreak;
            }
            set
            {
                m_intervalOfLongBreak = value;
                RaisePropertyChanged("IntervalOfLongBreak");
            }
        }




    }
}
