namespace MyShop.Core.Domain.Entities.Base {
    public interface IEntity {
        public Guid Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }
    }
}