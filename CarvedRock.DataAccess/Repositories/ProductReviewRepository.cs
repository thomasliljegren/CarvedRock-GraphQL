using CarvedRock.DataAccess.DAL;
using CarvedRock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{
    public class ProductReviewRepository : RepositoryBase<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(CarvedRockContext context) : base(context)
        {

        }
        public async Task<IEnumerable<ProductReview>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(t => t.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductReview>> GetByProductIdAsync(int productId)
        {
            return await FindByCondition(t => t.ProductId == productId)
                .OrderBy(t => t.Id)
                .ToListAsync();
        }
    }
}
