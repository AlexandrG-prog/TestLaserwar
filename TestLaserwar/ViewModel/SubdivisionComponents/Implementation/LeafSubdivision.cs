using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Interface;
using TestLaserwar.ViewModel.Employee;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.WindowManagers.Employee;

namespace TestLaserwar.ViewModel.SubdivisionComponents.Implementation
{
    /// <summary>
    /// Простое подразделение
    /// </summary>
    public class LeafSubdivision : SubdivisionComponent, INotifyPropertyChanged
    {
        private ICommand _editEmployeeCommand;
        private ICommand _addEmployeeCommand;
        private ICommand _deleteEmployeeCommand;

        private ObservableCollection<EmployeeItemViewModel> _employeeList = new ObservableCollection<EmployeeItemViewModel>();

        /// <summary>
        /// Список сотрудников у данного подразделения
        /// </summary>
        public ObservableCollection<EmployeeItemViewModel> EmployeeList
        {
            get { return _employeeList; }
            set
            {
                _employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private EmployeeItemViewModel _selectedEmployee;

        public EmployeeItemViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        public ICommand AddEmployee
        {
            get
            {
                return _addEmployeeCommand ?? (_addEmployeeCommand = new EmployeeCommand(x =>
                {
                    IWindowManager windowManager = new EmployeeAddManager();
                    windowManager.ShowWindow(this);
                }));

            }
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        public ICommand EditEmployee
        {
            get
            {
                return _editEmployeeCommand ?? (_editEmployeeCommand = new EmployeeCommand(x =>
                {
                    IWindowManager windowManager = new EmployeeEditManager();
                    windowManager.ShowWindow(this);
                }));
            }
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public ICommand DeleteEmployee
        {
            get
            {
                return _deleteEmployeeCommand ?? (_deleteEmployeeCommand = new EmployeeCommand(x =>
                {
                    IWindowManager windowManager = new EmployeeDeleteManager();
                    windowManager.ShowWindow(this);
                }));
            }
        }


        protected override void Draw()
        {
            _drawSubdivisionComponent.Draw(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
