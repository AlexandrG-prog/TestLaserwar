using BLL.DataModel;
using BLL.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;

namespace TestLaserwar.Implementation
{
    public class SubdivisionComponentCollection : ISubdivisionComponentCollection
    {
        private SubdivisionService<SubdivisionDataModel> _subdivisionService;
        private EmployeeService<EmployeeDataModel> _employeeService;

        private EmployeeModel _employeeModel;

        public SubdivisionComponentCollection()
        {
            _subdivisionService = new SubdivisionService<SubdivisionDataModel>();
            _employeeService = new EmployeeService<EmployeeDataModel>();

            _employeeModel = new EmployeeModel();
        }

        public ObservableCollection<SubdivisionComponent> GetSubdivisionComponentCollection()
        {
            var subdivisionList = _subdivisionService.GetAll();
            var employeeList = _employeeService.GetAll();

            var result = new ObservableCollection<SubdivisionComponent>();

            var headSubdivisionList = subdivisionList.Where(x => x.ParentId is null).ToList();

            foreach (var headSubdivision in headSubdivisionList)
            {
                var component = RecursionAddComponent(headSubdivision, employeeList, subdivisionList);
                result.Add(component);
            }

            return result;
        }

        /// <summary>
        /// Рекурсивное добавление подразделений в структуру подразделений
        /// </summary>
        /// <param name="sourceItem">исходная модель подразделения</param>
        /// <param name="employeeList">список сотрудников</param>
        /// <param name="subdivisionList">список подразделений</param>
        /// <returns></returns>
        private SubdivisionComponent RecursionAddComponent(SubdivisionDataModel sourceItem, List<EmployeeDataModel> employeeList, List<SubdivisionDataModel> subdivisionList)
        {
            var employeeListForSubdivision = employeeList.Where(x => x.SubdivisionId == sourceItem.Id).ToList();

            if (employeeListForSubdivision.Count > 0)
            {
                var component = new LeafSubdivision();
                var employeeItemViewList = employeeListForSubdivision
                    .Select(x => _employeeModel.GetEmployeeItemViewModel(x)).ToList();

                foreach (var employee in employeeItemViewList)
                {
                    component.EmployeeList.Add(employee);
                }

                component.SubdivisionName = sourceItem.Name;
                component.Id = sourceItem.Id;

                if (component.Id == this.TargetFindId)
                    this.FindComponent = component;

                return component;
            }

            var childSubdivisionList =
                subdivisionList.Where(x => x.ParentId.HasValue && x.ParentId == sourceItem.Id).ToList();

            if (childSubdivisionList.Count > 0)
            {
                var component = new CompositeSubdivision();

                foreach (var child in childSubdivisionList)
                {
                    var childComponent = RecursionAddComponent(child, employeeList, subdivisionList);
                    childComponent.ParentId = sourceItem.Id;
                    component.Add(childComponent);
                }

                component.SubdivisionName = sourceItem.Name;
                component.Id = sourceItem.Id;

                if (component.Id == this.TargetFindId)
                    this.FindComponent = component;

                return component;
            }

            var emptyComponent = new EmptySubdivision();
            emptyComponent.SubdivisionName = sourceItem.Name;
            emptyComponent.Id = sourceItem.Id;

            if (emptyComponent.Id == this.TargetFindId)
                this.FindComponent = emptyComponent;

            return emptyComponent;
        }

        public SubdivisionComponent FindSubdivisionComponentInCollection(int targetId)
        {
            this.TargetFindId = targetId;
            this.GetSubdivisionComponentCollection();
            this.TargetFindId = 0;

            return FindComponent;
        }

        private SubdivisionComponent FindComponent { get; set; }
        private int TargetFindId { get; set; }
    }
}
