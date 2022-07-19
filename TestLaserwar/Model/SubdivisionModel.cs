using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.DataModel;
using BLL.Service.Implementation;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.ViewModel.Subdivision;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;

namespace TestLaserwar.Model
{
    public class SubdivisionModel
    {
        private SubdivisionService<SubdivisionDataModel> _subdivisionService;
        private EmployeeService<EmployeeDataModel> _employeeService;

        private EmployeeModel _employeeModel;

        public SubdivisionModel()
        {
            _subdivisionService = new SubdivisionService<SubdivisionDataModel>();
            _employeeService = new EmployeeService<EmployeeDataModel>();

            _employeeModel = new EmployeeModel();
        }

        /// <summary>
        /// Получить коллекцию подразделений
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SubdivisionComponent> GetSubdivisionComponentCollection(
            ISubdivisionComponentCollection subdivisionComponentCollection)
        {
            var result = subdivisionComponentCollection.GetSubdivisionComponentCollection();

            return result;
        }

        /// <summary>
        ///  Получить пустое подразделение, которое еще не имеет дочерних подразделений и еще не имеет принадлежащих сотрудников
        /// </summary>
        /// <param name="subdivisionItemViewModel">viewModel</param>
        /// <returns></returns>
        public SubdivisionComponent GetEmptySubdivision(SubdivisionItemViewModel subdivisionItemViewModel)
        {
            var result = new EmptySubdivision()
            {
                Id = subdivisionItemViewModel.Id,
                ParentId = subdivisionItemViewModel.ParentId,
                SubdivisionName = subdivisionItemViewModel.Name
            };

            return result;
        }

        /// <summary>
        /// Добавление подразделения
        /// </summary>
        /// <param name="itemModel"></param>
        public void Add(SubdivisionItemViewModel itemModel)
        {
            var dataModel = new SubdivisionDataModel()
            {
                ParentId = itemModel.ParentId,
                Id = itemModel.Id,
                Name = itemModel.Name
            };

            itemModel.Id = _subdivisionService.Add(dataModel);
        }

        public SubdivisionComponent FindSubdivisionComponentInCollection(ISubdivisionComponentCollection subdivisionComponentCollection, int targetId)
        {
            var result = subdivisionComponentCollection.FindSubdivisionComponentInCollection(targetId);

            return result;
        }
    }
}
