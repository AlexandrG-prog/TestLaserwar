using BLL.DataModel;
using BLL.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLaserwar.ViewModel;
using TestLaserwar.ViewModel.Employee;

namespace TestLaserwar.Model
{
    public class EmployeeModel
    {
        private EmployeeService<EmployeeDataModel> _employeeService;

        public EmployeeModel()
        {
            _employeeService = new EmployeeService<EmployeeDataModel>();
        }

        /// <summary>
        /// Редактирование/добавление сотрудника
        /// </summary>
        /// <param name="itemViewModel"></param>
        public void EditEmployee(EmployeeItemViewModel itemViewModel)
        {
            var dataModel = new EmployeeDataModel()
            {
                Id = itemViewModel.Id,
                SubdivisionId = itemViewModel.SubdivisionId,
                Position = itemViewModel.Position,
                Phone = itemViewModel.Phone,
                Name = itemViewModel.Name
            };

            if (dataModel.Id > 0)
                _employeeService.Edit(dataModel);
            else
                itemViewModel.Id = _employeeService.Add(dataModel);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            _employeeService.Delete(id);
        }

        /// <summary>
        /// Получить список сотрудников в подразделении
        /// </summary>
        /// <param name="subdivisionId">id подразделения</param>
        /// <returns></returns>
        public ObservableCollection<EmployeeItemViewModel> GetEmployeeCollectionBySubdivision(int subdivisionId)
        {
            var result = new ObservableCollection<EmployeeItemViewModel>();
            var employeeList = _employeeService.GetAll().Where(x => x.SubdivisionId == subdivisionId).ToList();

            foreach (var employee in employeeList)
            {
                var employeeViewModel = new EmployeeItemViewModel()
                {
                    Id = employee.Id,
                    SubdivisionId = employee.SubdivisionId,
                    Phone = employee.Phone,
                    Position = employee.Position,
                    Name = employee.Name
                };

                result.Add(employeeViewModel);
            }

            return result;
        }

        /// <summary>
        /// Возвращает viewModel сотрудника
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public EmployeeItemViewModel GetEmployeeItemViewModel(EmployeeDataModel dataModel)
        {
            var item = new EmployeeItemViewModel()
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                SubdivisionId = dataModel.SubdivisionId,
                Phone = dataModel.Phone,
                Position = dataModel.Position
            };

            return item;
        }
    }
}
