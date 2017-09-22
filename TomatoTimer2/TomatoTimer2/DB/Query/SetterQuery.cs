using Oledb.sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class SetterQuery : AQueryBase<SetterDTO>
    {
        public override void DELETE(SetterDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void INSERT(SetterDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void SaveOrUpdate(SetterDTO dto)
        {
            throw new NotImplementedException();
        }

        public override List<SetterDTO> SELECT(object conditions)
        {
            throw new NotImplementedException();
        }

        public SetterDTO SELECT_LOW()
        {
            var query = new ARetrieveQuery<SetterDTO>(SharedPreference.Instance.DBM.Conn)
            {
                Query = string.Format(@"SELECT * FROM T_SETTER")
            };
            var e = query.DoQuery();
            if (e != null)
            {
                return new SetterDTO();
            }

            SetterDTO resultOfLow = query.ResultSet[0];
            return resultOfLow;

        }

        public override void UPDATE(SetterDTO dto)
        {
            var query = new OperateQueryHandler(SharedPreference.Instance.DBM.Conn)
            {
                // Query = $@"UPDATE T_CUSTOMER SET DURATION_OF_WORKING = '{dto.DURATION_OF_WORKING}' WHERE USER_ID ='{dto.USER_ID}'"
                Query = $@"UPDATE T_SETTER SET 
                            DURATION_PER_WORKING = '{ dto.DURATION_PER_WORKING }', 
                            DURATION_PER_SHORT_BREAK = '{ dto.DURATION_PER_SHORT_BREAK }', 
                            DURATION_PER_LONG_BREAK = '{ dto.DURATION_PER_LONG_BREAK }', 
                            INTERVAL_OF_LONG_BREAK ='{ dto.INTERVAL_OF_LONG_BREAK }', 
                            IS_PLAY_BEEP ='{dto.IS_PLAY_BEEP}'"
            };
            var e = query.DoQuery();
        }
    }
}
