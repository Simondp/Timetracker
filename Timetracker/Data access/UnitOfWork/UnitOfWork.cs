using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetracker.Data_access.Interface;
using Timetracker.Data_access.Interfaces;
using Timetracker.Data_access.Models;
using Timetracker.Data_access.Repositories;

namespace Timetracker.Data_access.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly FileContext _context;
        public UnitOfWork(FileContext filecontex)
        {
            _context = filecontex;
            TimeRecords = new TimeRecordRepository(_context);
        }
        public ITimeRecordsRepository<TimeRecord> TimeRecords{get;set;}
        public void Dispose()
        {

        }

        public void Save()
        {
           _context.Save();
        }
    }
}
