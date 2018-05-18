using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new Phone
            {
                Manufacturer = "Apple",
                Model = "iPhone X",
                Price = 1200.00
            };

            var phoneAsJsonString = JsonConvert.SerializeObject(phone, Formatting.Indented);
            Console.WriteLine(phoneAsJsonString);

            File.WriteAllText("Phone.json", phoneAsJsonString);


            var phoneStringFromFile = File.ReadAllText("Phone.json");

            var phoneDeserialized = JsonConvert.DeserializeObject<Phone>(phoneStringFromFile);
            Console.WriteLine(phoneDeserialized);

            Console.ReadKey();
        }
    }

    internal class Phone
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ${Price}";
        }
    }
}
