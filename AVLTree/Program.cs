using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> avl = new Tree<int>();


            avl.Add(12);
            avl.Add(11);
            avl.Add(15);
            avl.Add(2);
            avl.Add(18);
            avl.Add(1);
            avl.Add(15);
            avl.Add(15);


            foreach (var t in avl)
            {
                Console.WriteLine(t);
            }
        }
    }
}
