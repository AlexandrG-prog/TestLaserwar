using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbBase
{
    /// <summary>
    /// Класс работы с MSSQL, Entity Framework
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MSSqlEf<T> : IDbBase<T> where T : DbObject
    {
        private static object _lock = new object();

        public int Add(T entity)
        {
            lock (_lock)
            {
                using (var laserwarEntities = new LaserwarEntities())
                {
                    var table = GetTableData(laserwarEntities);
                    table.Add(entity);
                    laserwarEntities.SaveChanges();
                }

                return entity.Id;
            }
        }

        public void Delete(int id)
        {
            lock (_lock)
            {
                using (var laserwarEntities = new LaserwarEntities())
                {
                    var table = GetTableData(laserwarEntities);
                    var item = table.Find(id);

                    if (item != null)
                    {
                        table.Remove(item);
                        laserwarEntities.SaveChanges();
                    }
                }
            }
        }

        public void Edit(T entity)
        {
            lock (_lock)
            {
                using (var laserwarEntities = new LaserwarEntities())
                {
                    var item = GetTableData(laserwarEntities).AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);

                    if (item != null)
                    {
                        laserwarEntities.Entry(entity).State = EntityState.Modified;
                        laserwarEntities.SaveChanges();
                    }
                }
            }
        }

        public T Get(int id)
        {
            lock (_lock)
            {
                using (var laserwarEntities = new LaserwarEntities())
                {
                    var item = GetTableData(laserwarEntities).Find(id);

                    return item;
                }
            }
        }

        public List<T> GetAll()
        {
            lock (_lock)
            {
                using (var laserwarEntities = new LaserwarEntities())
                {
                    var list = GetTableData(laserwarEntities);

                    return list.ToList();
                }
            }
        }

        private DbSet<T> GetTableData(LaserwarEntities laserwarEntities)
        {
            var type = laserwarEntities.GetType();

            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType == typeof(DbSet<T>))
                {
                    var result = prop.GetValue(laserwarEntities) as DbSet<T>;

                    return result;
                }
            }

            return null;
        }
    }
}
