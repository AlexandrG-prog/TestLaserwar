using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Interface;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;
using TestLaserwar.WindowManagers.Subdivision;

namespace TestLaserwar.ViewModel.SubdivisionComponents.Implementation
{
    /// <summary>
    /// Подразделение, которое еще не имеет дочерних подразделений и еще не имеет принадлежащих сотрудников
    /// </summary>
    public class EmptySubdivision : SubdivisionComponent
    {
        private ICommand _addSubdivisionCommand;
        private ICommand _addEmployeeCommand;

        protected override void Draw()
        {
            _drawSubdivisionComponent.Draw(this);
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
                    IWindowManager windowManager = new SubdivisionEmptyManager();
                    var viewModel = GetCompositeSubdivision();
                    windowManager.ShowWindow(viewModel);
                }));
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
                    IWindowManager windowManager = new SubdivisionEmptyManager();
                    var viewModel = GetLeafSubdivision();
                    windowManager.ShowWindow(viewModel);
                }));
            }
        }

        /// <summary>
        /// Создает и заполняет компонент сложного подразделения
        /// </summary>
        /// <returns></returns>
        private CompositeSubdivision GetCompositeSubdivision()
        {
            var result = new CompositeSubdivision()
            {
                Id = this.Id,
                ParentId = this.ParentId,
                SubdivisionName = this.SubdivisionName
            };

            return result;
        }

        /// <summary>
        /// Создает и заполняет компонент простого подразделения
        /// </summary>
        /// <returns></returns>
        private LeafSubdivision GetLeafSubdivision()
        {
            var result = new LeafSubdivision()
            {
                Id = this.Id,
                ParentId = this.ParentId,
                SubdivisionName = this.SubdivisionName
            };

            return result;
        }
    }
}
