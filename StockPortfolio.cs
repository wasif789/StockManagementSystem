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
                bool CONTINUE = true;
                // 
                while (CONTINUE)
                {
                    Console.WriteLine("1.Print Report\n2.Add new Share\n3.Buy shares\n4.Sell share\n5.Purchase Details\n6.Transaction details");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    //selection statement to select between operation
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Total share value :{0}", stockManager.PrintReport());
                            break;
                        case 2:
                            //to initiate new stock 
                            stockManager.CreateNewStock(stockManager);
                            break;

                        case 3:
                            Console.WriteLine("Enter the name of Share:");
                            string companyName = Console.ReadLine();
                            Console.WriteLine("Enter the number:");
                            int numberOfShare = Convert.ToInt32(Console.ReadLine());
                            stockManager.BuyShare(numberOfShare, companyName, stockManager);
                            break;

                        case 4:
                            //gets input from user
                            Console.WriteLine("Enter the name of Share to be sold:");
                            string company = Console.ReadLine();
                            Console.WriteLine("Enter the number:");
                            int numOfShare = Convert.ToInt32(Console.ReadLine());
                            stockManager.SellShare(numOfShare, company, stockManager);
                            break;

                        case 5:
                            stockManager.PuchaseDetail();
                            break;

                        case 6:
                            stockManager.TransactionDetail();
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

