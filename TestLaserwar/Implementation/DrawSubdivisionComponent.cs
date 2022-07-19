using System;
using TestLaserwar.Interface;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;
using TestLaserwar.WindowManagers.Subdivision;
using TestLaserwar.Windows.Subdivision;

namespace TestLaserwar.Implementation
{
    public class DrawSubdivisionComponent : IDrawSubdivisionComponent
    {
        private IWindowManager _compositeWindowManager;
        private IWindowManager _leafWindowManager;
        private IWindowManager _emptyWindowManager;

        public DrawSubdivisionComponent()
        {
            _compositeWindowManager = new SubdivisionComponentManager<CompositeSubdivision, SubdivisionCompositeWindow>();
            _emptyWindowManager = new SubdivisionComponentManager<EmptySubdivision, SubdivisionEmptyWindow>();
            _leafWindowManager = new SubdivisionComponentManager<LeafSubdivision, SubdivisionLeafWindow>();
        }

        public void Draw(CompositeSubdivision subdivision)
        {
            _compositeWindowManager.ShowWindow(subdivision);
        }

        public void Draw(LeafSubdivision subdivision)
        {
            _leafWindowManager.ShowWindow(subdivision);
        }

        public void Draw(EmptySubdivision subdivision)
        {
            _emptyWindowManager.ShowWindow(subdivision);
        }
    }
}
