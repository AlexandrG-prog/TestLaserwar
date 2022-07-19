using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Service.Interface;
using DAL;

namespace BLL.Service.Implementation
{
    public class EmployeeService<T> : IEmployeeService<T> where T : IFillEntity<Employee>, new()
    {
        private DataManager _dataManager;

        public EmployeeService()
        {
            _dataManager = new DataManager();
        }

        public int Add(T dataModel)
        {
            var entity = dataModel.FillToEntity();
            var id = _dataManager.EmployeeRepository.Add(entity);

            return id;
        }

        public void Delete(int id)
        {
            _dataManager.EmployeeRepository.Delete(id);
        }

        public void Edit(T dataModel)
        {
            var entity = dataModel.FillToEntity();
            _dataManager.EmployeeRepository.Edit(entity);
        }

        public T Get(int id)
        {
            var item = _dataManager.EmployeeRepository.Get(id);
            var dataModel = new T();
            dataModel.FillFromEntity(item);
            return dataModel;
        }

        public List<T> GetAll()
        {
            var entityList = _dataManager.EmployeeRepository.GetAll();
            var dataModelList = entityList.Select(x =>
            {
                var dataModel = new T();
                dataModel.FillFromEntity(x);

                return dataModel;
            }).ToList();

            return dataModelList;
        }
    }
}
