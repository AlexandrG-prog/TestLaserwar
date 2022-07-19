using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Interface;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.WindowManagers.Subdivision;

namespace TestLaserwar.ViewModel.SubdivisionComponents.Implementation
{
    /// <summary>
    /// Сложное подразделение, содержащее дочерние подразделения
    /// </summary>
    public class CompositeSubdivision : SubdivisionComponent, INotifyPropertyChanged
    {
        private ICommand _addSubdivisionCommand;
        private ObservableCollection<SubdivisionComponent> _subdivisionComponents = new ObservableCollection<SubdivisionComponent>();

        /// <summary>
        /// Дочерние подразделения
        /// </summary>
        public ObservableCollection<SubdivisionComponent> ChildList
        {
            get { return _subdivisionComponents; }
            set
            {
                _subdivisionComponents = value;
                OnPropertyChanged("ChildList");
            }
        }


        public override void Add(SubdivisionComponent component)
        {
            this.ChildList.Add(component);
        }

        public override void Remove(SubdivisionComponent component)
        {
            this.ChildList.Remove(component);
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

        /// <summary>
        /// Добавление подразделения
        /// </summary>
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
    }
}
