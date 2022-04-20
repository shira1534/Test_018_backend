using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.convertos
{
    public class ProductConvertor
    {
        public static ProductDto ToProductDto(Product z)
        {
            return new ProductDto()
            {
                Category = z.Category,
                Price=z.Price,
                ProductId=z.ProductId,
                ProductName=z.ProductName,
                UnitsInStock=z.UnitsInStock
               
            };
        }
        public static Product ToProduct(ProductDto z)
        {
            return new Product()
            {
                Category = z.Category,
                Price = z.Price,
                ProductId = z.ProductId,
                ProductName = z.ProductName,
                UnitsInStock = z.UnitsInStock
            };
        }
        public static List<ProductDto> ToProductDtoList(List<Product> z)
        {
            List<ProductDto> zlist = new List<ProductDto>();

            foreach (var item in z)
            {
                zlist.Add(ToProductDto(item));
            }
            return zlist;
        }

        public static List<Product> ToProductList(List<ProductDto> z)
        {
            List<Product> zlist = new List<Product>();
            foreach (var item in z)
            {
                zlist.Add(ToProduct(item));
            }
            return zlist;
        }

    }
}
