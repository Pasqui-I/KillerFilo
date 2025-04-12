namespace Killerfilo.src.Node{
    abstract class Node<T>(T val){
        private T val = val;

        public T Val { get => val; set => val = value; }

        public override string ToString()
        {
            return $"Val = {Val}";
        }
    }
}