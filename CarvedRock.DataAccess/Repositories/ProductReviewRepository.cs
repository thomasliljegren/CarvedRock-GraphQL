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


        public async Task<ILookup<int, ProductReview>> GetByProductIdsAsync(IEnumerable<int> productIds)
        {
            var reviews = await FindByCondition(t => productIds.Contains(t.ProductId)).ToListAsync();
            return reviews.ToLookup(t => t.ProductId);
        }
        public new async Task<ProductReview> Create(ProductReview review)
        {
            base.Create(review);
            await SaveAsync();
            return review;
        }

        public new async Task<ProductReview> Delete(ProductReview review)
        {
            base.Delete(review);
            await SaveAsync();
            return review;
        }

        public new async Task<ProductReview> Update(ProductReview review)
        {
            base.Update(review);
            await SaveAsync();
            return review;
        }
    }
}
