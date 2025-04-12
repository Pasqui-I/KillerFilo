using Killerfilo.src.Node;
namespace Killerfilo.src.BinaryTree
{
    class TreeNode<T>(T val, TreeNode<T>? left = null, TreeNode<T>? right = null) : Node<T>(val) where T : IComparable<T>
    {
        private TreeNode<T>? left = left;
        private TreeNode<T>? right = right;

        internal TreeNode<T>? Right { get => right; set => right = value; }
        internal TreeNode<T>? Left { get => left; set => left = value; }

        public override string ToString()
        {
            return $"Node(Value: {Val}, Left: {left}, Right: {right})";
        }
    }
}