using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Интерфейс взаимодействия с различными контекстами бд, ORM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDbBase<T> where T : DbObject
    {
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity"></param>
        void Edit(T entity);

        /// <summary>
        /// Удаление сущности оп id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Получение сущности по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
    }
}
