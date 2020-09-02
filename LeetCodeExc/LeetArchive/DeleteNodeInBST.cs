using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class DeleteNodeInBST : IRunnable
    {
        public void Run()
        {
            RunWith(0);
        }

        private void RunWith(int input)
        {
            //var result = DeleteNode(input);
            //Logger.LogLine($"Input: {input}");
            //Logger.LogLine($"Result: {result}");
        }

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return root;

            if (root.val > key)
                root.left = DeleteNode(root.left, key);
            else if (root.val < key)
                root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.val = MinValue(root.right);
                root.right = DeleteNode(root.right, root.val);
            }

            return root;
        }

        private int MinValue(TreeNode root)
        {
            while(root.left != null)
                root = root.left;

            return root.val;
        }
    }
}
