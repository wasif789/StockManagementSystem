using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagementSystem
{
    class StockManager
    {
        StockLinkedList stockLinkedList;
        LinkedListStack stack;
        LinkedQueue queue;
        int totalValue = 0;
        StockUtility[] stocks1;
        DateTime date;
        public StockManager()
        {
            this.stockLinkedList = new StockLinkedList();
            this.stack = new LinkedListStack();
            this.queue = new LinkedQueue();
        }

        //method to add new share 
        public void CreateNewStock(StockManager stockManager)
        {
            StockUtility stock = new StockUtility();
            Console.WriteLine("Enter the name of Share:");
            stock.companyName = Console.ReadLine();
            Console.WriteLine("Enter the number:");
            stock.numberOfShare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            stock.sharePrice = Convert.ToInt32(Console.ReadLine());
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockLinkedList.AddLast(stock);
            stockManager.Track(stock.companyName, "Brought", stock.date, stock.time);
        }

        //method to print the report
        public int PrintReport()
        {
            Console.WriteLine("=================================");
            string item = String.Empty;

            stocks1 = this.stockLinkedList.display();
            if (stocks1 == null)
            {
                Console.WriteLine("No shares available to display");
            }
            else
            {
                for (int i = 0; i < stocks1.Length; i++)
                {

                    item = "name:" + stocks1[i].companyName + "\nNumber of shares:" + stocks1[i].numberOfShare + "\nPrice:" + stocks1[i].sharePrice;
                    Console.WriteLine(item);
                    Console.WriteLine("Date and Time of stock update:{0}  {1}", stocks1[i].date, stocks1[i].time);
                    int stockvalue = CalculateStockValue(stocks1[i].numberOfShare, stocks1[i].sharePrice);
                    Console.WriteLine("Stock Value for {0} company is:{1}", stocks1[i].companyName, stockvalue);
                    totalValue += stockvalue;
                    Console.WriteLine("===================================");
                }
            }
            return totalValue;
        }

        //method to buy the share 
        public void BuyShare(int amount, string company, StockManager stockManager)
        {
            //create the new object for utility class 
            StockUtility stock = new StockUtility();
            int contains = 0;
            int price = 0;
            stocks1 = this.stockLinkedList.display();
            for (int i = 0; i < stocks1.Length; i++)
            {
                if (stocks1[i].companyName.Equals(company))
                {
                    stocks1[i].numberOfShare += amount;
                    date = DateTime.Now;
                    stocks1[i].date = date.ToString("dd/MM/yyyy");
                    stocks1[i].time = date.ToString("HH:mm:ss");
                    contains = 1;
                    break;
                }
            }
            if (contains == 0)
            {
                Console.WriteLine("Stock not already available");
                Console.WriteLine("Enter the price of stock:");
                price = Convert.ToInt32(Console.ReadLine());
                stock.companyName = company;
                stock.numberOfShare = amount;
                stock.sharePrice = price;
                date = DateTime.Now;
                stock.date = date.ToString("dd/MM/yyyy");
                stock.time = date.ToString("HH:mm:ss");
                stockLinkedList.AddLast(stock);
            }

            stockManager.Track(company, "Brought", stock.date, stock.time);
        }

        //method to sell the share 
        public void SellShare(int amount, string company, StockManager stockManager)
        {
            StockUtility stock = new StockUtility();
            int contains = 0;
            stocks1 = this.stockLinkedList.display();
            for (int i = 0; i < stocks1.Length; i++)
            {
                if (stocks1[i].companyName.Equals(company) && amount < stocks1[i].numberOfShare)
                {
                    stocks1[i].numberOfShare -= amount;
                    Console.WriteLine("{0} number of shares has been sold ", amount);
                    stocks1[i].date = date.ToString("dd/MM/yyyy");
                    stocks1[i].time = date.ToString("HH:mm:ss");
                    contains = 1;
                    break;
                }
                else if (stocks1[i].companyName.Equals(company) && amount < stocks1[i].numberOfShare)
                {
                    contains = 1;
                    Console.WriteLine("since amount is less that available share enite share is sold ");
                    //if number of share is less than amount the remove the entire share
                    stockLinkedList.RemoveData(stocks1[i]);
                    break;
                }
            }
            if (contains == 0)
            {
                Console.WriteLine("No share is Available"); ;
            }
            else
            {
                stockManager.Track(company, "Sold", stock.date, stock.time);
            }

        }

        //method to track the transaction that calls stack push and enqueue method
        public void Track(string name, string action, string date, string time)
        {
            stack.PushStack(name, action);
            queue.EnqueueData(name, date, time);
        }

        //method that invoke pop() and display the purchase detail
        public void PuchaseDetail()
        {
            stack.PopStack();
        }

        //method that invoke queue and display the time and date of transaction
        public void TransactionDetail()
        {
            queue.Dequeue();
        }


        //calculate the total share value
        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);

        }
    }
}

