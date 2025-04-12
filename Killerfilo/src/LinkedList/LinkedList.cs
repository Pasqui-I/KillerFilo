namespace Killerfilo.src.LinkedList
{
    class LinkedList<T>(ListNode<T>? head = null) : List.List<T>(head)
    {
        public override void Add(ListNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (Head == null)
            {
                AddToEmptyList(node);
                return;
            }
            AddToEnd(node);

        }
        private void AddToEmptyList(ListNode<T> node)
        {
            Head = node;
            length++;
        }
        private void AddToEnd(ListNode<T> node)
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head is empty");
            }

            ListNode<T> curr = Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = node;
            length++;
        }

        public override void Remove(ListNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (Head == null)
            {
                throw new NullReferenceException("Lista vuota");
            }

            T val = node.Val;

            if (Head.Val != null && Head.Val.Equals(val))
            {
                RemoveHeadNode();
                return;
            }
            RemoveFromMiddle(node);

        }

        private void RemoveHeadNode()
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head is empty");
            }
            Head = Head.Next;
            length--;
        }
        private void RemoveFromMiddle(ListNode<T> node)
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head is empty");
            }
            ListNode<T>? prev = Head;
            ListNode<T>? curr = Head.Next;

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
            return base.ToString();
        }
    }
}