using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21880109_Project
{
    public class Queue
    {
        Node head;
        Node tail;
        public Queue()
        {
            head = null;
            tail = null;
        }
        //Enqueue: them vao tail
        public void Euqueue(double value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }
        //Dequeue: Lay o head
        /*public string Dequeue()
        {
            if (isEmpty())
            {
                throw new Exception("Hàng đợi rỗng");
            }
            string str = head.str;
            head = head.next;
            return str;
        }*/
        public bool isEmpty()
        {
            if(head == null)
            {
                return true;
            }
            return false;
        }

    }
}
