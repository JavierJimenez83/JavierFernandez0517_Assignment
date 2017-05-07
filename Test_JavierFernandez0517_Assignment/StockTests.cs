using JavierFernandez0517_Assignment;
using JavierFernandez0517_Assignment.Model;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_JavierFernandez0517_Assignment
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void Constructor_NotNullFixedDividend()
        {
            // arrange
            string expectedStockSymbol = "ABC";
            StockType expectedStockType = StockType.COMMON;
            double expectedLastDividend = 12.0;
            double expectedFixedDividend = 13.5;
            double parValue = 120.2;

            // act
            Stock stock = new Stock(expectedStockSymbol, expectedStockType, expectedLastDividend, expectedFixedDividend, parValue);

            // assert
            Assert.AreEqual(expectedStockSymbol, stock.GetStockSymbol(), "Stock Symbol has not been set up correctly");
            Assert.AreEqual(expectedStockType, stock.GetStockType(), "Stock Type has not been set up correctly");
            Assert.AreEqual(expectedLastDividend, stock.GetLastDividend(), "Last Dividend has not been set up correctly");
            Assert.AreEqual(expectedFixedDividend, stock.GetFixedDividend(), "Fixed Dividend has not been set up correctly");
            Assert.AreEqual(parValue, stock.GetParValue(), "Par Value has not been set up correctly");
        }

        [TestMethod]
        public void Constructor_NullFixedDividend()
        {
            // arrange
            string expectedStockSymbol = "DEF";
            StockType expectedStockType = StockType.PREFERRED;
            double expectedLastDividend = 6.3;
            double? expectedFixedDividend = null;
            double expectedParValue = 75.9;

            // act
            Stock stock = new Stock(expectedStockSymbol, expectedStockType, expectedLastDividend, expectedFixedDividend, expectedParValue);

            // assert
            Assert.AreEqual(expectedStockSymbol, stock.GetStockSymbol(), "Stock Symbol has not been set up correctly");
            Assert.AreEqual(expectedStockType, stock.GetStockType(), "Stock Type has not been set up correctly");
            Assert.AreEqual(expectedLastDividend, stock.GetLastDividend(), "Last Dividend has not been set up correctly");
            Assert.AreEqual(expectedFixedDividend, stock.GetFixedDividend(), "Fixed Dividend has not been set up correctly");
            Assert.AreEqual(expectedParValue, stock.GetParValue(), "Par Value has not been set up correctly");
        }
        
        [TestMethod]
        public void DividendYield_NegativeMarketPrice()
        {
            // arrange
            string stockSymbol = "G1H";
            StockType stockType = StockType.COMMON;
            double lastDividend = 15.6;
            double fixedDividend = 0.09;
            double parValue = 100.0;

            double marketPrice = -3.3;
            double expected = -1.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double dividendYield = stock.getDividendYield(marketPrice);

            // assert
            Assert.AreEqual(expected, dividendYield, "Dividend Yield (Negative Market Price) has not been set up correctly");
        }

        [TestMethod]
        public void CommonDividendYield()
        {
            // arrange
            string stockSymbol = "21J";
            StockType stockType = StockType.COMMON;
            double lastDividend = 15.0;
            double fixedDividend = 0.09;
            double parValue = 100.0;

            double marketPrice = 3.0;
            double expected = 5.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double dividendYield = stock.getDividendYield(marketPrice);

            // assert
            Assert.AreEqual(expected, dividendYield, "COMMON dividend Yield has not been set up correctly");
        }

        [TestMethod]
        public void PreferredDividendYield_NotNullFixedDividend()
        {
            // arrange
            string stockSymbol = "K90";
            StockType stockType = StockType.PREFERRED;
            double lastDividend = 15.6;
            double fixedDividend = 0.05;
            double parValue = 200.0;

            double marketPrice = 4.0;
            double expected = 2.5;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double dividendYield = stock.getDividendYield(marketPrice);

            // assert
            Assert.AreEqual(expected, dividendYield, "PREFERRED Dividend Yield (not null fixed dividend) has not been set up correctly");
        }

        [TestMethod]
        public void PreferredDividendYield_NullFixedDividend()
        {
            // arrange
            string stockSymbol = "K90";
            StockType stockType = StockType.PREFERRED;
            double lastDividend = 15.6;
            double? fixedDividend = null;
            double parValue = 200.0;

            double marketPrice = 4.0;
            double expected = -1.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double dividendYield = stock.getDividendYield(marketPrice);

            // assert
            Assert.AreEqual(expected, dividendYield, "PREFERRED Dividend Yield (null fixed dividend) has not been set up correctly");
        }
        
        [TestMethod]
        public void PERAtio_NegativeMarketPrice()
        {
            // arrange
            string stockSymbol = "G1H";
            StockType stockType = StockType.COMMON;
            double lastDividend = 15.6;
            double fixedDividend = 0.09;
            double parValue = 100.0;

            double marketPrice = -3.3;
            double expected = -1.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double peRatio = stock.getPriceEarningsRatio(marketPrice);

            // assert
            Assert.AreEqual(expected, peRatio, "Price-Earnings Ratio (Negative Market Price) has not been set up correctly");
        }
        
        
        [TestMethod]
        public void PERAtio_InvalidDividendYield()
        {
            // arrange
            string stockSymbol = "G1H";
            StockType stockType = StockType.PREFERRED;
            double lastDividend = 15.6;
            double? fixedDividend = null;
            double parValue = 100.0;

            double marketPrice = 3.3;
            double expected = -1.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double peRatio = stock.getPriceEarningsRatio(marketPrice);

            // assert
            Assert.AreEqual(expected, peRatio, "Price-Earnings Ratio (Invalid Dividend Yield: null fixed dividend) has not been set up correctly");
        }
        
        [TestMethod]
        public void PERAtio_Valid()
        {
            // arrange
            string stockSymbol = "G1H";
            StockType stockType = StockType.COMMON;
            double lastDividend = 10.0;
            double? fixedDividend = 2.0;
            double parValue = 100.0;

            double marketPrice = 10.0;
            double expected = 10.0;

            // act
            Stock stock = new Stock(stockSymbol, stockType, lastDividend, fixedDividend, parValue);
            double peRatio = stock.getPriceEarningsRatio(marketPrice);

            // assert
            Assert.AreEqual(expected, peRatio, "Price-Earnings Ratio (Invalid Dividend Yield: null fixed dividend) has not been set up correctly");
        }
    }
}
