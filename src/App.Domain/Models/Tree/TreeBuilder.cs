using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models.Tree
{
    public class TreeBuilder
    {
        public static TreeNode<T> Build<T>(ICollection<T> items) where T : INode
        {
            var map = new Dictionary<int, TreeNode<T>>();
            TreeNode<T> root = null;

            foreach (var item in items)
            {
                var node = new TreeNode<T>(item);
                var parent = node.GetParentId();

                if (parent == null)
                {
                    root = node;
                }
                else if (map.ContainsKey(parent.Value))
                {
                    map[parent.Value].AddChild(node);
                }

                map.Add(item.Id, node);
            }

            return root;
        }
    }
}
