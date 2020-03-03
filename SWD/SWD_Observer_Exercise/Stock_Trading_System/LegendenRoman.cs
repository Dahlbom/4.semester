using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_System
{
    public class LegendenRoman : IPortfolie<LegendenRoman>
    {
        public override int StockAmount { get; set; }
        public override string StockName { get; set; }
        public override double StockValue { get; set; }

        public override void Update(Stock<LegendenRoman> stock)
        {
            base.Update(stock);
        }
    }
}
