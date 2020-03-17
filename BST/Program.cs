using System;
using System.Collections.Generic;

namespace BST
{
	class Program
	{
		static void Main(string[] args)
		{
			var bst = new BinarySearchTree();
			bst.Insert(9);
			bst.Insert(4);
			bst.Insert(20);
			bst.Insert(1);
			bst.Insert(6);
			bst.Insert(15);
			bst.Insert(150);
			var result = bst.BreathFirstSearchR();
		}
	}

	class BinarySearchTree
	{
		public BinarySearchTreeNode Root { get; set; }

		public void Insert(int value)
		{
			if (Root == null)
			{
				Root = new BinarySearchTreeNode(value);
				return;
			}

			var currentNode = Root;
			while (currentNode != null)
			{
				if (value > currentNode.Value)
				{
					if (currentNode.RightNode == null)
					{
						currentNode.RightNode = new BinarySearchTreeNode(value);
						return;
					}

					currentNode = currentNode.RightNode;
				}
				else
				{
					if (currentNode.LeftNode == null)
					{
						currentNode.LeftNode = new BinarySearchTreeNode(value);
						return;
					}

					currentNode = currentNode.LeftNode;
				}
			}


		}

		public BinarySearchTreeNode Lookup(int value)
		{
			if (Root == null) return null;

			var currentNode = Root;
			while (currentNode != null)
			{
				if (currentNode.Value == value)
				{
					return currentNode;
				} else if (value > currentNode.Value && currentNode.RightNode != null)
				{
					currentNode = currentNode.RightNode;
				} else if (value < currentNode.Value && currentNode.LeftNode != null)
				{
					currentNode = currentNode.LeftNode;
				}
			}

			return null;
		}

		public (BinarySearchTreeNode node, BinarySearchTreeNode parent) LookupWithParent(int value)
		{
			if (Root == null) return (null, null);

			var currentNode = Root;
			BinarySearchTreeNode parentNode = null;
			while (currentNode != null)
			{
				if (currentNode.Value == value)
				{
					return (currentNode, parentNode);
				}
				else if (value > currentNode.Value && currentNode.RightNode != null)
				{
					parentNode = currentNode;
					currentNode = currentNode.RightNode;
				}
				else if (value < currentNode.Value && currentNode.LeftNode != null)
				{
					parentNode = currentNode;
					currentNode = currentNode.LeftNode;
				}
			}

			return (null, null);
		}

		public void Remove(int value)
		{
			var (targetNode, parentNode) = LookupWithParent(value);

			if (targetNode == null)
			{
				return;
			}

			if (targetNode.LeftNode == null && targetNode.RightNode == null)
			{
				ReplaceNode(parentNode, targetNode, null);
			}
			else if (targetNode.LeftNode == null || targetNode.RightNode == null)
			{
				ReplaceNode(parentNode, targetNode, targetNode.LeftNode ?? targetNode.RightNode);
			}
			else
			{
				var smallestSuccessor = FindSmallestSuccessor(targetNode.RightNode);
				smallestSuccessor.parent.LeftNode = smallestSuccessor.target.RightNode;

				smallestSuccessor.target.LeftNode = targetNode.LeftNode;
				smallestSuccessor.target.RightNode = targetNode.RightNode;
				ReplaceNode(parentNode, targetNode, smallestSuccessor.target);
			}

		}

		public int[] BreathFirstSearch()
		{
			var result = new List<int>();
			var queue = new Queue<BinarySearchTreeNode>();
			queue.Enqueue(Root);

			while (queue.Count > 0)
			{
				var currentNode = queue.Dequeue();
				result.Add(currentNode.Value);
				if (currentNode.LeftNode != null)
				{
					queue.Enqueue(currentNode.LeftNode);
				}

				if (currentNode.RightNode != null)
				{
					queue.Enqueue(currentNode.RightNode);
				}
			}

			return result.ToArray();
		}

		public int[] BreathFirstSearchR()
		{
			var result = new List<int>();
			BreathFirstSearchRP(Root, result);
			return result.ToArray();
		}

		private void BreathFirstSearchRP(BinarySearchTreeNode node, List<int> result)
		{
			result.Add(node.Value);

			if (node.LeftNode != null)
			{
				BreathFirstSearchRP(node.LeftNode, result);
			}

			if (node.RightNode != null)
			{
				BreathFirstSearchRP(node.RightNode, result);
			}
		}

		private void ReplaceNode(BinarySearchTreeNode parentNode, BinarySearchTreeNode targetNode, BinarySearchTreeNode newNode)
		{
			if (parentNode.LeftNode == targetNode)
			{
				parentNode.LeftNode = newNode;
			}
			else
			{
				parentNode.RightNode = newNode;
			}
		}

		private (BinarySearchTreeNode target, BinarySearchTreeNode parent) FindSmallestSuccessor(BinarySearchTreeNode node)
		{
			var currentNode = node;
			BinarySearchTreeNode parentNode = null;
			while (true)
			{
				if (currentNode.LeftNode == null)
				{
					break;
				}

				parentNode = currentNode;
				currentNode = currentNode.LeftNode;
			}

			return (currentNode, parentNode);
		}
	}

	class BinarySearchTreeNode
	{
		public BinarySearchTreeNode(int value)
		{
			Value = value;
		}
		public int Value { get; set; }
		public BinarySearchTreeNode LeftNode { get; set; }
		public BinarySearchTreeNode RightNode { get; set; }
	}

}
