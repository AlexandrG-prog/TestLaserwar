using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLaserwar.Interface
{
    /// <summary>
    /// Интерфейст управления окнами
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Открытие окна
        /// </summary>
        /// <param name="parameters">параметры</param>
        void ShowWindow(params object[] parameters);

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="parameters">параметры</param>
        void CloseWindow(params object[] parameters);
    }
}
