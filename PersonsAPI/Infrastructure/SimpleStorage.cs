using System.IO;
using Newtonsoft.Json;
using Persistence;

namespace PersonsAPI.Infrastructure
{
    public class SimpleStorage : IStorage
    {
        private readonly string _fileName;

        public SimpleStorage(string filename)
        {
            _fileName = filename;
        }

        public void Add<T>(T entity) where T : class
        {
            using (StreamWriter writer = new StreamWriter(_fileName, false))
            {
                writer.WriteLine(JsonConvert.SerializeObject(entity));
            }
        }
    }
}