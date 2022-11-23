using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_A
{
    class node
    {
        /*creates nodes for the circular nexted list*/
        public int rollnumber;
        public string name;
        public node next;
    }
    class Circularlist
    {
        node LAST;

        public Circularlist()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref node previous, ref node current)
            /*Searches for the specified node*/
        {
            for(previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollnumber)
                    return (true);/*returns true if teh node is found*/
            }
            if (rollNo == LAST.rollnumber)/*if the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
