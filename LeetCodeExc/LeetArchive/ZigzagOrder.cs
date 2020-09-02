using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc.Zigzag
{
    public class ZigzagOrder : IRunnable
    {
        public void Run()
        {

        }

        private void RunWith()
        {

        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var items = new List<IList<int>>();

            if (root == null)
                return items;

            ProcessNode(root, 0, items);

            for(var level = 0; level < items.Count; level++)
            {
                if(level %2 == 1)
                    items[level] = items[level].Reverse().ToList();
            }

            return items;
        }

        private void ProcessNode(TreeNode node, int level, IList<IList<int>> items)
        {
            if (items.Count <= level)
                items.Add(new List<int>());

            items[level].Add(node.val);

            if (node.left != null)
                ProcessNode(node.left, level + 1, items);

            if (node.right != null)
                ProcessNode(node.right, level + 1, items);
        }
    }

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
    }

}
