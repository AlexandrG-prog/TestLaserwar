using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLaserwar.Implementation;
using TestLaserwar.ViewModel.SubdivisionComponents.Implementation;

namespace TestLaserwar.Interface
{
    /// <summary>
    /// Интерфейс для отображения подразделений
    /// </summary>
    public interface IDrawSubdivisionComponent
    {
        /// <summary>
        /// Составное подразделение
        /// </summary>
        /// <param name="subdivision"></param>
        void Draw(CompositeSubdivision subdivision);

        /// <summary>
        /// Простое подразделение
        /// </summary>
        /// <param name="subdivision"></param>
        void Draw(LeafSubdivision subdivision);

        /// <summary>
        /// Подразделение, которое еще не имеет дочерних подразделений и еще не имеет принадлежащих сотрудников
        /// </summary>
        /// <param name="subdivision"></param>
        void Draw(EmptySubdivision subdivision);
    }
}
