

namespace Killerfilo.src.BinaryTree
{
    class BinaryTree<T>(TreeNode<T>? root = null) where T : IComparable<T>
        {
            // La radice dell'albero
            private TreeNode<T>? root = root;

            internal TreeNode<T>? Root { get => root; set => root = value; }



            // Aggiungi un nuovo nodo all'albero
            public void Add(TreeNode<T> newNode)
            {
                ArgumentNullException.ThrowIfNull(newNode);

                // Se la radice è null, assegniamo il nuovo nodo come radice
                if (Root == null)
                {
                    Root = newNode;
                    return;
                }

                TreeNode<T>? curr = Root;
                T val = newNode.Val;

                // Cerca il posto giusto dove inserire il nuovo nodo
                while (curr != null)
                {
                    int compare = val.CompareTo(curr.Val);

                    // Se il valore è minore o uguale, prova a mettere il nodo a sinistra
                    if (compare <= 0)
                    {
                        if (curr.Left == null)
                        {
                            curr.Left = newNode;
                            return;
                        }
                        curr = curr.Left;  // Vai a sinistra
                    }
                    else
                    {
                        if (curr.Right == null)
                        {
                            curr.Right = newNode;
                            return;
                        }
                        curr = curr.Right;  // Vai a destra
                    }
                }
            }

            public void Print()
            {
                List<TreeNode<T>> nodes = BinaryTree<T>.Dfs(Root);
                foreach (TreeNode<T> node in nodes)
                {
                    Console.WriteLine(node.Val);
                }
            }

            // Traversata DFS in ordine Pre-order
            internal static List<TreeNode<T>> Dfs(TreeNode<T>? node)
            {
                if (node == null)
                    return [];

                List<TreeNode<T>> nodes = [node];
                nodes.AddRange(BinaryTree<T>.Dfs(node.Left));
                nodes.AddRange(BinaryTree<T>.Dfs(node.Right));
                return nodes;
            }

            public bool Exists(TreeNode<T> node)
            {
                ArgumentNullException.ThrowIfNull(node);
                T val = node.Val;
                TreeNode<T>? curr = root;
                while (curr != null)
                {
                    int compare = val.CompareTo(curr.Val);
                    switch (compare)
                    {
                        case -1:
                            curr = curr.Left;
                            break;
                        case 0:
                            return true;
                        case 1:
                            curr = curr.Right;
                            break;
                    }
                }
                return false;

            }

            public override string ToString()
            {
                List<TreeNode<T>> nodes = BinaryTree<T>.Dfs(Root);
                return string.Join(", ", nodes.Select(node => $"{node}\n "));
            }



            public void StampaGrafica()
            {
                BinaryTree<T>.StampaGrafica(Root, "", true);
            }

            private static void StampaGrafica(TreeNode<T>? nodo, string indentazione, bool isUltimo)
            {
                if (nodo == null)
                    return;

                Console.Write(indentazione);
                if (isUltimo)
                {
                    Console.Write("└──");
                    indentazione += "   ";
                }
                else
                {
                    Console.Write("├──");
                    indentazione += "│  ";
                }

                Console.WriteLine(nodo.Val);

                bool haSinistro = nodo.Left != null;
                bool haDestro = nodo.Right != null;

                if (haSinistro || haDestro)
                {
                    if (nodo.Left != null)
                        BinaryTree<T>.StampaGrafica(nodo.Left, indentazione, nodo.Right == null);
                    if (nodo.Right != null)
                        BinaryTree<T>.StampaGrafica(nodo.Right, indentazione, true);
                }
            }

        }
}