using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = LeetCodeExc.PathSum3.TreeNode;

namespace LeetCodeExc
{
    public class PathSum3 : IRunnable
    {
        public void Run()
        {
            // RunWith(new int?[] {10, 5, -3, 3, 2, null, 11, 3, -2, null, 1}, 8);

            RunWith(new int?[] { 1, null, 2, null, null, null, 3, null, 4, null, 5 }, 3);
            // RunWith(new int?[] { 1, null, 2, null, 3, null, 4, null, 5 }, 3);
        }

        private void RunWith(int?[] input, int sum)
        {
            var root = BuildTree(input);
            var result = PathSum(root, sum);

            var convInput = input.Select(n => n.HasValue ? n.Value.ToString() : "null");
            Logger.LogLine($"Input: [{string.Join(',', convInput)}] ## SumOf({sum})");
            Logger.LogLine($"Result: {result}");
        }

        private TreeNode BuildTree(int?[] input)
        {
            var root = new TreeNode(input[0].Value);
            AddLeaves(root, input, 1, 0);
            return root;
        }

        private void AddLeaves(TreeNode current, int?[] input, int level, int num)
        {
            var inputIndex = (int)Math.Pow(2, level) - 1 + num;
            if (input.Length < inputIndex + 1)
                return;

            if (input[inputIndex] != null)
            {
                current.left = new TreeNode(input[inputIndex].Value);
                AddLeaves(current.left, input, level + 1, num);
            }

            if (input[inputIndex + 1] != null)
            {
                current.right = new TreeNode(input[inputIndex + 1].Value);
                AddLeaves(current.right, input, level + 1, num + 2);
            }
        }

        public int PathSum(TreeNode root, int sum)
        {
            var sumCount = 0;
            CalcSum(root, sum, 0, ref sumCount);
            return sumCount;
        }

        private void CalcSum(TreeNode current, int targetSum, int currSum, ref int sumCount)
        {
            if (current == null)
                return;

            currSum += current.val;

            if (currSum == targetSum)
            {
                sumCount++;
                return;
            }
            else
            {
                CalcSum(current.left, targetSum, currSum, ref sumCount);
                CalcSum(current.right, targetSum, currSum, ref sumCount);
            }

            CalcSum(current.left, targetSum, 0, ref sumCount);
            CalcSum(current.right, targetSum, 0, ref sumCount);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;

            }

            public override string ToString()
            {
                return $"[{val}]";
            }
        }
    }
}
