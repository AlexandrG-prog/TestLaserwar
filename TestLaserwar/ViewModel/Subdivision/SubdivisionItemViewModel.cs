using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Interface;
using TestLaserwar.Model;

namespace TestLaserwar.ViewModel.Subdivision
{
    public class SubdivisionItemViewModel : INotifyPropertyChanged
    {
        private ICommand _editCommand;
        private IWindowManager _windowManager;

        private int _id;
        private int? _parentId;
        private string _name;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
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

        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                _parentId = value;
                OnPropertyChanged("ParentId");
            }
        }

        public SubdivisionItemViewModel()
        {
            _editCommand = new SubdivisionCommand(x =>
            {
                _windowManager.CloseWindow(this);
            });
        }

        /// <summary>
        /// Проверка корректности введенного имени подразделения
        /// </summary>
        /// <returns></returns>
        public bool ValidationName()
        {
            return !String.IsNullOrEmpty(this.Name);
        }

        public ICommand EditSubdivision
        {
            get
            {
                return _editCommand;
            }
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
