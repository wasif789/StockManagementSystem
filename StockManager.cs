using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagementSystem
{
    class StockManager
    {
        int totalValue = 0;
        public int PrintReport(LinkedList<StockUtility.Stock> stocks)
        {
            Console.WriteLine("=================================");
            string item = String.Empty;
            foreach (StockUtility.Stock i in stocks)
            {

                item = "name:" + i.companyName + "\nNumber of shares:" + i.numberOfShare + "\nPrice:" + i.sharePrice;
                Console.WriteLine(item);
                int stockvalue = CalculateStockValue(i.numberOfShare, i.sharePrice);
                Console.WriteLine("Stock Value for {0} company is:{1}", i.companyName, stockvalue);
                totalValue += stockvalue;
                Console.WriteLine("===================================");
            }
            return totalValue;
        }

        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);
        }
    }
}
