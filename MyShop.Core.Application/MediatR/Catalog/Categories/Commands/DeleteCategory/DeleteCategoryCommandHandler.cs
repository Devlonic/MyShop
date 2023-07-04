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

namespace MyShop.Core.Application.MediatR.Catalog.Categories.Commands.DeleteCategory {
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit> {
        private readonly ICategoriesDbContext _categoriesDbContext;

        public DeleteCategoryCommandHandler(ICategoriesDbContext categoriesDbContext) {
            this._categoriesDbContext = categoriesDbContext;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
            var entity =
                await _categoriesDbContext.Categories.FindAsync(new object[] { request.CategoryId }, cancellationToken);

            if ( entity is null /*|| entity.CreatorID != request.CreatorId*/ )
                throw new NotFoundException(nameof(Category), request.CategoryId);

            _categoriesDbContext.Categories.Remove(entity);

            await _categoriesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
