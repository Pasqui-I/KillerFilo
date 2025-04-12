using System.Reflection.Metadata;
using Killerfilo.src.LinkedList;

namespace Killerfilo.src
{
    class Program
    {
        private static void Main(string[] args)
        {
            LinkedList.LinkedList<int> list = new();
            Console.WriteLine(list);
            for (int i = 0; i < 10; i++)
            {
                list.Add(new(i));
            }
            Console.WriteLine(list);
            list.Remove(new(10));
            Console.WriteLine(list);
        }



    }
}

