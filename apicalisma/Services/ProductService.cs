using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apicalisma.Models;
using apicalisma.Function;
namespace apicalisma.Services
{
    public class ProductService : IProductService
    {
        
        public List<Products> GetData()
        {
            List<Products> productList = new List<Products>();
            for (int i = 0; i < 5; i++)
            {
                Products product = new Products();
                product.ProductId = i;
                product.Price ="1"+i.ToString() ;
                product.ProductName = "ekmek" + i.ToString();
                product.ProductImage = Functions.GetImageBase64()[i] ;
                productList.Add(product);
            }
            return productList;
        }
    }
}