﻿using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> 
    {
        TSource Create(TSource source);
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        IEnumerable<TSource> GetAll();
        bool Delete(int id);
        void ShowInfo(TSource source);
    }
}
