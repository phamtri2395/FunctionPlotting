using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        private string _value;
        public string Value
        {
            get { return _value; }
        }

        public Node(string Value, Node Left = null, Node Right = null)
        {
            this._value = Value;
            this.LeftNode = Left;
            this.RightNode = Right;
        }

        public bool isLeaf()
        {
            return ((LeftNode == null) && (RightNode == null));
        }
    }
}
