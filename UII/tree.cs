using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UII;

namespace UII
{
    class tree
    {
        private int data;
        private tree Left;
        private tree right;
        bool isroot;

        public tree(int data, tree leftnode=null, tree rightnode=null)
        {
            this.data = data;
            this.Left = leftnode;
            this.right = rightnode;
        }

        
        public tree getnode()
        {
            return this;
        }
        
        public int GetValue()
        {
            return data;
        }
        public tree leftnode
        { get { return Left; } set { Left = value; } }
        public tree rightnode
        { get { return right; } set { right = value; } }
    }
}
