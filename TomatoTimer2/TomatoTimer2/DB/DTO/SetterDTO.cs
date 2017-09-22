using Oledb.sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class SetterDTO : AResultSet
    {
        public SetterDTO()
        {
            //초기값. 일 25분, 짧은 휴식 5분, 긴휴식 10분, 긴휴 간격 4회, 비프 On, 네트워크 off 
            DURATION_PER_WORKING = 25;
            DURATION_PER_SHORT_BREAK = 5;
            DURATION_PER_LONG_BREAK = 10;
            INTERVAL_OF_LONG_BREAK = 4;
            IS_PLAY_BEEP = false;
            //IS_NETWORK = false;
        }

        public long DURATION_PER_WORKING { get; set; }

        public long DURATION_PER_SHORT_BREAK { get; set; }

        public long DURATION_PER_LONG_BREAK { get; set; }

        public long INTERVAL_OF_LONG_BREAK { get; set; }

        public bool IS_PLAY_BEEP { get; set; }

        public bool IS_NETWORK { get; set; }
    }
}
