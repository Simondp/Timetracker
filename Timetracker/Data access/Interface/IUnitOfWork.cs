using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetracker.Data_access.Repositories;

namespace Timetracker.Data_access.Interface
{
    internal interface IUnitOfWork
    {
        public void Save();
        public void Dispose();

    }
}
