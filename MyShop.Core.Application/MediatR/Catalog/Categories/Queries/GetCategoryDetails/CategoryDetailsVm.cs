using AutoMapper;
using MyShop.Core.Application.Common.Mappings;
using MyShop.Core.Domain.Entities.Catalog;

namespace MyShop.Core.Application.MediatR.Catalog.Categories.Queries.GetCategoryDetails {
    public class CategoryDetailsVm : IMapWith<Category> {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Category, CategoryDetailsVm>()
                .ForMember(vm => vm.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(vm => vm.Details, opt => opt.MapFrom(c => c.Details))
                .ForMember(vm => vm.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(vm => vm.DateCreate, opt => opt.MapFrom(c => c.DateCreate))
                .ForMember(vm => vm.DateEdit, opt => opt.MapFrom(c => c.DateEdit));
        }
    }
}