using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class TreeNode<TNode> : IComparable<TNode> where TNode : IComparable 
    {
        Tree<TNode> _tree;

        TreeNode<TNode> _left;
        TreeNode<TNode> _right;

        public TreeNode(TNode value, TreeNode<TNode> parent, Tree<TNode> tree)
        {
            Value = value;
            Parent = parent;
            _tree = tree;
        }

        public TreeNode<TNode> Left
        {
            get
            {
                return _left;
            }
            internal set
            {
                _left = value;
                if (_left != null)
                {
                    _left.Parent = this;
                }
            }
        }

        public TreeNode<TNode> Right
        {
            get
            {
                return _right;
            }
            internal set
            {
                _right = value;
                if (_right != null)
                {
                    _right.Parent = this;
                }
            }
        }

        public TreeNode<TNode> Parent
        {
            get;
            internal set;
        }

        public TNode Value
        {
            get;
            internal set;
        }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
        internal  void Balance()
       {
             if(State == TreeState.RightHeavy)
             {
                if(Right != null && Right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
             }
            else if(State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
       }

        private  int MaxChildHeight(TreeNode<TNode> node)
        {
            if(node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }

        private int LeftHeight
        {
            get
            {
                return MaxChildHeight(Left);
            }
        }

        private int RightHeight
        {
            get
            {
                return MaxChildHeight(Right);
            }
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }
                return TreeState.Balanced;
            }

        }

        private int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }
        enum TreeState
        {
            Balanced,
            LeftHeavy,
            RightHeavy,
        }


        private void LeftRotation()
        {
            TreeNode<TNode> newRoot = Right;
            ReplaceRoot(newRoot);

            Right = newRoot.Left;

            newRoot.Left = this;
        }

        private void RightRotation()
        {
            TreeNode<TNode> newRoot = Left;
            ReplaceRoot(newRoot);

            Left = newRoot.Right;

            newRoot.Right = this;
        }

        private void LeftRightRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }
        private void ReplaceRoot(TreeNode<TNode> newRoot)
        {
            if(this.Parent != null)
            {
                if(this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                else if(this.Parent.Right == this)
                {
                    this.Parent.Right = newRoot;
                }
            }
            else
            {
                _tree.Head = newRoot;
            }

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
        }
       
    }
}
