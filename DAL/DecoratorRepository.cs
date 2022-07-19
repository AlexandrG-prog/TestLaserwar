using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Общий класс декораторов репозитория
    /// </summary>
    /// <typeparam name="T">тип сущности</typeparam>
    public abstract class DecoratorRepository<T> : BaseRepository<T> where T : DbObject
    {
    }
}
