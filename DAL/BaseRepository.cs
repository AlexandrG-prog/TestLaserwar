using DAL.DbBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    /// <typeparam name="T">класс сущности</typeparam>
    public abstract class BaseRepository<T> where T : DbObject
    {
        private IDbBase<T> _dbBase;

        public BaseRepository()
        {
            _dbBase = new MSSqlEf<T>();//По умолчанию
        }

        /// <summary>
        /// Сеттер для динамического изменения класса работы с бд
        /// </summary>
        public IDbBase<T> SetterDbBase
        {
            set { _dbBase = value; }
        }

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            _dbBase.Add(entity);
            return entity.Id;
        }

        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity)
        {
            _dbBase.Edit(entity);
        }

        /// <summary>
        /// Удаление сущности оп id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            _dbBase.Delete(id);
        }

        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            var resultList = _dbBase.GetAll();
            return resultList;
        }

        /// <summary>
        /// Получение сущности по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            var item = _dbBase.Get(id);
            return item;
        }
    }
}
