using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.WindowManagers.Subdivision;
using System.Windows;

namespace TestLaserwar.ViewModel
{
    /// <summary>
    /// View model главного окна
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _addSubdivisionCommand;

        private SubdivisionModel _subdivisionModel;
        private EmployeeModel _employeeModel;

        public MainWindowViewModel()
        {
            _subdivisionModel = new SubdivisionModel();
            _employeeModel = new EmployeeModel();

            SubdivisionComponents = _subdivisionModel.GetSubdivisionComponentCollection(new SubdivisionComponentCollection());
        }

        public ICommand AddSubdivision
        {
            get
            {
                return _addSubdivisionCommand ?? (_addSubdivisionCommand = new SubdivisionCommand(x =>
                {
                    IWindowManager windowManager = new SubdivisionAddManager();
                    windowManager.ShowWindow(this);
                }));
            }
        }

        private ObservableCollection<SubdivisionComponent> _subdivisionComponents;
        public ObservableCollection<SubdivisionComponent> SubdivisionComponents
        {
            get { return _subdivisionComponents; }
            set
            {
                _subdivisionComponents = value;
                OnPropertyChanged("SubdivisionComponents");
            }
        }


        private SubdivisionComponent _selectedSubdivision { get; set; }

        public SubdivisionComponent SelectedSubdivision
        {
            get { return _selectedSubdivision; }
            set
            {
                _selectedSubdivision = value;
                OnPropertyChanged("SelectedSubdivision");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
