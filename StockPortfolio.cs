using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagementSystem
{
    class StockPortfolio
    {
        public void ReadInput()
        {
            StockManager stockManager = new StockManager();
            //string filePath = @"C:\Users\HP1\source\repos\StockManagementSystem\StockManagementSystem\Stock.json";
            //StockUtility stockUtility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(filePath));
            StockUtility stockUtility = new StockUtility();
            bool CONTINUE = true;

            while (CONTINUE)
            {
                Console.WriteLine("1.Print Report\n2.Add new Share\n3.Buy shares\n4.Sell share");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Total share value :{0}", stockManager.PrintReport());
                        break;
                    case 2:
                        stockManager.CreateNewStock();
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of Share:");
                        string companyName = Console.ReadLine();
                        Console.WriteLine("Enter the number:");
                        int numberOfShare = Convert.ToInt32(Console.ReadLine());
                        stockManager.BuyShare(numberOfShare, companyName);
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of Share to be sold:");
                        string company = Console.ReadLine();
                        Console.WriteLine("Enter the number:");
                        int numOfShare = Convert.ToInt32(Console.ReadLine());
                        stockManager.SellShare(numOfShare, company);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        CONTINUE = false;
                        break;
                }
            }
        }
    }
}
