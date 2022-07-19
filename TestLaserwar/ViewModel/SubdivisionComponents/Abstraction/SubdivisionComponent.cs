using System;
using System.Windows;
using System.Windows.Input;
using TestLaserwar.CommandsView;
using TestLaserwar.Implementation;
using TestLaserwar.Interface;
using TestLaserwar.Model;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.WindowManagers.Subdivision;
using TestLaserwar.Windows.Subdivision;

namespace TestLaserwar.ViewModel.SubdivisionComponents.Abstraction
{
    /// <summary>
    /// Абстрактный класс элемента древовидной структуры подразделений
    /// </summary>
    public abstract class SubdivisionComponent
    {
        protected IDrawSubdivisionComponent _drawSubdivisionComponent;

        private ICommand _drawCommand;
        private ICommand _backCommand;

        private SubdivisionModel _subdivisionModel;
        private IWindowManager _windowManager;

        public SubdivisionComponent()
        {
            _drawSubdivisionComponent = new DrawSubdivisionComponent();//по умолчанию
            _subdivisionModel = new SubdivisionModel();
            _windowManager = new SubdivisionComponentManager<CompositeSubdivision, SubdivisionCompositeWindow>();

            _drawCommand = new SubdivisionCommand(x =>
            {
                Draw();
            });

            _backCommand = new SubdivisionCommand(x =>
            {
                if (this.ParentId.HasValue)
                {
                    var parent =
                        _subdivisionModel.FindSubdivisionComponentInCollection(new SubdivisionComponentCollection(),
                            this.ParentId.Value);
                    parent.Draw();
                }
                else
                    _windowManager.CloseWindow(this);
            });
        }

        /// <summary>
        /// Сеттер для установки способа отображения подразделения
        /// </summary>
        public IDrawSubdivisionComponent SetterDrawSubdivisionComponent
        {
            set { _drawSubdivisionComponent = value; }
        }

        /// <summary>
        /// Добавление элемента в структуру
        /// </summary>
        /// <param name="component">подразделение</param>
        public virtual void Add(SubdivisionComponent component)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление элемента из структуры
        /// </summary>
        /// <param name="component">подразделение</param>
        public virtual void Remove(SubdivisionComponent component)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Название подразделения
        /// </summary>
        public string SubdivisionName { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Id родительского подразделения
        /// </summary>
        public int? ParentId { get; set; }

        protected abstract void Draw();

        /// <summary>
        /// Отображение подразделения
        /// </summary>
        public ICommand DrawComponents
        {
            get
            {
                return _drawCommand;
            }
        }

        /// <summary>
        /// Вернуться на вышестоящее подразделение
        /// </summary>
        public ICommand Back
        {
            get
            {
                return _backCommand;
            }
        }
    }
}
