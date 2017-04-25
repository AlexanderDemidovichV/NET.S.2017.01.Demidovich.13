using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public sealed class BinaryTree<T>: IEnumerable<T>, IEnumerable
    {

        #region Private Fields

        private Node root;

        private int count;

        private IComparer<T> comparer;

        #endregion

        #region Constructors

        public BinaryTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            root = null;
            count = 0;
            this.comparer = comparer;
        }

        public BinaryTree() : this(Comparer<T>.Default) { }

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return count;
            }
        }

        #endregion

        #region Public Methods

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

        public IEnumerable<T> Postorder()
        {
            return PostOrder(root);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }

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
