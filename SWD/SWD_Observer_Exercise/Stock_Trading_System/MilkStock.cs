using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_System
{
    public class MilkStock : Stock<MilkStock>
    {
        private List<IPortfolie<MilkStock>> observers = new List<IPortfolie<MilkStock>>();
        private IPortfolie<MilkStock> currentPortfolie;

        public MilkStock()
        {
            SetStockValue(45);
            Notify(this);
        }

        override public void Attach(IPortfolie<MilkStock> portfolie)
        {
            observers.Add(portfolie);
        }

        override public void Detach(IPortfolie<MilkStock> portfolie)
        {
            observers.Remove(portfolie);
        }

        override public void Notify(Stock<MilkStock> stock)
        {
            foreach (var observer in observers)
            {
                observer.Update(stock);
            }
        }

        public override void SetStockValue(int stockValue)
        {
            currentPortfolie.StockValue = stockValue;
            Notify(this);
        }

    }
}
