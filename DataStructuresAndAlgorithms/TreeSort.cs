using System;

namespace DataStructuresAndAlgorithms
{
    public class TreeSort : AbstractSort
    {
        private class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private TreeNode root;

        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            root = null;

            // Build BST
            foreach (int value in a)
            {
                Insert(value);
            }

            // In-order traversal to get sorted array
            int index = 0;
            InOrderTraversal(root, a, ref index);
        }

        private void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private TreeNode InsertRec(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value <= node.Value)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else
            {
                node.Right = InsertRec(node.Right, value);
            }

            return node;
        }

        private void InOrderTraversal(TreeNode node, int[] arr, ref int index)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, arr, ref index);
                arr[index++] = node.Value;
                InOrderTraversal(node.Right, arr, ref index);
            }
        }
    }
}