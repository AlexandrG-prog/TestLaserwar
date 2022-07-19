using System;
using BLL.Common.Enum;
using BLL.Interface;
using DAL;

namespace BLL.DataModel
{
    /// <summary>
    /// data model сотрудника
    /// </summary>
    public class EmployeeDataModel : IFillEntity<Employee>
    {
        public int Id { get; set; }

        /// <summary>
        /// Id подразделения, в котором числится сотрудник
        /// </summary>
        public int SubdivisionId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public EmployeePositionEnum Position { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Получить заполненную сущность
        /// </summary>
        /// <returns></returns>
        public Employee FillToEntity()
        {
            var item = new Employee()
            {
                Id = this.Id,
                Name = this.Name,
                Phone = this.Phone,
                Position = (int)this.Position,
                SubdivisionId = this.SubdivisionId
            };

            return item;
        }

        /// <summary>
        /// Заполнить data model
        /// </summary>
        /// <param name="entity">сущность</param>
        public void FillFromEntity(Employee entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Phone = entity.Phone;
            this.SubdivisionId = entity.SubdivisionId;
            this.Position = (EmployeePositionEnum)entity.Position;
        }
    }
}
