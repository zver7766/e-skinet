using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Intefraces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}