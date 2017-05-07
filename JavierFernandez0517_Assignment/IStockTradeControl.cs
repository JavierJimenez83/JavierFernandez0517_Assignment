using JavierFernandez0517_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavierFernandez0517_Assignment
{
    public interface IStockTradeControl
    {
        /// <summary>
        /// List of stocks (Global Beverage Corporation Exchange)
        /// </summary>
        /// <returns>List of stocks (Global Beverage Corporation Exchange)</returns>
        //public List<Stock> obtainGBCEStockList();

        /// <summary>
        /// List of trades (Global Beverage Corporation Exchange)
        /// </summary>
        /// <returns>List of trades (Global Beverage Corporation Exchange)</returns>
       // public List<Trade> obtainGBCETradeList();

        /// <summary>
        /// This method returns a Stock with a specific stock symbol
        /// </summary>
        /// <param name="stockSymbol">Stock symbol (to identify stock)</param>
        /// <returns>This returns a stock; it returns null if there is not a stock with such stock symbol</returns>
        //public Stock getStockByStockSymbol(string stockSymbol);

        /// <summary>
        /// This method adds a trade to the list of trades (Global Beverage Corporation Exchange)
        /// </summary>
        /// <param name="trade">Trade</param>
        /// <returns>It returns 'true' if the trade has been added successfully; it returns 'false' if the trade has not been added</returns>
        //public bool addTrade(Trade trade);
    }
}
