using System;
using System.Collections.Generic;
using BLL.Interface;
using DAL;

namespace BLL.Service.Interface
{
    /// <summary>
    /// Интерфейс для CRUD операций с моделями данных сотрудника
    /// </summary>
    /// <typeparam name="T">dataModel</typeparam>
    public interface IEmployeeService<T> where T : IFillEntity<Employee>
    {
        int Add(T dataModel);
        void Edit(T dataModel);
        void Delete(int id);
        T Get(int id);
        List<T> GetAll();
    }
}
