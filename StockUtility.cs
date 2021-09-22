using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagementSystem
{
    class StockUtility
    {
        public LinkedList<Stock> stocksList { get; set; }


        public class Stock
        {
            public string companyName { get; set; }
            public int numberOfShare { get; set; }
            public int sharePrice { get; set; }

            public string date { get; set; }
            public string time { get; set; }
        }
    }
}
