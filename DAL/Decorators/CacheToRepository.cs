using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Decorators
{
    /// <summary>
    /// Декоратор кэширования данных при работе с базой
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheToRepository<T> : DecoratorRepository<T> where T : DbObject
    {
        private readonly BaseRepository<T> _baseRepository;
        private readonly Cache<T> _cache;

        private static object _lock = new object();

        public CacheToRepository(BaseRepository<T> repository)
        {
            _baseRepository = repository;
            _cache = Cache<T>.GetInstance();
            _cache.ReNew(repository.GetAll());
        }

        public override int Add(T entity)
        {
            lock (_lock)
            {
                var itemId = _baseRepository.Add(entity);

                if (itemId > 0)
                    _cache.AddInCache(entity);

                return itemId;
            }
        }

        public override void Delete(int id)
        {
            lock (_lock)
            {
                _baseRepository.Delete(id);
                _cache.DeleteInCache(id);
            }
        }

        public override void Edit(T entity)
        {
            lock (_lock)
            {
                _baseRepository.Edit(entity);
                _cache.EditInCache(entity);
            }
        }

        public override T Get(int id)
        {
            return _cache.GetInCache(id);
        }

        public override List<T> GetAll()
        {
            return _cache.GetTableInCache();
        }
    }
}
