using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMAssessment
{
    public enum GoodsType
    {
        Book = 1,
        Food = 2,
        Medical = 3,
        Other = 4
    }
    public abstract class Goods
    {
        public string Name { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Type { get; }

        public Goods(string name, bool isImported, decimal price, int quantity)
        {
            Name = name;
            IsImported = isImported;
            Price = price;
            Quantity = quantity;
        }

        public virtual decimal CalculateTax()
        {
            decimal tax = 0;

            if (IsImported == true)
            {
                tax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            return Math.Round(tax, 2);
        }
    }

    public class Book : Goods
    {
        public Book(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }

    public class Medical : Goods
    {
        public Medical(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }

    public class Food : Goods
    {
        public Food(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }

    public class Others : Goods
    {
        public Others(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }

        public override decimal CalculateTax()
        {
            decimal importedTax = 0;

            if (IsImported == true)
            {
                importedTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            var salesTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.1);

            return Math.Round(importedTax + salesTax, 2);
        }
    }
}
