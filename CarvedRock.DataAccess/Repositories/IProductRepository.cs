using CarvedRock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetById(int id);
        new Task Create(Product product);
        new Task Update(Product product);
        new Task Delete(Product product);

    }
}
