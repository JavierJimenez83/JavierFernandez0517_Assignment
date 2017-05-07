using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavierFernandez0517_Assignment.Model
{
    public class Trade
    {
        // Trade class properties
        private DateTimeOffset timestamp = DateTimeOffset.Now; /* DateTimeOffset has been chosen over DateTime because it identifies a single point in time unambiguously*/
        private long quantityOfShares = 0;
        private TradeBuySell buySellIndicator = TradeBuySell.BUY;
        private double tradePrice = 0.0;
        private Stock stock = null;

        // Trade class getters-setters
        public DateTimeOffset GetTimestamp() { return timestamp; }
        public void SetTimestamp(DateTimeOffset value) { this.timestamp = value; }

        public long GetQuantityOfShares() { return quantityOfShares; }
        public void SetQuantityOfShares(long value) { this.quantityOfShares = value; }

        public TradeBuySell GetBuySellIndicator() { return buySellIndicator; }
        public void SetBuySellIndicator(TradeBuySell value) { this.buySellIndicator = value; }

        public double GetTradePrice() { return tradePrice; }
        public void SetTradePrice(double value) { this.tradePrice = value; }

        public Stock GetStock() { return stock; }
        public void SetStock(Stock value) { this.stock = value; }

        /// <summary>
        /// This is the Trade class constructor
        /// </summary>
        /// <param name="tim">Timestamp</param>
        /// <param name="qua">Quantity of shares</param>
        /// <param name="tbs">Trade buy or sell indicator</param>
        /// <param name="pri">Trade price</param>
        public Trade(DateTimeOffset tim, long qua, TradeBuySell tbs, double pri, Stock sto)
        {
            this.SetTimestamp(tim);
            this.SetQuantityOfShares(qua);
            this.SetBuySellIndicator(tbs);
            this.SetTradePrice(pri);
            this.SetStock(sto);
        }
    }
}
