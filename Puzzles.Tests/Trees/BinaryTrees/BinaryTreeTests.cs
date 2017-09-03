using FluentAssertions;
using Puzzles.Exercises.Trees.BinaryTrees;
using Xunit;

namespace Puzzles.Tests.Trees.BinaryTrees
{
    public class BinaryTreeTests
    {
        [Fact]
        public void LeftMost_IsRootIfRootHasNoLeftChild()
        {
            // ARRANGE
            var root = new Node<int>(1, null, new Node<int>(3));

            // SUT
            var tree = new BinaryTree<int>(root);

            // ACT & ASSERT
            tree.LeftMost.Should().Be(root);
        }

        [Fact]
        public void LeftMost_IsLeftMostNodeOfTree()
        {
            // ARRANGE
            var leftMost = new Node<int>(4);

            var root = new Node<int>(
                1,
                new Node<int>(2,
                    leftMost,
                    new Node<int>(5,
                        null,
                        new Node<int>(8))
                ),
                new Node<int>(3,
                    new Node<int>(6),
                    new Node<int>(7, new Node<int>(9), null)
                ));

            // SUT
            var tree = new BinaryTree<int>(root);

            // ACT & ASSERT
            tree.LeftMost.Should().Be(leftMost);
        }

        [Fact]
        public void InOrderTraversal_ReturnsLeftSubtreeJoinedWithRootAndThenRightSubtree()
        {
            // ARRANGE
            var inOrderTraversalValues = new[]
            {
                4, 2, 5, 8, 1, 6, 3, 9, 7
            };

            var root = new Node<int>(
                1,
                new Node<int>(2,
                    new Node<int>(4),
                    new Node<int>(5,
                        null,
                        new Node<int>(8))
                ),
                new Node<int>(3,
                    new Node<int>(6),
                    new Node<int>(7, new Node<int>(9), null)
                ));

            // SUT
            var tree = new BinaryTree<int>(root);

            // ACT
            var actualTraversal = tree.TraverseInOrder();

            // ASSERT
            actualTraversal.ShouldAllBeEquivalentTo(inOrderTraversalValues, o => o.WithStrictOrdering());
        }

        [Fact]
        public void PostOrderTraversal_ReturnsLeftSubtreeJoinedWithRightSubtreeAndThenRoot()
        {
            // ARRANGE
            var postOrderTraversalValues = new[]
            {
                4, 8, 5, 2, 6, 9, 7, 3, 1
            };

            var root = new Node<int>(
                1,
                new Node<int>(2,
                    new Node<int>(4),
                    new Node<int>(5,
                        null,
                        new Node<int>(8))
                ),
                new Node<int>(3,
                    new Node<int>(6),
                    new Node<int>(7, new Node<int>(9), null)
                ));

            // SUT
            var tree = new BinaryTree<int>(root);

            // ACT
            var actualTraversal = tree.TraversePostOrder();

            // ASSERT
            actualTraversal.ShouldAllBeEquivalentTo(postOrderTraversalValues, o => o.WithStrictOrdering());
        }

        [Fact]
        public void PreOrderTraversal_ReturnsRootJoinedWithLeftSubtreeAndRightSubtree()
        {
            // ARRANGE
            var preOrderTraversalValues = new[]
            {
                1, 2, 4, 5, 8, 3, 6, 7, 9
            };

            var root = new Node<int>(
                1,
                new Node<int>(2,
                    new Node<int>(4),
                    new Node<int>(5,
                        null,
                        new Node<int>(8))
                ),
                new Node<int>(3,
                    new Node<int>(6),
                    new Node<int>(7, new Node<int>(9), null)
                ));

            // SUT
            var tree = new BinaryTree<int>(root);

            // ACT
            var actualTraversal = tree.TraversePreOrder();

            // ASSERT
            actualTraversal.ShouldBeEquivalentTo(preOrderTraversalValues, o => o.WithStrictOrdering());
        }
    }
}