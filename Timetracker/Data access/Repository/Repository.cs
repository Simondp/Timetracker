using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetracker.Data_access.Interface;

namespace Timetracker.Data_access.Repositories
{
    internal class Repository<T> : IRepository<T>
    {
        private readonly FileContext _fileContext;

        public Repository(FileContext ctx) 
        {
            _fileContext = ctx;
        }
        public void Add(T Entity)
        {
            if (Entity is null) { throw new NullReferenceException("Entity cannot be null"); }
            _fileContext.Create(Entity);
        }

        public void AddRange(List<T> Entities)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            var result = _fileContext.Retreive(typeof(Repository<T>).GetGenericArguments()[0].Name, id);
            return JsonConvert.DeserializeObject<T>(result);

        }


        public List<T> GetAll()
        {
            var result = _fileContext.RetreiveAll(typeof(Repository<T>).GetGenericArguments()[0].Name);
            return (List<T>) result;
        }



        public void Remove(int id)
        {
            _fileContext.Delete(typeof(Repository<T>).GetGenericArguments()[0].Name, id);
        }
    }
}
