using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Класс работы с кэшем
    /// </summary>
    public class Cache<T> where T : DbObject
    {
        private Cache()
        {
            _data = new Dictionary<int, T>();
        }

        private static Cache<T> _instance;
        private static object _lock = new object();

        public static Cache<T> GetInstance()
        {
            lock (_lock)
            {
                if (_instance is null)
                    _instance = new Cache<T>();

                return _instance;
            }
        }

        private Dictionary<int, T> _data;

        /// <summary>
        /// Кэш данных
        /// </summary>
        public Dictionary<int, T> Data => _data;

        /// <summary>
        /// Обновление кэша
        /// </summary>
        public void ReNew(List<T> source)
        {
            lock (_lock)
            {
                if (source is null)
                    return;

                _data.Clear();

                foreach (var item in source)
                {
                    _data.Add(item.Id, item);
                }
            }
        }

        /// <summary>
        /// Добавление элемента в кэш
        /// </summary>
        /// <param name="obj"></param>
        public void AddInCache(T obj)
        {
            lock (_lock)
            {
                if (!this._data.ContainsKey(obj.Id))
                    this._data.Add(obj.Id, obj);
            }
        }

        /// <summary>
        /// Редактирование элемента в кэше
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void EditInCache(T obj)
        {
            lock (_lock)
            {
                if (this._data.ContainsKey(obj.Id))
                {
                    this._data.Remove(obj.Id);
                    this._data.Add(obj.Id, obj);
                }
            }
        }

        /// <summary>
        /// Удаление элемента из кэша
        /// </summary>
        /// <param name="id"></param>
        public void DeleteInCache(int id)
        {
            lock (_lock)
            {
                if (this._data.ContainsKey(id))
                    this._data.Remove(id);
            }
        }

        /// <summary>
        /// Возвращает сущность из кэша
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetInCache(int id)
        {
            lock (_lock)
            {
                if (this._data.ContainsKey(id))
                {
                    return this._data[id];
                }

                return null;
            }
        }

        /// <summary>
        /// Возвращает список сущностей таблицы из кэша
        /// </summary>
        /// <returns></returns>
        public List<T> GetTableInCache()
        {
            lock (_lock)
            {
                return this._data.Values.ToList();
            }
        }
    }
}
