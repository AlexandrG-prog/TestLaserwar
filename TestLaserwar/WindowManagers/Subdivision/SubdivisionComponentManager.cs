using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;

namespace TestLaserwar.WindowManagers.Subdivision
{
    /// <summary>
    /// Класс взаимодействия компонентов структуры подразделений с окнами
    /// </summary>
    /// <typeparam name="T">компонент</typeparam>
    /// <typeparam name="W">окно</typeparam>
    public class SubdivisionComponentManager<T, W> : IWindowManager where T : SubdivisionComponent where W : Window, new()
    {
        private Window _window;
        private SubdivisionModel _subdivisionModel;

        public SubdivisionComponentManager()
        {
            _subdivisionModel = new SubdivisionModel();
        }

        public void CloseWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.Owner != null)
                {
                    _window = window.Owner;
                    window.Close();
                }
            }

            _window.Activate();
            _window.DataContext = new MainWindowViewModel();

        }

        public void ShowWindow(params object[] parameters)
        {
            if (parameters.Length != 1)
                return;

            var viewModel = parameters[0] as T;

            _window = new W();
            _window.DataContext = viewModel;

            Window owner = null;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                {
                    owner = window;

                    while (owner.Owner != null)
                        owner = owner.Owner;
                }
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.Owner != null)
                    window.Close();
            }

            _window.Owner = owner;

            _window.Left = _window.Owner.Left;
            _window.Top = _window.Owner.Top;
            _window.Show();
        }
    }
}
