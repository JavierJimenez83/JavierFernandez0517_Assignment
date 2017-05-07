using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavierFernandez0517_Assignment.Model
{
    public class Stock
    {
        // Stock class properties
        private string stockSymbol = null;
        private StockType stockType = StockType.COMMON;
        private double lastDividend = 0.0;
        private double? fixedDividend = 0.0;
        private double parValue = 0.0;

        // Stock class getters-setters
        public string GetStockSymbol(){ return stockSymbol; }
        public void SetStockSymbol(string value) { this.stockSymbol = value; }

        public StockType GetStockType() { return stockType; }
        public void SetStockType(StockType value) { this.stockType = value; }

        public double GetLastDividend() { return lastDividend; }
        public void SetLastDividend(double value) { this.lastDividend = value; }

        public double? GetFixedDividend() { return fixedDividend; }
        public void SetFixedDividend(double? value) { this.fixedDividend = value; }

        public double GetParValue() { return parValue; }
        public void SetParValue(double value) { this.parValue = value; }
                
        /// <summary>
        /// This is the Stock class constructor
        /// </summary>
        /// <param name="sto">Stock Symbol</param>
        /// <param name="typ">Stock Type (Common or Preferred)</param>
        /// <param name="las">Last Dividend</param>
        /// <param name="fix">Fixed Dividend</param>
        /// <param name="par">Par Value</param>
        public Stock(string sto, StockType typ, double las, double? fix, double par)
        {
            this.stockSymbol = sto;
            this.stockType = typ;
            this.lastDividend = las;
            this.fixedDividend = fix;
            this.parValue = par;
        }

        /// <summary>
        /// This method calculates the dividend yield for a specific Stock (both COMMON and PREFERRED)
        /// </summary>
        /// <param name="marketPrice">Market price</param>
        /// <returns>This method returns the dividend yield; it returns -1.0 if and only if market price is less or equal than 0.0</returns>
        public double DividendYield(double marketPrice)
        {
            if (marketPrice > 0.0)
            {
                // If Stock Type is COMMON
                if(stockType == StockType.COMMON)
                {
                    return lastDividend / marketPrice ;
                }
                // If Stock Type is PREFERRED
                else
                {
                    // fixedDividend is a nullable double; try and catch block throws an exception when fixedDividend is null
                    try
                    {
                        // Casting to double
                        double fixDiv = (double)fixedDividend;
                        return (fixDiv * parValue) / marketPrice;
                    }
                    catch
                    {
                        return -1.0;
                    }
                }
            }
            else
            {
                return -1.0;
            }
        }

        /// <summary>
        /// This method calculates the price-earnings ratio for a specific Stock (both COMMON and PREFERRED, through the DividendYield method)
        /// </summary>
        /// <param name="marketPrice">Market price</param>
        /// <returns>This method returns the price-earnings ratio; it returns -1.0 if and only if market price is less or equal than 0.0</returns>
        public double PriceEarningsRatio(double marketPrice)
        {
            if (marketPrice > 0.0)
            {
                double dividendYield = DividendYield(marketPrice);
                return marketPrice / dividendYield ;
            }
            else
            { 
                return -1.0;
            }
        }
    }
}
