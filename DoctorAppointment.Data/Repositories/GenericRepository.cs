using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using System.Numerics;
using System.Xml.Serialization;

namespace DoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }
        public TSource CreateToJson(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Newtonsoft.Json.Formatting.Indented));
            SaveLastId();
            return source;
        }
        public TSource CreateToXml(TSource source, string path)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            List<TSource>? sources = null;
            XmlSerializer formatter = new XmlSerializer(typeof(List<TSource>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    sources = formatter.Deserialize(fs) as List<TSource>;

                    if (sources != null)
                    {
                        sources.Add(source);
                    }
                }
                else
                {
                    sources = new List<TSource> { source };
                }
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, sources);
            }
            return source;
        }
        public List<TSource> GetFromXml(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<TSource>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<TSource>? sources = formatter.Deserialize(fs) as List<TSource>;
                return sources;
            }

        }
        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Newtonsoft.Json.Formatting.Indented));
            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var json = File.ReadAllText(Path);
            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<TSource>>(json)!;
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        public abstract void ShowInfo(TSource source);
        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Newtonsoft.Json.Formatting.Indented));
            return source;
        }
        protected abstract void SaveLastId();
        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));

    }
}
