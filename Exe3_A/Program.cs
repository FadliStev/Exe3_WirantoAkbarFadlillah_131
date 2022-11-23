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
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void tarverse()/*Traverses all the nodes of the lsit*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are : \n");
                node currentnode;
                currentnode = LAST.next;  
                while (currentnode != LAST)
                {
                    Console.Write(currentnode.rollnumber + " " + currentnode.name + "\n");
                    currentnode = currentnode.next;
                }
                Console.Write(LAST.rollnumber +""+LAST.name + "\n");
            }
        }
        public void firstnode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("\nThe first record in the list is : \n\n" + LAST.next.rollnumber + "" + LAST.next.name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
