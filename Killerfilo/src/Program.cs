namespace Killerfilo.src
{
    class Program
    {
        private static void Main(string[] args)
        {
            Set.Set<int> set = new();
            set.Add(1);
            set.Add(100);
            Console.WriteLine(set.Exists(34));
        }
    }
}

