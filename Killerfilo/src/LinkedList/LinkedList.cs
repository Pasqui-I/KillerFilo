using System.Text;

namespace Killerfilo.src.LinkedList
{
    class LinkedList<T>(ListNode<T>? head = null)
    {
        private ListNode<T>? head = head;
        private int length = head == null ? 0 : 1;

        public int Length { get => length; set => length = value; }
        internal ListNode<T>? Head { get => head; set => head = value; }

        public void Add(ListNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (head == null)
            {
                AddToEmptyList(node);
                return;
            }
            AddToEnd(node);

        }
        private void AddToEmptyList(ListNode<T> node)
        {
            head = node;
            length++;
        }
        private void AddToEnd(ListNode<T> node)
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is empty");
            }

            ListNode<T> curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = node;
            length++;
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
                RemoveHeadNode();
                return;
            }
            RemoveFromMiddle(node);

        }

        private void RemoveHeadNode()
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is empty");
            }
            head = head.Next;
            length--;
        }
        private void RemoveFromMiddle(ListNode<T> node)
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is empty");
            }
            ListNode<T>? prev = head;
            ListNode<T>? curr = head.Next;

            while (curr != null)
            {
                if (curr.Val != null && curr.Val.Equals(node.Val))
                {
                    prev.Next = curr.Next;
                    length--;
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
            stringBuilder.Append($", Length = {length}");
            return stringBuilder.ToString();
        }
    }
}