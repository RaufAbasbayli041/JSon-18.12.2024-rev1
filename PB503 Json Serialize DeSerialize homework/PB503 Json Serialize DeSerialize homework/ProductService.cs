using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
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

        private static string path = "C:\\Users\\ASUS\\Desktop\\";

        public void Create(Product product)
        {
            if (!File.Exists(path + "JSON task/example.txt"))
            {
                File.Create(path + "JSON task/example.txt");
            }
            var createdProductJson = JsonSerializer.Serialize(product);

            File.AppendAllLines(path + "JSON task/example.txt", new List<string> { createdProductJson });
            _products.Add(product);
        }

        public Product Get(int id)
        {
            string[] allContents = File.ReadAllLines(path + "JSON task/example.txt");

            foreach (var item in allContents)
            {
                Product product = new Product();
                product = JsonSerializer.Deserialize<Product>(item);
                _products.Add(product);
            }
            Product wantedProduct = _products.Find(wantedProduct => wantedProduct.Id == id);
            return wantedProduct;
        }

        public List<Product> GetAll()
        {

            string[] allContents = File.ReadAllLines(path + "JSON task/example.txt");
            foreach (var item in allContents)
            {

                Console.WriteLine(item);
            }

            return _products;
        }

        public void Delete(int id)
        {
            string[] allContents = File.ReadAllLines(path + "JSON task/example.txt");

            foreach (var item in allContents)
            {
                Product product = new Product();
                product = JsonSerializer.Deserialize<Product>(item);
                _products.Add(product);
            }
            Product wantedProduct = _products.Find(wantedProduct => wantedProduct.Id == id);

            if ( wantedProduct.Id == id)
            {
                _products.Remove(wantedProduct);
                Console.WriteLine("product silindi");
            }
           

            Console.WriteLine("after delete");
            var productAfterRemove = new List<string>();
            foreach (var item in _products)
            {
                productAfterRemove.Add(JsonSerializer.Serialize(item));
            }

            File.WriteAllLines(path + "JSON task/example.txt", productAfterRemove);

            string[] contents = File.ReadAllLines(path + "JSON task/example.txt");
            foreach (var item in contents)
            {
                Product product = JsonSerializer.Deserialize<Product>(item);

            }

            foreach (var item in _products)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }

        }


    }
}
