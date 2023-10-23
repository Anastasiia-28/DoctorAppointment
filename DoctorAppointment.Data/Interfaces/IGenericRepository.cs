using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> 
    {
        TSource CreateToJson(TSource source);
        TSource CreateToXml(TSource source, string path);
        List<TSource> GetFromXml(string path);
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        IEnumerable<TSource> GetAll();
        bool Delete(int id);
        void ShowInfo(TSource source);
    }
}
