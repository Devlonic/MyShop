using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Application.Common.Exceptions;
using MyShop.Core.Application.Interfaces;
using MyShop.Core.Domain.Entities.Catalog;

namespace MyShop.Core.Application.MediatR.Catalog.Categories.Queries.GetCategoryDetails {
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsVm> {
        private readonly ICategoriesDbContext _categoriesDbContext;
        private readonly IMapper _mapper;

        public GetCategoryDetailsQueryHandler(ICategoriesDbContext categoriesDbContext, IMapper mapper) {
            this._categoriesDbContext = categoriesDbContext;
            this._mapper = mapper;
        }

        public async Task<CategoryDetailsVm> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken) {
            var entity = await _categoriesDbContext.Categories
                .FirstOrDefaultAsync(c =>
                c.Id == request.CategoryId, cancellationToken);

            if ( entity is null )
                throw new NotFoundException(nameof(Category), request.CategoryId);

            return _mapper.Map<CategoryDetailsVm>(entity);
        }
    }
}