using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagementSystem
{
    class StockPortfolio
    {
        public void ReadInpu()
        {
            StockManager stockManager = new StockManager();
            string filePath = @"C:\Users\wsffa\c#_projects\StockManagementSystem\Stock.json";
            StockUtility stockUtility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(filePath));
            Console.WriteLine("Total share value :{0}", stockManager.PrintReport(stockUtility.stocksList));
        }
    }
}
