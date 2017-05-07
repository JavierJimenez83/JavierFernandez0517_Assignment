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
            listStock.Add(new Stock("GIN",  StockType.PREFERRED, 8.0,    0.02,    100.0));
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
        /// <param name="stockSymbol">Stock symbol (to identify stock)</param>
        /// <returns>This returns a stock; it returns null if there is not a stock with such stock symbol</returns>
        public Stock getStockByStockSymbol(string stockSymbol)
        {
            try
            {
                Stock stock = this.GetListStock().Find(x => x.GetStockSymbol() == stockSymbol);
                return stock;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// This method adds a trade to the list of trades (Global Beverage Corporation Exchange)
        /// </summary>
        /// <param name="trade">Trade</param>
        /// <returns>It returns 'true' if the trade has been added successfully; it returns 'false' if the trade has not been added</returns>
        public bool addTrade(Trade trade)
        {
            try
            {
                this.GetListTrade().Add(trade);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Get all the trade of a particular stock that have been traded in a given period
        /// </summary>
        /// <param name="stockSymbol">Stock symbol (to identify stock)</param>
        /// <param name="periodMinutes">Given period (15 minutes from requirements, but this can be modified in GBCEMain class)</param>
        /// <returns></returns>
        public List<Trade> getListTradeInPeriod(string stockSymbol, int periodMinutes)
        {
            List<Trade> listTradeInPeriod = new List<Trade>();

            foreach(Trade x in this.GetListTrade())
            {
                try
                {
                    // Geting stock symbol of that trade
                    string tradeStockSymbol = x.GetStock().GetStockSymbol();
                    bool isCorrectStock = tradeStockSymbol == stockSymbol ? true : false;

                    // Comparing DateTime now to time trade happened
                    DateTimeOffset timeNow = DateTimeOffset.Now;
                    DateTimeOffset timeTrade = x.GetTimestamp();
                    int minutes = timeNow.Subtract(timeTrade).Minutes;
                    bool isWithinPeriod = minutes <= periodMinutes ? true : false;

                    // Adding trade to list if: is correct stock AND has been traded in given period
                    if (isCorrectStock && isWithinPeriod)
                    {
                        listTradeInPeriod.Add(x);
                    }
                }
                catch
                {

                }                
            }

            return listTradeInPeriod;
        }
    }
}
