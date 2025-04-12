using System.Text;

namespace Killerfilo.src.LinkedList
{
    class LinkedList<T>(ListNode<T>? head = null)
    {
        private ListNode<T>? head = head;
        private int lenght = 0;

        public int Lenght { get => lenght; set => lenght = value; }
        internal ListNode<T>? Head { get => head; set => head = value; }

        public void Add(ListNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (head == null)
            {
                head = node;
                lenght++;
                return;
            }

            ListNode<T> curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = node;
            lenght++;
        }

        public void Remove(ListNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (head == null)
            {
                throw new NullReferenceException("Lista vuota");
            }

            T val = node.Val;

            if (head.Val != null && head.Val.Equals(val))
            {
                head = head.Next;
                return;
            }

            ListNode<T>? prev = head;
            ListNode<T>? curr = head.Next;

            while (curr != null)
            {
                if (curr.Val != null && curr.Val.Equals(val))
                {
                    prev.Next = curr.Next;
                    lenght--;
                    return;
                }
                prev = curr;
                curr = curr.Next;
            }
        }
         public override string ToString()
        {
            if (head == null)
            {
                return "Head : Empty";
            }
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');
            ListNode<T> curr = head;
            while (curr.Next != null)
            {
                stringBuilder.Append(curr.Val + ",");
                curr = curr.Next;
            }
            stringBuilder.Append(curr.Val); // Append the last element without trailing comma
            stringBuilder.Append(']');
            stringBuilder.Append($", Lenght = {lenght}");
            return stringBuilder.ToString();
        }
    }
}