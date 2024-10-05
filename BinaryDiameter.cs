using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets
{
    public class BinaryDiameter
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            var (left, right, max) = Auxiliary(root);
            var rs = Math.Max(left + right, max);
            Console.WriteLine("rs is: " + rs);
            return rs;
        }
        private (int left, int right, int max) Auxiliary(TreeNode root)
        {
            if (root.left == null && root.right == null) return (0, 0, 0);
            if (root.left != null && root.right == null)
            {
                var leftRs0 = Auxiliary(root.left);
                var rs = 1 + Math.Max(leftRs0.left, leftRs0.right);
                return (rs, 0, leftRs0.max);
            }
            if (root.left == null && root.right != null)
            {
                var rightRs0 = Auxiliary(root.right);
                var rs = 1 + Math.Max(rightRs0.left, rightRs0.right);
                return (0, rs, rightRs0.max);
            }
            var leftRs = Auxiliary(root.left);
            var rsLeft = Math.Max(leftRs.left, leftRs.right);
            var left = 1 + rsLeft;
            var rightRs = Auxiliary(root.right);
            var rsRight = Math.Max(rightRs.left, rightRs.right);
            var right = 1 + rsRight;
            var max = Math.Max(Math.Max(leftRs.max, rightRs.max), left + right);
            return (left, right, max);
        }
    }
}
