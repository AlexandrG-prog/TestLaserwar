using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common.Enum
{
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public enum EmployeePositionEnum
    {
        /// <summary>
        /// Менеджер отдела
        /// </summary>
        DeptManager = 1,

        /// <summary>
        /// Менеджер
        /// </summary>
        Manager = 2,

        /// <summary>
        /// Оператор
        /// </summary>
        Operator = 3
    }
}
