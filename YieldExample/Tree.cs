using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YieldExample
{
    public class Tree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public TItem CurrentValue { get; set; }
        public Tree<TItem> LeftTree { get; set; }
        public Tree<TItem> RightTree { get; set; }

        public Tree(TItem nodeValue)
        {
            this.CurrentValue = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }

        public void Insert(TItem newItem)
        {
            if (CurrentValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        public void WalkTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.WalkTree();
            }

            Console.WriteLine(this.CurrentValue.ToString());

            if (this.RightTree != null)
            {
                this.RightTree.WalkTree();
            }
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
                foreach (TItem item in this.LeftTree)
                {
                    yield return item;
                }
            }

            yield return this.CurrentValue;

            if (this.RightTree != null)
            {
                foreach (TItem item in this.RightTree)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() //remember to implement interface on explicit way.
        {
            throw new NotImplementedException();
        }
    }
}
