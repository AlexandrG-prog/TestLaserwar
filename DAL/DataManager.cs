using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Decorators;
using DAL.Repositories;

namespace DAL
{
    /// <summary>
    /// Класс доступа к репозиториям
    /// </summary>
    public class DataManager
    {
        private BaseRepository<Employee> _employeeRepository;
        public BaseRepository<Employee> EmployeeRepository =>
            _employeeRepository ?? (_employeeRepository = new CacheToRepository<Employee>(new EmployeeRepository()));

        private BaseRepository<Subdivision> _subdivisionRepository;
        public BaseRepository<Subdivision> SubdivisionRepository =>
            _subdivisionRepository ??
            (_subdivisionRepository = new CacheToRepository<Subdivision>(new SubdivisionRepository()));
    }
}
