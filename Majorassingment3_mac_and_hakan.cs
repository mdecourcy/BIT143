using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *@Authors Mac DeCourcy & Hakan
 *Major Assignment 3
 *BST using linked list
 */

namespace TreeSort
{
    class Node
    {
        public int commission;
        public string name;
        public Node left;
        public Node right;

        public void display()
        {
            Console.Write("[");
            Console.Write(commission + ", " + name);
            Console.Write("]");
        }
        public Node(string name, int comm)
        {
            this.name = name;
            commission = comm;
            left = null;
            right = null;
        }
    }

    class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        public Node Root()
        {
            return root;
        }

        //Inserts passed through commissions and names into the bst by comparing a newly created node to preexisting nodes if the root node isnt null
        public void Insert(int commission, string name)
        {
            Node newNode = new Node(name, commission);
            newNode.commission = commission;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (commission < current.commission)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
        //recursive function to print out the bst via the "preorder" pattern
        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Console.Write("[" + Root.name + ", $" + Root.commission + "] ");
                Preorder(Root.left);
                Preorder(Root.right);
            }
        }
        //recursive function to print out the bst via the "Inorder" pattern
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.left);
                Console.Write("[" + Root.name + ", $" + Root.commission + "] ");
                Inorder(Root.right);
            }
        }
        //recursive function to print out the bst via the "postorder" pattern
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.left);
                Postorder(Root.right);
                Console.Write("[" + Root.name + ", $" + Root.commission + "] ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree BTree = new Tree();
            Random rnd = new Random();
            Queue People = new Queue();
            
            //creates boolean elements that act as loop cancelers
            bool decision = false;

            Console.WriteLine("Enter in the name for the salespeople you wish to compare commissions of, or type QUIT to end name selection.");
            string Choice = Console.ReadLine();

            if (Choice == "QUIT")
            {
                decision = true;
            }
            //the loop continues and adds names to the queue
            else
            {
                People.Enqueue(Choice);
            }
            //next loop
            while (decision == false)
            {
                //question for next loop
                int caseSwitch = rnd.Next(1, 5);
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Fantastic, who will be next?");
                        break;
                    case 2:
                        Console.WriteLine("I'll add them to the list! Who's next?");
                        break;
                    case 3:
                        Console.WriteLine("Added to the list! Next?");
                        break;
                    case 4:
                        Console.WriteLine("Next?");
                        break;
                    default:
                        Console.WriteLine("Who's next?");
                        break;
                }

                string nextchoice = Console.ReadLine();
                
         
                //if user quits this ends loop
                if (nextchoice == "QUIT")
                {
                    decision = true;
                    Console.WriteLine();
                    Console.WriteLine();
                }

                //otherwise loop continues and keeps asking for more names
                else
                {
                    People.Enqueue(nextchoice);
                }

            }

            //inserts each string in the queue into the BST, along with a random numerical value for the salesperson's commission
            foreach (string str in People)
            {
                BTree.Insert(rnd.Next(500, 10000), str);
            }

            Console.WriteLine("Preorder Traversal: ");
            BTree.Preorder(BTree.Root());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal: ");
            BTree.Postorder(BTree.Root());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Inorder Traversal: ");
            BTree.Inorder(BTree.Root());
            Console.WriteLine();
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}