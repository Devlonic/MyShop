namespace MyShop.Core.Domain.Entities.Base {
    public abstract class BaseEntity : IEntity {
        public Guid Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }

        public BaseEntity() {
            Id = Guid.NewGuid();
            DateCreate = DateTime.Now;
            DateEdit = null;
        }
    }
}