using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Interface
{
    /// <summary>
    /// Интерфейс заполнения сущности
    /// </summary>
    /// <typeparam name="T">сущность</typeparam>
    public interface IFillEntity<T> where T : DbObject, new()
    {
        /// <summary>
        /// Получить заполненную сущность
        /// </summary>
        T FillToEntity();

        /// <summary>
        /// Заполнить data model
        /// </summary>
        /// <param name="entity">сущность</param>
        void FillFromEntity(T entity);
    }
}
