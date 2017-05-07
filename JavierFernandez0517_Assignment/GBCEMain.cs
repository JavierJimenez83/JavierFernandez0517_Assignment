using JavierFernandez0517_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavierFernandez0517_Assignment
{
    /// <summary>
    /// Main entry point of this library
    /// </summary>
    public class GBCEMain
    {
        // GBCEMain class property
        private StockTradeControl stockTradeControl = new StockTradeControl();
        private static int periodMinutes = 15;

        // GBCEMain class getter
        public StockTradeControl GetStockTradeControl() { return stockTradeControl; }

        /// <summary>
        /// This method returns the dividend yield of a specific stock. Market price is an input (requirement)
        /// </summary>
        /// <param name="stockSymbol">Stock symbol (to identify stock)</param>
        /// <param name="marketPrice">Market Price</param>
        /// <returns>Dividend yield of a specific stock</returns>
        public double calculateDividendYield(string stockSymbol, double marketPrice)
        {
            try
            {
                // Get stock
                Stock stock = this.GetStockTradeControl().getStockByStockSymbol(stockSymbol);

                // Get dividend yield
                return stock.getDividendYield(marketPrice);
            }
            catch
            {
                return -1.0;
            }
        }

        /// <summary>
        /// This method returns the price-earning ratio of a specific stock. Market price is an input (requirement)
        /// </summary>
        /// <param name="stockSymbol">Stock symbol (to identify stock)</param>
        /// <param name="marketPrice">Market Price</param>
        /// <returns>Price-earning ratio of a specific stock</returns>
        public double calculatePriceEarningsRatio(string stockSymbol, double marketPrice)
        {
            try
            {
                // Get stock
                Stock stock = this.GetStockTradeControl().getStockByStockSymbol(stockSymbol);

                // Get dividend yield
                return stock.getPriceEarningsRatio(marketPrice);
            }
            catch
            {
                return -1.0;
            }
        }

        /// <summary>
        /// This method records a new trade
        /// </summary>
        /// <param name="timestamp">Timestamp of trade</param>
        /// <param name="quantityOfShares">Quantity of shares</param>
        /// <param name="tradeBuySell">Buy or Sell indicator</param>
        /// <param name="tradePrice">Trade price</param>
        /// <param name="stockSymbol">Stock Symbol (to identify stock)</param>
        /// <returns>It returns 'true' if the trade has been added successfully; it returns 'false' if the trade has not been added</returns>
        public bool recordTrade(DateTime timestamp, long quantityOfShares, TradeBuySell tradeBuySell, double tradePrice, string stockSymbol)
        {
            try
            {
                // Get stock
                Stock stock = this.GetStockTradeControl().getStockByStockSymbol(stockSymbol);

                // Create trade instance
                Trade trade = new Trade(timestamp, quantityOfShares, tradeBuySell, tradePrice, stock);

                // Record trade
                return this.stockTradeControl.addTrade(trade);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method returns the volume weighted stock price of trades for a specific stock in a give period 
        /// (15 minutes from requirements, but this can be modified in GBCEMain class)
        /// </summary>
        /// <param name="stockSymbol">Stock Symbol (to identify stock)</param>
        /// <returns>Volume Weighted Stock Price</returns>
        public double calculateVWStockPrice(string stockSymbol)
        {
            try
            {
                // Get list of trades in a give period (15 minutes from requirements, but this can be modified in GBCEMain class)
                List<Trade> listTradeInPeriod = this.GetStockTradeControl().getListTradeInPeriod(stockSymbol, periodMinutes);

                // Get Summatory(TradePrice[i] * QuantityShares[i]) and Summatory(QuantityShares[i]) for all those trades
                double summPriceTimesQuant = 0.0;
                double summQuant = 0.0;
                foreach(Trade x in listTradeInPeriod)
                {
                    summPriceTimesQuant += x.GetTradePrice() * x.GetQuantityOfShares();
                    summQuant += x.GetQuantityOfShares();
                }

                // Get Volume Weighted Stock Price
                return summPriceTimesQuant / summQuant;
            }
            catch
            {
                return -1.0;
            }
            
        }
    }
}
