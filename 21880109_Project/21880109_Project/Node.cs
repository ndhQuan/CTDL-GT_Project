using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21880109_Project
{
    public class Node
    {
        public char ch;
        public double value;
        public Node next;

        public Node(double a)
        {
            value = a;
            next = null;
        }
        public Node(char a)
        {
            ch = a;
            next = null;
        }

    }
}
