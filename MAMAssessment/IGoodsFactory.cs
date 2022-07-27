using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMAssessment
{
    public interface IGoodsFactory
    {
        Goods GetGoods(string Name, decimal price, int quantity, GoodsType goodsType, bool isImported);
    }

    public class GoodsFactory : IGoodsFactory
    {
        public Goods GetGoods(string name, decimal price, int quantity, GoodsType goodsType, bool isImported)
        {
            switch (goodsType)
            {
                case GoodsType.Book:
                    return new Book(name, isImported, price, quantity);

                case GoodsType.Food:
                    return new Food(name, isImported, price, quantity);

                case GoodsType.Medical:
                    return new Medical(name, isImported, price, quantity);

                case GoodsType.Other:
                    return new Others(name, isImported, price, quantity);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
