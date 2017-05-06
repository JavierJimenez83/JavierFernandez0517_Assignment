using JavierFernandez0517_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavierFernandez0517_Assignment
{
    public class StockTradeControl : IStockTradeControl
    {
        // StockTradeControl class properties
        List<Stock> listStock = new List<Stock>(); // = obtainGBCEStockList();
        List<Trade> listTrade = new List<Trade>();

        // StockTradeControl class getters-setters
        public List<Stock> GetListStock() { return listStock; }
        public void SetListStock(List<Stock> value) { this.listStock = value; }

        public List<Trade> GetListTrade() { return listTrade; }
        public void SetListTrade(List<Trade> value) { this.listTrade = value; }
        
        /// <summary>
        /// This method return the list of stocks (Global Beverage Corporation Exchange)
        /// THIS SHOULD BE RETRIEVED FROM A DATABASE. HARDCODED AS NO DATABASE IS REQUIRED.
        /// </summary>
        /// <returns>List of stocks from the Global Beverage Corporation Exchange</returns>
        public List<Stock> obtainGBCEStockList()
        {            
            List<Stock> listStock = new List<Stock>();
            listStock.Add(new Stock("TEA",  StockType.COMMON,    0.0,    null,   100.0));
            listStock.Add(new Stock("POP",  StockType.COMMON,    8.0,    null,   100.0));
            listStock.Add(new Stock("ALE",  StockType.COMMON,    23.0,   null,   100.0));
            listStock.Add(new Stock("GIN",  StockType.PREFERRED, 8.0,    2.0,    100.0));
            listStock.Add(new Stock("JOE",  StockType.COMMON,    13.0,   null,   100.0));
            return listStock;
        }

        /// <summary>
        /// This method return the list of trades (Global Beverage Corporation Exchange)
        /// THIS SHOULD BE RETRIEVED FROM A DATABASE. 
        /// </summary>
        /// <returns>List of stocks from the Global Beverage Corporation Exchange</returns>
        public List<Trade> obtainGBCETradeList()
        {
            List<Trade> listTrade = new List<Trade>();
            /*
             *  DATABASE QUERYING
             */
            return listTrade;
        }

        /// <summary>
        /// This method returns a Stock with a specific stock symbol
        /// </summary>
        /// <param name="stockSymbol">Stock symbol</param>
        /// <returns>This returns a stock; it returns null if there is not a stock with such stock symbol</returns>
        public Stock getStockByStockSymbol(string stockSymbol)
        {
            try
            {
                Stock stock = this.listStock.Find(x => x.GetStockSymbol() == stockSymbol);
                return stock;
            }
            catch
            {
                return null;
            }
        }

    }
}
