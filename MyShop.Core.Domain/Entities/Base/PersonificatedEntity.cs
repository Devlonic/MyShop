namespace MyShop.Core.Domain.Entities.Base {
    public abstract class PersonificatedEntity : BaseEntity {
        public Guid CreatorID { get; set; }
        public PersonificatedEntity() : base() {
        }
    }
}