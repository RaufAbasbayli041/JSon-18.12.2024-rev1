using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PB503_Json_Serialize_DeSerialize_homework
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>();

        public void Create(Product product)
        {
            _products.Add(product);           

        }

        public Product Get(int id)
        {
            Product wantedProduct = new Product();
            _products.FindIndex(wantedProduct => wantedProduct.Id == id);
            return wantedProduct;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Delete(int id)
        {            
            _products.RemoveAt(id);
        }
    }
}
