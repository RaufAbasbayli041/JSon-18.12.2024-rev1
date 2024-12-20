using System.IO;
using System.Text.Json;

namespace PB503_Json_Serialize_DeSerialize_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputMenu;

            do
            {
                ProductService productService = new ProductService();
                Console.WriteLine(@"
                1. All Products - butun product'lari txt'den oxuyub ekranda gosterirsiniz
                2. Get product - verilmis Id'li product'i txt'den oxuyub ekranda gosterirsiniz
                3. Create product - Product'in lazimi parameterleri ile yaradib, txt'e yazdirirsiniz (Json formatda)
                4. Delete product - verilmis Id'li product'i txt'den silirsiniz, yoxdursa ele bir product xeta mesajini gosterirsiniz ekranda");


                string path = "C:\\Users\\ASUS\\Desktop\\";

                Directory.CreateDirectory(path + "JSON task");

                inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "1":
                        productService.GetAll();
                        
                        break;

                    case "2":
                        Console.WriteLine("enter wanted product id");
                        byte wantedId = byte.Parse(Console.ReadLine());
                       
                        Console.WriteLine(productService.Get(wantedId).Name);
                        break;

                    case "3":
                        create:
                        Product createdProduct = new Product();
                        Console.WriteLine("Enter new product's name");
                        string createdProductName = Console.ReadLine();
                        createdProduct.Name = createdProductName;
                        Console.WriteLine("Enter new product's cost price");
                        double createdProductCostPrice = double.Parse(Console.ReadLine());
                        createdProduct.CostPrice = createdProductCostPrice;
                        Console.WriteLine("Enter new product's sales price");
                        double createdProducSalesPrice = double.Parse(Console.ReadLine());
                        createdProduct.SalesPrice = createdProducSalesPrice;
                        try
                        {
                            productService.Create(createdProduct);
                        }
                        catch
                        {
                            Console.WriteLine("");
                            goto create;
                        }
                       

                        break;
                    case "4":
                        Console.WriteLine("enter deleted product's id");
                        byte deletedProductId = byte.Parse(Console.ReadLine());


                        try
                        {
                            productService.Delete(deletedProductId);
                        }
                        catch 
                        {
                            Console.WriteLine("product tapilmadi");
                        }

                       
                        break;

                    default:
                        Console.WriteLine("enter right menu number");
                        break;

                }

            } while (inputMenu != "0");








        }
    }
}
