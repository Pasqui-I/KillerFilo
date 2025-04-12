namespace Killerfilo.src.Set
{
    class Set<T>(int initialSize = 10)
    {
        private T[] array = new T[initialSize];
        private int size = initialSize;
        private int count = 0;

        public int Size { get => size; private set => size = value; }

        private void Resize()
        {
            size *= 2;  // Double the size when resizing
            T[] newArray = new T[size];

            // Rehash all elements into the new array
            foreach (var item in array)
            {
                if (item != null) // To prevent rehashing null values
                {
                    int bucket = Math.Abs(item.GetHashCode()) % size;
                    newArray[bucket] = item;
                }
            }

            array = newArray;
        }

        public void Add(T val)
        {
            ArgumentNullException.ThrowIfNull(val);

            if (count >= size)  // Resize when the array is full
            {
                Resize();
            }

            int bucket = Math.Abs(val.GetHashCode()) % size;

            // If the bucket is already occupied, handle the collision
            // (Here, we're simply replacing the element, but you could handle it differently)
            if (array[bucket] != null)
            {
                Console.WriteLine($"Overwriting existing value at bucket {bucket}");
            }

            array[bucket] = val;
            count++;
            Console.WriteLine($"Added at bucket {bucket}, size {size}");
        }

        public bool Exists(T val)
        {
            ArgumentNullException.ThrowIfNull(val);

            int bucket = Math.Abs(val.GetHashCode()) % size;

            // If the bucket is empty or the element doesn't match, return false
            if (array[bucket] == null || !array[bucket].Equals(val))
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            foreach (T val in array)
            {
                if (val != null)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
