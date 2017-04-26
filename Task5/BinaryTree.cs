using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// This class represents a binary search tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public sealed class BinaryTree<T>: IEnumerable<T>
    {

        #region Private Fields

        /// <summary>
        /// Main root of binary search tree.
        /// </summary>
        private Node root;

        /// <summary>
        /// Number of elements in binary search tree.
        /// </summary>
        private int count;

        /// <summary>
        /// Custom comparator.
        /// </summary>
        private IComparer<T> comparer;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor which takes custom comparator as an argument.
        /// </summary>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            root = null;

            if (ReferenceEquals(collection, null))
                count = 0;
            else
            {
                foreach (var element in collection)
                    Add(element);
            }
            
            this.comparer = comparer;
        }

        public BinaryTree() : this(null, Comparer<T>.Default) { }

        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparer) : this(collection, Comparer<T>.Default) { }
        
        #endregion

            #region Properties

            /// <summary>
            /// Number of elements in binary search tree.
            /// </summary>
        public int Count => count;

        #endregion

        #region Public Methods

        /// <summary>
        /// This method adds elements to the binary search tree.
        /// </summary>
        /// <param name="value">Value which will be added.</param>
        public bool Add(T value)
        {
            if (value.Equals(default(T)))
                throw new ArgumentException();

            if (root == null)
            {
                root = new Node(value);
                count++;
                return true;
            }

            if (!Contains(value))
            {
                AddTo(root, value);
                count++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method finds binary search tree's node by given value.
        /// </summary>
        /// <param name="value">Value which one of nodes might contains.</param>
        /// <returns>Returns node if the binary search tree contains this value or null if it not.</returns>
        public Node FindNode(T item)
        {
            int num;
            for (Node node = this.root; node != null; node = (num < 0) ? node.Left : node.Rigth)
            {
                num = this.comparer.Compare(item, node.value);
                if (num == 0)
                    return node;
            }
            return null;
        }

        public bool Contains(T item)
        {
            if (item.Equals(default(T)))
                throw new ArgumentException(nameof(item));

            if (FindNode(item) != null)
                return true;

            return false;
        }

        /// <summary>
        /// Display the data part of the root (or current node). Traverse the left subtree by recursively calling the pre-order function. Traverse the right subtree by recursively calling the pre-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Preorder()
        {
            if (ReferenceEquals(root, null))
                throw new InvalidOperationException("Tree is empty!");

            var nodes = new Stack<Node>();

            Node current = root;

            while (true)
            {
                if (!ReferenceEquals(current, null))
                {
                    yield return current.value;
                    nodes.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (nodes.Count != 0)
                    {
                        current = nodes.Pop().Rigth;
                    }
                    else 
                        yield break;
                }

            }
        }

        /// <summary>
        /// Traverse the left subtree by recursively calling the in-order function. Display the data part of the root (or current node). Traverse the right subtree by recursively calling the in-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Inorder()
        {
            if (ReferenceEquals(root, null))
                throw new InvalidOperationException("Tree is empty!");

            var nodes = new Stack<Node>();

            var current = root;

            bool isDone = false;

            while (!isDone)
            {
                if (!ReferenceEquals(current, null))
                {
                    nodes.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (nodes.Count == 0)
                    {
                        isDone = true;
                    }
                    current = nodes.Pop();
                    yield return current.value;
                    current = current.Rigth;
                }
            }
        }

        /// <summary>
        /// Post-order traversal with recursion. Traverse the left subtree by recursively calling the post-order function. Traverse the right subtree by recursively calling the post-order function. Display the data part of the root (or current node).
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Postorder()
        {
            return PostOrder(root);
        }

        /// <summary>
        /// Returns an enumerator.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private Methods

        private IEnumerable<T> PostOrder(Node root)
        {
            if (ReferenceEquals(root, null))
                yield break;

            if (!ReferenceEquals(root.Left, null))
            {
                foreach (var node in PostOrder(root.Left))
                {
                    yield return node;
                }
            }

            if (!ReferenceEquals(root.Rigth, null))
            {
                foreach (var node in PostOrder(root.Rigth))
                {
                    yield return node;
                }
            }

            yield return root.value;

        }

        private void AddTo(Node node, T value)
        {
            if (comparer.Compare(value, node.value) < 0)
            {
                if (ReferenceEquals(node.Left, null))
                    node.Left = new Node(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (ReferenceEquals(node.Rigth, null))
                    node.Rigth = new Node(value);
                else
                    AddTo(node.Rigth, value);
            }
        }

        #endregion

        #region Inner class

        public class Node
        {
            public T value;

            public Node Rigth { get; set; }

            public Node Left { get; set; }

            public Node(T value)
            {
                this.value = value;
            }

            public Node() : this(default(T)) { }
        }

        #endregion

    }
}
