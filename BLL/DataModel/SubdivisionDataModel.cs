using BLL.Interface;
using DAL;

namespace BLL.DataModel
{
    /// <summary>
    /// dataModel подразделения
    /// </summary>
    public class SubdivisionDataModel : IFillEntity<Subdivision>
    {
        public int Id { get; set; }

        /// <summary>
        /// Id родительского подразделения
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        public void FillFromEntity(Subdivision entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.ParentId = entity.ParentId;
        }

        public Subdivision FillToEntity()
        {
            var item = new Subdivision()
            {
                Id = this.Id,
                Name = this.Name,
                ParentId = this.ParentId
            };

            return item;
        }
    }
}
