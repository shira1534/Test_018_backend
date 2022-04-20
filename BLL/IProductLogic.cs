using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IProductLogic
    {
        List<ProductDto> GetAllProduct();
        ProductDto GetProductById(int id);
        ProductDto AddProduct(ProductDto z);
        List<ProductDto> GetProductByUnitsInStock(int num);
        List<ProductDto> SearchProduct(string name, string category, int priceId);

        bool isEexsist(ProductDto z);

        ProductDto Edit(ProductDto u);
    }
}
