using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BLL.Common.Enum;
using TestLaserwar.CommandsView;
using TestLaserwar.Interface;
using TestLaserwar.Model;

namespace TestLaserwar.ViewModel.Employee
{
    public class EmployeeItemViewModel : INotifyPropertyChanged
    {
        private EmployeeModel _employeeModel;
        private IWindowManager _windowManager;

        private ICommand _editCommand;
        private ICommand _deleteCommand;

        private int _id { get; set; }
        private int _subdivisionId { get; set; }
        private string _name { get; set; }
        private EmployeePositionEnum _position { get; set; }
        private string _phone { get; set; }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public int SubdivisionId
        {
            get { return _subdivisionId; }
            set
            {
                _subdivisionId = value;
                OnPropertyChanged("SubdivisionId");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public EmployeePositionEnum Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public EmployeeItemViewModel()
        {
            _employeeModel = new EmployeeModel();

            _editCommand = new EmployeeCommand(x =>
            {
                _windowManager.CloseWindow(this);
            });

            _deleteCommand = new EmployeeCommand(x =>
            {
                _windowManager.CloseWindow(this);
            });
        }

        public ICommand EditEmployee
        {
            get
            {
                return _editCommand;
            }
        }

        public ICommand DeleteEmployee
        {
            get
            {
                return _deleteCommand;
            }
        }

        /// <summary>
        /// Проверка корректности введенного имени сотрудника
        /// </summary>
        /// <returns></returns>
        public bool ValidationName()
        {
            return !String.IsNullOrEmpty(this.Name);
        }

        /// <summary>
        /// Проверка корректности введенного телефона сотрудника
        /// </summary>
        /// <returns></returns>
        public bool ValidationPhone()
        {
            return !String.IsNullOrEmpty(this.Phone);
        }

        /// <summary>
        /// Проверка корректности выбранной должности
        /// </summary>
        /// <returns></returns>
        public bool ValidationPosition()
        {
            return !((int)this.Position == 0);
        }

        /// <summary>
        /// Установить реализацию менеджера окон
        /// </summary>
        public IWindowManager SetterWindowManager
        {
            set { _windowManager = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
