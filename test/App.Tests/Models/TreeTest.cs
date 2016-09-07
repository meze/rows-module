using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities.Navigation;
using App.Domain.Models.Tree;
using Xunit;

namespace App.Tests.Models
{
    public class TreeTest
    {
        [Fact]
        public void CreatesTree()
        {
            var root = new TreeNode<SimpleNode>(new SimpleNode("root"));
            var childNode = root.AddChild(new TreeNode<SimpleNode>(new SimpleNode("child1")));
            childNode.AddChild(new TreeNode<SimpleNode>(new SimpleNode("subchild2")));

            Assert.Equal(3, root.Count());
        }

        [Fact]
        public void SetsFullPath()
        {
            var root = new TreeNode<SimpleNode>(new SimpleNode("root") { Id = 1 });
            var childNode = root.AddChild(new TreeNode<SimpleNode>(new SimpleNode("child1") { Id = 2 }));
            var lastChild = childNode.AddChild(new TreeNode<SimpleNode>(new SimpleNode("subchild2") { Id = 3 }));

            Assert.Equal("/1", childNode.Item.Path);
            Assert.Equal("/1/2", lastChild.Item.Path);
        }

        [Fact]
        public void ReturnsParentId()
        {
            var tree = new TreeNode<SimpleNode>(new SimpleNode("root") { Path = "/1/3/4" });
            Assert.Equal(4, tree.GetParentId());
        }

        [Fact]
        public void ReturnsWhetherNodeIsRoot()
        {
            var root = new TreeNode<SimpleNode>(new SimpleNode("root"));
            var childNode = root.AddChild(new TreeNode<SimpleNode>(new SimpleNode("child1")));

            Assert.True(root.IsRoot());
            Assert.False(childNode.IsRoot());
        }

        [Fact]
        public void ReturnsNullForParentIfItIsRoot()
        {
            var tree = new TreeNode<SimpleNode>(new SimpleNode("root") { Path = "/" });
            Assert.Null(tree.GetParentId());
        }

        [Fact]
        public void FindNodeByPath()
        {
            var items = new[] {
                new MenuItem { Path = "/", Id = 1 },
                new MenuItem { Path = "/1", Id = 2 },
                new MenuItem { Path = "/1/2", Id = 3 }
            };
            var root = TreeBuilder.Build(new List<MenuItem>(items));

            Assert.Equal("/1", root.FindChildById(2).Item.Path);
            Assert.Equal("/1/2", root.FindChildById(3).Item.Path);
        }

        [Fact]
        public void ChangesPathWhenNodeIsMovedToRoot()
        {
            var items = new[] {
                new MenuItem { Path = "/", Id = 1 },
                new MenuItem { Path = "/1", Id = 2 },
                new MenuItem { Path = "/1/2", Id = 3 },
                new MenuItem { Path = "/1/2/3", Id = 4 }
            };
            var root = TreeBuilder.Build(new List<MenuItem>(items));

            var movedNode = root.FindChildById(3);
            var movedNodeChild = root.FindChildById(4);

            movedNode.MoveTo(root);

            Assert.Equal("/1", movedNode.GetPath());
            Assert.Equal("/1/3", movedNodeChild.GetPath());
        }

        [Fact]
        public void ChangesPathWhenNodeIsMovedToAnotherNode()
        {
            var items = new[] {
                new MenuItem { Path = "/", Id = 1 },
                new MenuItem { Path = "/1", Id = 2 },
                new MenuItem { Path = "/1", Id = 3 },
                new MenuItem { Path = "/1/3", Id = 4 },
            };
            var root = TreeBuilder.Build(new List<MenuItem>(items));

            var movedNode = root.FindChildById(3);
            var movedNodeChild = root.FindChildById(4);

            movedNode.MoveTo(root.FindChildById(2));

            Assert.Equal("/1/2", movedNode.GetPath());
            Assert.Equal("/1/2/3", movedNodeChild.GetPath());
        }

        [Fact]
        public void SetsCorrectPath()
        {
            var items = new[] {
                new MenuItem { Path = "/", Id = 1, Menu = new Menu { Id = 1 }},
                new MenuItem { Path = "/1", Id = 2, Menu = new Menu { Id = 1 }}
            };

            var root = TreeBuilder.Build(new List<MenuItem>(items));

            Assert.Equal("/1", root.GetChildren().ElementAt(0).Item.Path);
        }
    }

    internal class SimpleNode : INode
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Value { get; set; }

        public SimpleNode(string value)
        {
            Value = value;
            Path = "/";
        }
    }
}