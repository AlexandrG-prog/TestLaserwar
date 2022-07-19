using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel.Employee;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.Windows.Employee;

namespace TestLaserwar.WindowManagers.Employee
{
    public class EmployeeAddManager : IWindowManager
    {
        private EmployeeEditWindow _employeeEditWindow;
        private EmployeeItemViewModel _employeeItemViewModel;

        private LeafSubdivision _subdivisionComponent;

        private EmployeeModel _employeeModel;

        public EmployeeAddManager()
        {
            _employeeModel = new EmployeeModel();
        }

        public void CloseWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            _employeeItemViewModel = parameters[0] as EmployeeItemViewModel;

            if (!_employeeItemViewModel.ValidationName())
                return;

            if (!_employeeItemViewModel.ValidationPhone())
                return;

            if (!_employeeItemViewModel.ValidationPosition())
                return;

            _employeeModel.EditEmployee(_employeeItemViewModel);

            _subdivisionComponent.EmployeeList.Add(_employeeItemViewModel);

            _employeeEditWindow.Close();
        }

        public void ShowWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            _subdivisionComponent = parameters[0] as LeafSubdivision;

            _employeeEditWindow = new EmployeeEditWindow();
            _employeeItemViewModel = new EmployeeItemViewModel() { SubdivisionId = _subdivisionComponent.Id };

            _employeeEditWindow.Title = "Add employee";

            _employeeItemViewModel.SetterWindowManager = this;
            _employeeEditWindow.DataContext = _employeeItemViewModel;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                    _employeeEditWindow.Owner = window;
            }

            _employeeEditWindow.ShowDialog();
        }
    }
}
