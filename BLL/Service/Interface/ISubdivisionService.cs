using System;
using System.Collections.Generic;
using BLL.Interface;
using DAL;

namespace BLL.Service.Interface
{
    /// <summary>
    /// Интерфейс для CRUD операций с моделями данных подразделения
    /// </summary>
    /// <typeparam name="T">dataModel</typeparam>
    public interface ISubdivisionService<T> where T : IFillEntity<Subdivision>
    {
        int Add(T dataModel);
        void Edit(T dataModel);
        void Delete(int id);
        T Get(int id);
        List<T> GetAll();
    }
}
