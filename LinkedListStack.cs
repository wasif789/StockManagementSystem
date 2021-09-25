using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagementSystem
{
    public class StackNode
    {
        public string name { get; set; }
        public string type { get; set; }
        public StackNode Next { get; set; }
        public StackNode(string name, string type)
        {
            this.name = name;
            this.type = type;
            Next = null;
        }
    }
    class LinkedListStack
    {

        private StackNode head;
        //push stack method insert the node at the begining of the list
        public void PushStack(string name, string type)
        {
            StackNode stack = new StackNode(name, type);
            if (head == null)
            {
                head = stack;
            }

            else
            {
                StackNode temp = head;
                head = stack;
                stack.Next = temp;
            }

        }

        //method that display the stack data 
        public void PopStack()
        {
            Console.WriteLine("======Purchase Details======");
            StackNode temp = head;
            if (head == null)
            {
                Console.WriteLine("No item is available");
            }
            else
            {
                while (temp != null)
                {
                    Console.WriteLine("{0} share is {1}", temp.name, temp.type);
                    temp = temp.Next;
                }
            }
            Console.WriteLine("==============================");
        }
    }
    
}
