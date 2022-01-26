using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetracker.Data_access.Interfaces;
using Timetracker.Data_access.Models;

namespace Timetracker.Data_access.Repositories
{
    internal class TimeRecordRepository : Repository<TimeRecord>, ITimeRecordsRepository<TimeRecord>
    {
        public TimeRecordRepository(FileContext ctx) : base(ctx)
        {
        }

        public List<TimeRecord> GetTimeRecords(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<TimeRecord> GetTimeRecordsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
