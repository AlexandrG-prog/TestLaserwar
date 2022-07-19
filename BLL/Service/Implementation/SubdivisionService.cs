using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Service.Interface;
using DAL;

namespace BLL.Service.Implementation
{
    public class SubdivisionService<T> : ISubdivisionService<T> where T : IFillEntity<Subdivision>, new()
    {
        private DataManager _dataManager;

        public SubdivisionService()
        {
            _dataManager = new DataManager();
        }

        public int Add(T dataModel)
        {
            var entity = dataModel.FillToEntity();
            var id = _dataManager.SubdivisionRepository.Add(entity);

            return id;
        }

        public void Delete(int id)
        {
            _dataManager.SubdivisionRepository.Delete(id);
        }

        public void Edit(T dataModel)
        {
            var entity = dataModel.FillToEntity();
            _dataManager.SubdivisionRepository.Edit(entity);
        }

        public T Get(int id)
        {
            var item = _dataManager.SubdivisionRepository.Get(id);
            var dataModel = new T();
            dataModel.FillFromEntity(item);
            return dataModel;
        }

        public List<T> GetAll()
        {
            var entityList = _dataManager.SubdivisionRepository.GetAll();
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
