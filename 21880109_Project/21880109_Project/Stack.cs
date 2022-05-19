using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21880109_Project
{
    class Stack
    {
        Node head;
        Node tail;
        public Stack()
        {
            head = null;
            tail = null;
        }
        //Push: them vao head kieu so
        public void PushNumber(double value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }
        //Pop: Lay ra o head kieu so
        public double PopNumber()
        {
            if (isEmpty())
            {
                throw new Exception("Ngăn Xếp rỗng");
            }
            double value = head.value;
            head = head.next;
            return value;
        }
        public double PeekNumber()
        {
            if (isEmpty())
            {
                throw new Exception("Ngăn Xếp rỗng");
            }
            return head.value; 
        }
        //Push: them vao head kieu char
        public void PushCharacter(char value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }
        //Pop: Lay ra o head kieu so
        public char PopCharacter()
        {
            if (isEmpty())
            {
                throw new Exception("Ngăn Xếp rỗng");
            }
            char ch = head.ch;
            head = head.next;
            return ch;
        }
        public char PeekChar() //tim gia tri char o head
        {
            if (isEmpty())
            {
                Exception myException = new Exception("Ngăn Xếp rỗng");
                throw myException;

            }
            return head.ch;
        }

        public bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
    }
}
