using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class CreateTableQuery
    {
        //public const string T_STATISTICS = @"
        //    CREATE TABLE IF NOT EXISTS T_STATISTICS
        //    (IDX INTEGER PRIMARY KEY AUTOINCREMENT,
        //    TYPE VARCHAR NOT NULL,
        //    DATE DATE,
        //    TIME DOUBLE,
        //    COUNT INTEGER)";

        //SETTING에 초기값을 INSERT함. 
        public const string T_SETTER = @"
            CREATE TABLE IF NOT EXISTS T_SETTER
            (DURATION_PER_WORKING INTEGER NOT NULL,
            DURATION_PER_SHORT_BREAK INTEGER NOT NULL,
            DURATION_PER_LONG_BREAK INTEGER NOT NULL,
            INTERVAL_OF_LONG_BREAK INTEGER NOT NULL,
            IS_PLAY_BEEP BOOLEAN NOT NULL,
            IS_NETWORK BOOLEAN NOT NULL);
            ";

        public const string T_STATISTICS = @"
            CREATE TABLE IF NOT EXISTS T_STATISTICS
            (IDX INTEGER PRIMARY KEY AUTOINCREMENT,
            TYPE VARCHAR NOT NULL,
            DATE DATE,
            TIME DOUBLE,
            COUNT INTEGER)";

    }
}
