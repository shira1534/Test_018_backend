using Dal.Models;
using DTO;
using DTO.convertos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogic : IProductLogic
    {
        private Dictionary<int, List<int>> prices = new Dictionary<int, List<int>>();


        private ClothesContext _context;
        public ProductLogic(ClothesContext context)
        {
            _context = context;
            List<int> list = new List<int>();
            list.Add(100);
            list.Add(400);
            prices.Add(1, list);
            List<int> list2 = new List<int>();
            list2.Add(400);
            list2.Add(1000);
            prices.Add(2, list2);
            List<int> list3 = new List<int>();
            list3.Add(1000);
            list3.Add(10000);
            prices.Add(3, list3);


        }
        public ProductDto AddProduct(ProductDto z)
        {
            try
            {
                z.ProductId = 0;
                Product zz = ProductConvertor.ToProduct(z);
                _context.Products.Add(zz);

                _context.SaveChanges();
                return ProductConvertor.ToProductDto(zz);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ProductDto Edit(ProductDto u)
        {
            var t = ProductConvertor.ToProduct(u);
            var Et = _context.Products.FirstOrDefault(use => use.ProductId == u.ProductId);
            if (Et != null)
            {
                Et.Price = u.Price;
                Et.UnitsInStock = u.UnitsInStock;
                Et.ProductName = u.ProductName;
                Et.Category = u.Category;
                _context.SaveChanges();
            }
            return u;
        }

        public List<ProductDto> GetAllProduct()
        {
            return ProductConvertor.ToProductDtoList(_context.Products.ToList());
        }

        public ProductDto GetProductById(int id)
        {
            try
            {
                //123
                return ProductConvertor.ToProductDto(_context.Products.FirstOrDefault(o => o.ProductId == id));

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<ProductDto> GetProductByUnitsInStock(int num)
        {
            return ProductConvertor.ToProductDtoList(_context.Products.Where(o => o.UnitsInStock < num).ToList());
        }

        public bool isEexsist(ProductDto z)
        {
            return _context.Products.Any(p => p.ProductId == z.ProductId);
        }


        public List<ProductDto> SearchProduct(string name, string category, int priceId)
        {
            List<ProductDto> results = new List<ProductDto>();

            List<ProductDto> Products = ProductConvertor.ToProductDtoList(_context.Products.ToList());
            Products.ForEach(Product =>
            {
                if ((name == "" || Product.ProductName == name) && (category == "" || Product.Category == category)
                && (priceId == 0) || (priceId != 0 && Product.Price <= prices[priceId][1] && Product.Price >= prices[priceId][0]))
                {
                    results.Add(Product);
                }
            });

            return results;
        }
    }
}
