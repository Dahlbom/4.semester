using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_System
{
    public class Stock<T>
    {
        private List<IPortfolie<T>> observers;
        private IPortfolie<T> currentPortfolie;

        virtual public void Attach(IPortfolie<T> portfolie)
        {

        }

        virtual public void Detach(IPortfolie<T> portfolie)
        {

        }

        virtual public void Notify(Stock<T> stock)
        {

        }

        virtual public void SetStockValue(int stockValue) 
        {
            
        }
    }
}
