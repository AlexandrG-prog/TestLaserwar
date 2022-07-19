using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.UserControls;
using TestLaserwar.ViewModel.Employee;
using TestLaserwar.ViewModel.Subdivision;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.Windows.Employee;
using TestLaserwar.Windows.Subdivision;

namespace TestLaserwar.WindowManagers.Subdivision
{
    public class SubdivisionEmptyManager : IWindowManager
    {
        private SubdivisionComponent _subdivisionComponent;

        private SubdivisionAddWindow _subdivisionAddWindow;
        private SubdivisionItemViewModel _subdivisionItemViewModel;

        private SubdivisionModel _subdivisionModel;

        private EmployeeEditWindow _employeeEditWindow;
        private EmployeeItemViewModel _employeeItemViewModel;

        private EmployeeModel _employeeModel;

        public SubdivisionEmptyManager()
        {
            _subdivisionModel = new SubdivisionModel();
            _employeeModel = new EmployeeModel();
        }

        public void CloseWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            if (parameters[0].GetType() == typeof(SubdivisionItemViewModel))
            {
                _subdivisionItemViewModel = parameters[0] as SubdivisionItemViewModel;

                if (!_subdivisionItemViewModel.ValidationName())
                    return;

                _subdivisionItemViewModel.ParentId = _subdivisionComponent.Id;

                _subdivisionModel.Add(_subdivisionItemViewModel);

                //только что созданное подразделение будет пустым, еще не имеющем дочерних подразделений или сотрудников
                var emptySubdivision = _subdivisionModel.GetEmptySubdivision(_subdivisionItemViewModel);
                _subdivisionComponent.Add(emptySubdivision);

                var ownerWindow = _subdivisionAddWindow.Owner;

                _subdivisionAddWindow.Close();

                ownerWindow.Content = new SubdivisionCompositeUserControl();
                ownerWindow.DataContext = _subdivisionComponent;
            }

            if (parameters[0].GetType() == typeof(EmployeeItemViewModel))
            {
                _employeeItemViewModel = parameters[0] as EmployeeItemViewModel;

                if (!_employeeItemViewModel.ValidationName())
                    return;

                if (!_employeeItemViewModel.ValidationPhone())
                    return;

                if (!_employeeItemViewModel.ValidationPosition())
                    return;

                _employeeItemViewModel.SubdivisionId = _subdivisionComponent.Id;

                _employeeModel.EditEmployee(_employeeItemViewModel);

                _subdivisionComponent =
                    _subdivisionModel.FindSubdivisionComponentInCollection(new SubdivisionComponentCollection(),
                        _subdivisionComponent.Id);

                var ownerWindow = _employeeEditWindow.Owner;

                _employeeEditWindow.Close();

                ownerWindow.Content = new SubdivisionLeafUserControl();
                ownerWindow.DataContext = _subdivisionComponent;
            }
        }

        public void ShowWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            if (parameters[0].GetType() == typeof(CompositeSubdivision))
            {
                _subdivisionComponent = parameters[0] as CompositeSubdivision;

                _subdivisionAddWindow = new SubdivisionAddWindow();
                _subdivisionItemViewModel = new SubdivisionItemViewModel();

                _subdivisionAddWindow.Title = "Add subdivision";

                _subdivisionItemViewModel.SetterWindowManager = this;
                _subdivisionAddWindow.DataContext = _subdivisionItemViewModel;

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.IsActive)
                        _subdivisionAddWindow.Owner = window;
                }

                _subdivisionAddWindow.ShowDialog();
            }

            if (parameters[0].GetType() == typeof(LeafSubdivision))
            {
                _subdivisionComponent = parameters[0] as LeafSubdivision;

                _employeeEditWindow = new EmployeeEditWindow();
                _employeeItemViewModel = new EmployeeItemViewModel();

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
}
