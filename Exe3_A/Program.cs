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
        public void insertnode()/*add insert node for adding new data*/
        {
            int number;
            string nama;
            Console.WriteLine("\nEnter the roll number of student :");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of student");
            nama = Console.ReadLine();
            node newnode = new node();
            newnode.name = nama;
            newnode.rollnumber = number;

            if (LAST == null || number <= LAST.rollnumber)
            {
                if ((LAST != null) && (number == LAST.rollnumber))
                {
                    Console.WriteLine("");
                    return;
                }
                newnode.next = LAST;
                LAST = newnode;
                return;
            }
            node previous, current;
            previous = LAST.next;
            current = LAST.next;

            while((current != null)&& (number >= current.rollnumber))
            {
                if(number == current.rollnumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = LAST.next;
            LAST.next = newnode;

        }
        public bool deletenode(int rollNo)/*method for delete data that has inserted*/
        {
            node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            } 
            if(rollNo == LAST.rollnumber)
            {
                current = LAST;
                previous = current.next;
                return true;
            }
            if(rollNo == LAST.rollnumber)
            {
                current = LAST;
                previous = current.next;
                while(previous.next != LAST)
                    previous =previous.next;
                previous.next = LAST.next;
                LAST = previous;    
                return true;
            }
            if(rollNo <= LAST.rollnumber)
            {
                current = LAST.next;
                previous = LAST.next;
                while(rollNo > current.rollnumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;
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

        static void Main(string[] args)
        {
            Circularlist obj = new Circularlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the lsit");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add a record to the list");
                    Console.WriteLine("5. Delete a record from the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.tarverse();
                            }
                            break;
                        case '2':
                            {
                                if(obj.listEmpty()== true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number : " + curr.rollnumber);
                                    Console.WriteLine("\nName : " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstnode();
                            }
                            break;
                        case '4':
                            {
                                obj.insertnode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + "whose record is to be deleted : ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deletenode(rollNo) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                    Console.WriteLine("\nRecord will roll number " + rollNo + "deleted\n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }
                          

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());    
                }
            }
        }
    }

   
}
