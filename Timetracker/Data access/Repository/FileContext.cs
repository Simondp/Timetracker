using Newtonsoft.Json;
using System.Text;

namespace Timetracker.Data_access.Repositories
{
    internal class FileContext : IDisposable
    {
        string _filePath { get; set; }
        private List<Object> _files;

        public FileContext()
        {
            _filePath = @"C:\temp\Timetracker";
            _files = new List<object>();
        }

        public void Save()
        {

            foreach (var file in _files)
            {
                var temp = new List<dynamic>();

                if (!Directory.Exists($@"{ _filePath}/{file.GetType().Name}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/"))
                {
                    Directory.CreateDirectory($@"{ _filePath}/{file.GetType().Name}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/");
                }

                if (File.Exists($@"{ _filePath}/{file.GetType().Name}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"))
                {
                    temp = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText($@"{ _filePath}/{file.GetType().Name}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"));
                }

                temp.Add(file);
                File.WriteAllText($@"{_filePath}/{file.GetType().Name}/{DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json", JsonConvert.SerializeObject(temp), Encoding.UTF8);
               
            }

            _files.Clear();

        }

        internal void Delete(string entity, int id) 
        {
            var temp = new List<dynamic>();

            if (!Directory.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/"))
            {
                throw new Exception("No data created today");
            }

            if (!File.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"))
            {
                throw new Exception("No data created today");
            }

            temp = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"));

            var result = temp.RemoveAll(x => x.Id == id);

            File.WriteAllText($@"{_filePath}/{entity}/{DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json", JsonConvert.SerializeObject(result), Encoding.UTF8);

        }

        internal object RetreiveAll (string entity)
        {
            var temp = new List<dynamic>();

            if (!Directory.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/"))
            {
                throw new Exception("No data created today");
            }

            if (!File.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"))
            {
                throw new Exception("No data created today");
            }

            temp = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"));

            if (temp is null)
            {
                throw new Exception("Not found");
            }
            return temp;
        }

        internal string Retreive(string entity,int id)
        {
            var temp = new List<dynamic>();

            if (!Directory.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/"))
            {
                throw new Exception("No data created today");
            }

            if (!File.Exists($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"))
            {
                throw new Exception("No data created today");    
            }

            temp = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText($@"{ _filePath}/{entity}/{ DateTime.Now.Date.ToString("dd-MM-yyyy")}/data.json"));
           
            var result = temp.Find(x => x.caseId == id);
            if (result is null)
            {
                throw new Exception("Not found");
            }
            return JsonConvert.SerializeObject(result);
        }

        public void Dispose()
        {

        }
        public void Create(Object instance)
        {
            _files.Add(instance);
        }
    }
}