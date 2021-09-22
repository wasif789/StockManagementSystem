using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagementSystem
{
    class StockManager
    {
        int totalValue = 0;
        DateTime date;

        public void CreateNewStock(LinkedList<StockUtility.Stock> stockList)
        {
            StockManager stockManager = new StockManager();
            //create the new object for utility class 
            StockUtility.Stock stock = new StockUtility.Stock();
            Console.WriteLine("Enter the name of Share:");
            stock.companyName = Console.ReadLine();
            Console.WriteLine("Enter the number:");
            stock.numberOfShare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            stock.sharePrice = Convert.ToInt32(Console.ReadLine());
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockList.AddLast(stock);
            stockManager.SaveStock(stockList);
        }

        public int PrintReport(LinkedList<StockUtility.Stock> stocks)
        {
            Console.WriteLine("=================================");
            string item = String.Empty;
            foreach (StockUtility.Stock i in stocks)
            {

                item = "name:" + i.companyName + "\nNumber of shares:" + i.numberOfShare + "\nPrice:" + i.sharePrice;
                Console.WriteLine(item);
                Console.WriteLine("Date and Time of stock update:{0}  {1}", i.date, i.time);
                int stockvalue = CalculateStockValue(i.numberOfShare, i.sharePrice);
                Console.WriteLine("Stock Value for {0} company is:{1}", i.companyName, stockvalue);
                totalValue += stockvalue;
                Console.WriteLine("===================================");
            }
            return totalValue;
        }

        public void BuyShare(int amount, string company, LinkedList<StockUtility.Stock> stockList)
        {

            StockManager stockManager = new StockManager();
            //create the new object for utility class 
            StockUtility.Stock stock = new StockUtility.Stock();
            int contains = 0;
            int price = 0;
            foreach (StockUtility.Stock i in stockList)
            {
                if (i.companyName.Equals(company))
                {
                    amount += i.numberOfShare;
                    price = i.sharePrice;
                    company = i.companyName;
                    contains = 1;
                    stockList.Remove(stockList.Find(i));
                    break;
                }
            }
            if (contains == 0)
            {
                Console.WriteLine("Stock not already available");
                Console.WriteLine("Enter the price of stock:");
                price = Convert.ToInt32(Console.ReadLine());
            }
            stock.companyName = company;
            stock.numberOfShare = amount;
            stock.sharePrice = price;
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockList.AddLast(stock);
            stockManager.SaveStock(stockList);
        }

        public void SellShare(int amount, string company, LinkedList<StockUtility.Stock> stockList)
        {

            StockManager stockManager = new StockManager();
            //create the new object for utility class 
            StockUtility.Stock stock = new StockUtility.Stock();
            int contains = 0;
            int price = 0;
            foreach (StockUtility.Stock i in stockList)
            {
                if (i.companyName.Equals(company) && amount < i.numberOfShare)
                {
                    amount = i.numberOfShare - amount;
                    price = i.sharePrice;
                    company = i.companyName;
                    contains = 1;
                    stockList.Remove(stockList.Find(i));
                    break;
                }
            }
            if (contains == 1)
            {
                stock.companyName = company;
                stock.numberOfShare = amount;
                stock.sharePrice = price;
                date = DateTime.Now;
                stock.date = date.ToString("dd/MM/yyyy");
                stock.time = date.ToString("HH:mm:ss");
                stockList.AddLast(stock);
                stockManager.SaveStock(stockList);
            }

            else
            {
                Console.WriteLine("No share is Available"); ;
            }

        }

        public void SaveStock(LinkedList<StockUtility.Stock> stocks)
        {
            string filePath = @"C:\Users\wsffa\c#_projects\StockManagementSystem\Stock.json";
            StockUtility stockUtility = new StockUtility();
            stockUtility.stocksList = stocks;

            File.WriteAllText(filePath, JsonConvert.SerializeObject(stockUtility));
        }

        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);
        }
    }
}
