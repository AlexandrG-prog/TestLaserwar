using System.Windows;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel;
using TestLaserwar.ViewModel.Subdivision;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.Windows;
using TestLaserwar.Windows.Subdivision;

namespace TestLaserwar.WindowManagers.Subdivision
{
    /// <summary>
    /// Класс для работы с окном добавления подразделения
    /// </summary>
    public class SubdivisionAddManager : IWindowManager
    {
        private MainWindowViewModel _mainWindowViewModel;

        private SubdivisionComponent _subdivisionComponent;

        private SubdivisionAddWindow _subdivisionAddWindow;
        private SubdivisionItemViewModel _subdivisionItemViewModel;

        private SubdivisionModel _subdivisionModel;

        public SubdivisionAddManager()
        {
            _subdivisionModel = new SubdivisionModel();
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        /// <param name="parameters">параметры</param>
        public void CloseWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            _subdivisionItemViewModel = parameters[0] as SubdivisionItemViewModel;

            if (!_subdivisionItemViewModel.ValidationName())
                return;

            _subdivisionItemViewModel.ParentId = _subdivisionComponent is null ? null : _subdivisionComponent?.Id;

            _subdivisionModel.Add(_subdivisionItemViewModel);

            if (_subdivisionComponent != null)
            {
                var emptySubdivision = _subdivisionModel.GetEmptySubdivision(_subdivisionItemViewModel);
                _subdivisionComponent.Add(emptySubdivision);
            }
            else
                _mainWindowViewModel.SubdivisionComponents = _subdivisionModel.GetSubdivisionComponentCollection(new SubdivisionComponentCollection());

            _subdivisionAddWindow.Close();
        }

        /// <summary>
        /// Открыть окно
        /// </summary>
        /// <param name="parameters">параметры</param>
        public void ShowWindow(params object[] parameters)
        {
            if (parameters.Length == 0)
                return;

            if (parameters[0].GetType() == typeof(MainWindowViewModel))
                _mainWindowViewModel = parameters[0] as MainWindowViewModel;

            if (parameters[0].GetType() == typeof(CompositeSubdivision))
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
    }
}
