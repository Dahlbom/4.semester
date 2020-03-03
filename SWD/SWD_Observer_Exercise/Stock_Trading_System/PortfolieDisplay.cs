using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_System
{
    public class PortfolieDisplay<T> : IPortfolie<T>
    {
        virtual public string StockName { get; set; }
        virtual public int StockAmount { get; set; }
        virtual public double StockValue { get; set; }

        virtual public void Update(Stock<T> stock)
        {
            
        }
    }

    public class LegendenRomanDisplay<T> : PortfolieDisplay<T>
    {
        public override int StockAmount { get; set; }
        public override string StockName { get; set; }
        public override double StockValue { get; set; }

        public override void Update(Stock<T> stock)
        {
            base.Update(stock);
        }
    }
}
