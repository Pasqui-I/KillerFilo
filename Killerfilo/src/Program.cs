using Killerfilo.src.LinkedList;

namespace Killerfilo.src
{
    class Program
    {
        private static void Main(string[] args)
        {
            LinkedList.LinkedList<int> list = new();
            for (int i = 0; i < 4; i++)
            {
                list.Add(new ListNode<int>(i));
                Console.WriteLine(i);
            }
            Console.WriteLine(list);

            list.Remove(new(100));
            Console.WriteLine(list);
            
        }

    }
}

