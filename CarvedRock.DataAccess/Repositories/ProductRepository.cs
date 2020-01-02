using CarvedRock.DataAccess.DAL;
using CarvedRock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(CarvedRockContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(t => t.Id)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await FindByCondition(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public new async Task Create(Product product)
        {
            base.Create(product);
            await SaveAsync();
        }

        public new async Task Update(Product product)
        {
            base.Update(product);
            await SaveAsync();
        }

        public new async Task Delete(Product product)
        {
            base.Delete(product);
            await SaveAsync();
        }
    }
}
