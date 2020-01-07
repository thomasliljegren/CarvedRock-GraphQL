using CarvedRock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{
    public interface IProductReviewRepository : IRepositoryBase<ProductReview>
    {
        Task<IEnumerable<ProductReview>> GetAllAsync();
        Task<IEnumerable<ProductReview>> GetByProductIdAsync(int productId);
        Task<ILookup<int, ProductReview>> GetByProductIdsAsync(IEnumerable<int> productIds);
        new Task<ProductReview> Create(ProductReview review);
        new Task<ProductReview> Delete(ProductReview review);
        new Task<ProductReview> Update(ProductReview review);

    }
}
