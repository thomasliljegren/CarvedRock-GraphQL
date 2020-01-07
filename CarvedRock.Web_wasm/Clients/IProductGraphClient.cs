using CarvedRock.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Web.Clients
{
    public interface IProductGraphClient
    {
        Task<ProductModel> GetProduct(int id);
        Task<IEnumerable<ProductModel>> GetProducts();
    }
}