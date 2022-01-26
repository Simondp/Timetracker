using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetracker.Data_access.Interface;
using Timetracker.Data_access.Models;

namespace Timetracker.Data_access.Interfaces
{
    internal interface ITimeRecordsRepository<T> : IRepository<T>
    {
        List<TimeRecord> GetTimeRecordsByDate(DateTime date);
        List<TimeRecord> GetTimeRecords(DateTime from, DateTime to);
    }
}
