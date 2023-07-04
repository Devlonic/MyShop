using MediatR;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Application.Common.Exceptions;
using MyShop.Core.Application.Interfaces;
using MyShop.Core.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Application.MediatR.Catalog.Categories.Commands.UpdateCategory {
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit> {
        private readonly ICategoriesDbContext _categoriesDbContext;

        public UpdateCategoryCommandHandler(ICategoriesDbContext categoriesDbContext) {
            this._categoriesDbContext = categoriesDbContext;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken) {
            var entity =
                await _categoriesDbContext.Categories.FirstOrDefaultAsync(
                    c =>
                    c.Id == request.CategoryId, cancellationToken);

            if ( entity is null /*|| entity.CreatorID != request.CreatorId*/ )
                throw new NotFoundException(nameof(Category), request.CategoryId);

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.Image = request.Image;
            entity.DateEdit = DateTime.Now;

            await _categoriesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
