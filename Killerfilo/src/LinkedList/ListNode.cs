using Killerfilo.src.Node;
namespace Killerfilo.src.LinkedList
{
    class ListNode<T>(T val,ListNode<T>? next = null) : Node<T>(val)
    {
        private ListNode<T>? next = next;

        internal ListNode<T>? Next { get => next; set => next = value; }

        public override string ToString()
        {
            return $"{base.ToString}, Next = {next}";
        }
    }
}