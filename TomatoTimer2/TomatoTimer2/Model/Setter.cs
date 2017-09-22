using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class Setter : BindableBase
    {

        //초기값 설정을 위해서, Setter에서 데이터 불러옴. 
        public Setter()
        {
            this.Dto = new SetterQuery().SELECT_LOW();
        }


        public Setter(SetterDTO dto)
        {
            this.Dto = dto;
        }

        
        private SetterDTO m_dto;
        public SetterDTO Dto
        {
            get
            {
                return m_dto;
            }
            set
            {
                m_dto = value;
                RaisePropertyChanged("Dto");
            }
        }


        //private long m_durationPerWorking = 4; //dto에 연결하기 위해서 
        public long DurationPerWorking
        {
            get
            {
                return Dto.DURATION_PER_WORKING;
            }
            set
            {
                Dto.DURATION_PER_WORKING = value;
                RaisePropertyChanged("DurationPerWorking");
            }
        }

        //private long m_durationPerShortBreak = 2;
        public long DurationPerShortBreak
        {
            get
            {
                return Dto.DURATION_PER_SHORT_BREAK;
            }
            set
            {
                Dto.DURATION_PER_SHORT_BREAK = value;
                RaisePropertyChanged("DurationPerShortBreak");
            }
        }

        //private long m_durationPerLongBreak = 3;
        public long DurationPerLongBreak
        {
            get
            {
                return Dto.DURATION_PER_LONG_BREAK;
            }
            set
            {
                Dto.DURATION_PER_LONG_BREAK = value;
                RaisePropertyChanged("DurationPerLongBreak");
            }
        }


        //private long m_intervalOfLongBreak = 4;
        public long IntervalOfLongBreak
        {
            get
            {
                return Dto.INTERVAL_OF_LONG_BREAK;
            }
            set
            {
                Dto.INTERVAL_OF_LONG_BREAK = value;
                RaisePropertyChanged("IntervalOfLongBreak");
            }
        }


       
        public bool IsPlayBeep
        {
            get
            {
                return Dto.IS_PLAY_BEEP;
            }
            set
            {
                Dto.IS_PLAY_BEEP = value;
                RaisePropertyChanged("IsPlayBeep");
            }
        }


        public void saveSetterValue()
        {
            updateSetterValue();
        }

        private void updateSetterValue()
        {
            SetterDTO dto = new SetterDTO()
            {
                DURATION_PER_WORKING = DurationPerWorking,
                DURATION_PER_SHORT_BREAK = DurationPerShortBreak,
                DURATION_PER_LONG_BREAK = DurationPerLongBreak,
                INTERVAL_OF_LONG_BREAK = IntervalOfLongBreak,
                IS_PLAY_BEEP = IsPlayBeep
            };

            new SetterQuery().UPDATE(dto);
        }

        public void saveSetterDefaultValue()
        {
            updateSetterDefaultValue();
        }

        private void updateSetterDefaultValue()
        {
            Console.WriteLine("default Setting Info without saving DB");
            DurationPerWorking = 25;
            DurationPerShortBreak = 5;
            DurationPerLongBreak = 15;
            IntervalOfLongBreak = 4;
            IsPlayBeep = true;

        }

    }
}
