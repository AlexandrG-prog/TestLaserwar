using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLaserwar.ViewModel.SubdivisionComponents.Abstraction;

namespace TestLaserwar.Interface
{
    /// <summary>
    /// Интерфейс операций над структурой подразделений
    /// </summary>
    public interface ISubdivisionComponentCollection
    {
        /// <summary>
        /// Получить коллекцию подразделений
        /// </summary>
        /// <returns></returns>
        ObservableCollection<SubdivisionComponent> GetSubdivisionComponentCollection();

        /// <summary>
        /// Поиск подраздерения в коллекции
        /// </summary>
        /// <param name="targetId">id искомого подразделения</param>
        /// <returns></returns>
        SubdivisionComponent FindSubdivisionComponentInCollection(int targetId);
    }
}
