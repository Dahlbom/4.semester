using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_System
{
    public interface IPortfolie<T>
    {
         
        string StockName { get; set; }
        int StockAmount { get; set; }
        double StockValue { get; set; }

        void Update(Stock<T> stock);
    }
}
