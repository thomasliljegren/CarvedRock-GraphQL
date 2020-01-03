using CarvedRock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{
    public interface IProductReviewRepository : IRepositoryBase<ProductReview>
    {
        Task<IEnumerable<ProductReview>> GetAllAsync();
        Task<IEnumerable<ProductReview>> GetByProductIdAsync(int productId);
    }
}
