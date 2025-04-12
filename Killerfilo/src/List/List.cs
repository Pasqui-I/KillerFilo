using System.Text;
using Killerfilo.src.LinkedList;

namespace Killerfilo.src.List
{
    abstract class List<T>(ListNode<T>? head = null)
    {
        // Nodo di testa della lista
        private ListNode<T>? head = head;
        protected readonly int length = (head == null) ? 0 : 1;

        // Proprietà per la lunghezza della lista
        public int Length { get => length;}
        protected ListNode<T>? Head { get => head; set => head = value; }

        // Proprietà per il nodo di testa


        // Metodo astratto per aggiungere un nodo alla lista
        public abstract void Add(ListNode<T> node);

        // Metodo astratto per rimuovere un nodo dalla lista
        public abstract void Remove(ListNode<T> node);

        // Metodo per ottenere la rappresentazione della lista come stringa
        public override string ToString(){
            if (Head == null)
            {
                return "[]";
            }
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');
            ListNode<T> curr = Head;
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
