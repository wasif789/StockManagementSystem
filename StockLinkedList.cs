using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagementSystem
{
    class Node
    {
        public StockUtility value { get; set; }
        public Node Next { get; set; }
        public Node(StockUtility stock)
        {
            this.value = stock;
            Next = null;
        }
    }
    public class StockLinkedList
    {
        private Node head;
        //private IEnumerable<StockUtility> value;

        //public StockLinkedList(IEnumerable<T> collection);
         //public StockLinkedList()
        //{

        //}
        public StockLinkedList(params StockUtility[] value)
        {
            foreach (StockUtility temp in value)
            {
                AddLast(temp);

            }
        }
        public void AddLast(StockUtility stock)
        {
            Node newNode = new Node(stock);
            if (head == null)
            {
                head = newNode;
            }

            else
            {
                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }

        }
        public int Count()
        {
            int count = 0;
            if (head != null)
            {
                Node temp = head;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }
            }
            return count;
        }

        public StockUtility[] display()
        {
            int count = Count();
            StockUtility[] result = new StockUtility[count];
            int index = 0;
            Node temp = head;
            while (temp.Next != null)
            {
                result[index++] = temp.value;
                temp = temp.Next;
            }
            result[index] = temp.value;
            return result;
        }

        public void RemoveData(StockUtility stock)
        {
            Node temp = head;
            Node prev = null;
            if (temp != null && temp.value == stock)
            {
                head = temp.Next;

            }

            while (temp != null && temp.value != stock)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp.value == stock)
            {
                prev.Next = temp.Next;
            }
        }
    }
}
