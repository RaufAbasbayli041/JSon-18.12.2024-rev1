using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503_Json_Serialize_DeSerialize_homework
{
    public class Product
    {
        private static byte _id;
        public byte Id { get; set; }
        public string Name { get; set; }
        public double _costPrice { get; set; }
        private double _salesPrice;
        public double SalesPrice
        {
            get => _salesPrice;
            set
            {
                if (value > _costPrice)
                {
                    _salesPrice = value;
                }
                else
                {
                    Console.WriteLine("Sales price can not be less than cost price");
                }
            }
        }


        public Product()
        {
            Id = ++_id;

        }
    }
}
