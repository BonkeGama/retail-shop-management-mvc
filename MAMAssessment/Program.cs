using System;
using System.Collections.Generic;
using System.Linq;

namespace MAMAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            IGoodsFactory goodsFactory = new GoodsFactory();
            List<Goods> goodsItems = new List<Goods>();
            int count = 0;

            while (true)
            {
                Console.WriteLine("Add Items");
                Console.WriteLine("");
                Console.WriteLine($"Item {++count}");
                Console.WriteLine("");

                Console.Write("Name : ");
                var name = Console.ReadLine();

                Console.Write("Price : ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    throw new Exception("Invalid price");
                }

                Console.Write("Quantity : ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    throw new Exception("Invalid quantity");
                }

                Console.WriteLine("Is imported : (Y/N)");
                var isImported = Console.ReadLine().ToLower() == "y" ? true : false;

                Console.WriteLine("Type of Item (select one of below)\n1. Book\n2. Food\n3. Medical\n4. Other");

                if (!Enum.TryParse<GoodsType>(Console.ReadLine(), out GoodsType goodsType))
                {
                    throw new Exception("Invalid type");
                }

                Console.WriteLine("Do you want to add more items? (Y/N)");
                var input = Console.ReadLine().ToLower();

                var goods = goodsFactory.GetGoods(name, Convert.ToDecimal(price), Convert.ToInt32(quantity), goodsType, isImported);
                goodsItems.Add(goods);

                if (input == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Your results are as follows:");
            Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
            Console.WriteLine("");

            foreach (var item in goodsItems)
            {
                Console.WriteLine($"{item.Quantity} {item.Name}: {item.Price + item.CalculateTax()}");
            }

            Console.WriteLine($"Sales Tax: {goodsItems.Sum(item => item.CalculateTax())}");
            Console.WriteLine($"Total: {(goodsItems.Sum(item => item.Price) + goodsItems.Sum(item => item.CalculateTax()))}");
            Console.ReadLine();
        }
    }
}
