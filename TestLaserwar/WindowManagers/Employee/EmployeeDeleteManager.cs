using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel.Employee;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.Windows.Employee;

namespace TestLaserwar.WindowManagers.Employee
{
    public class EmployeeDeleteManager : IWindowManager
    {
        private EmployeeDeleteWindow _employeeDeleteWindow;
        private EmployeeItemViewModel _employeeItemViewModel;

        private LeafSubdivision _subdivisionComponent;

        private EmployeeModel _employeeModel;

        public EmployeeDeleteManager()
        {
            _employeeModel = new EmployeeModel();
        }

        public void CloseWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            _employeeItemViewModel = parameters[0] as EmployeeItemViewModel;

            _employeeModel.DeleteEmployee(_employeeItemViewModel.Id);

            _subdivisionComponent.EmployeeList = _employeeModel.GetEmployeeCollectionBySubdivision(_subdivisionComponent.Id);

            _employeeDeleteWindow.Close();
        }

        public void ShowWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            _subdivisionComponent = parameters[0] as LeafSubdivision;

            _employeeDeleteWindow = new EmployeeDeleteWindow();
            _employeeItemViewModel = _subdivisionComponent.SelectedEmployee;

            _employeeDeleteWindow.Title = "Remove employee";

            _employeeItemViewModel.SetterWindowManager = this;
            _employeeDeleteWindow.DataContext = _employeeItemViewModel;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                    _employeeDeleteWindow.Owner = window;
            }

            _employeeDeleteWindow.ShowDialog();
        }
    }
}
