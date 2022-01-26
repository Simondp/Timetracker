using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetracker.Data_access.Interface
{
    internal interface IRepository <T>
    {
        void Add(T Entity);
        void Remove(int id);

        T Get(int id);
        List<T> GetAll();
       
    }
}
