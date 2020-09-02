using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExc
{
   // Definition for a binary tree node.
   public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class BinaryTreeTraversal : IRunnable
    {
        IList<IList<int>> traversal = new List<IList<int>>();
        
        public void Run()
        {
            var root = new TreeNode(2);
            LevelOrderBottom(root);
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            AddStep(root, 1);
            return traversal;
        }

        private void AddStep(TreeNode node, int level)
        {
            if (node == null)
                return;

            if (traversal.Count < level)
                traversal.Insert(0, new List<int>());

            traversal[traversal.Count - level].Add(node.val);

            if (node.left != null)
                AddStep(node.left, level + 1);

            if (node.right != null)
                AddStep(node.right, level + 1);
        }
    }
}
