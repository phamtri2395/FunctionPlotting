using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Expression
{
    class ExpressionTree
    {
        #region Class's Fields
        private string _expression;
        private double? _value;
        private List<Tokens> _tokenList = new List<Tokens>();
        private Stack NodeList = new Stack();
        private Stack OperatorList = new Stack();
        enum listPos { Operators, Brackets, Operands, Functions, Variables, Empty };
        #endregion

        private struct Tokens
        {
            private string _value;
            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
            private listPos _type;
            public listPos Type
            {
                get { return _type; }
                set { _type = value; }
            }

            public Tokens(string val, listPos typ)
            {
                this._value = val;
                this._type = typ;
            }
        }

        public ExpressionTree(string Expression)
        {
            this._expression = Expression;
            try
            {
                Correct();
            }
            catch
            {
                MessageBox.Show("Initialize Expression Tree object failed! Can't correct input string", "Initialize Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Correct()
        {
            #region define Token
            string[] Operators = new string[] { "+", "-", "*", "/", "^", "=" };
            string[] Brackets = new string[] { "(", ")", "{", "}" };
            string[] Operands = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] Functions = new string[] { "s", "i", "n", "c", "o", "t", "a", "b" };
            string[] Variables = new string[] { "x", "y" };
            #endregion

            int startIndex = 0;
            int endIndex = 0;
            listPos currentList = new listPos();
            currentList = listPos.Empty;

            for (int i = 0; i < _expression.Length; i++)
            {
                #region currentList != Empty
                if (currentList != listPos.Empty)
                {
                    if (currentList == listPos.Functions)
                        if (Functions.Contains(_expression[i].ToString()))
                            endIndex = i;
                        else
                        {
                            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
                            currentList = listPos.Empty;
                        }
                   
                    if (currentList == listPos.Operands)
                        if (Operands.Contains(_expression[i].ToString()))
                            endIndex = i;
                        else
                        {
                            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
                            currentList = listPos.Empty;
                        }

                    if (currentList == listPos.Operators)
                        if (Operators.Contains(_expression[i].ToString()))
                            endIndex = i;
                        else
                        {
                            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
                            currentList = listPos.Empty;
                        }

                    if (currentList == listPos.Brackets)
                        if (Brackets.Contains(_expression[i].ToString()))
                            endIndex = i;
                        else
                        {
                            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
                            currentList = listPos.Empty;
                        }

                    if (currentList == listPos.Variables)
                        if (Variables.Contains(_expression[i].ToString()))
                            endIndex = i;
                        else
                        {
                            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
                            currentList = listPos.Empty;
                        }
                }
                #endregion

                #region currentList == Empty
                if (currentList == listPos.Empty)
                {
                    startIndex = i;
                    if (Functions.Contains(_expression[i].ToString()))
                        currentList = listPos.Functions;

                    if (Operands.Contains(_expression[i].ToString()))
                        currentList = listPos.Operands;

                    if (Operators.Contains(_expression[i].ToString()))
                        currentList = listPos.Operators;
                    if (Brackets.Contains(_expression[i].ToString()))
                        currentList = listPos.Brackets;
                    if (Variables.Contains(_expression[i].ToString()))
                        currentList = listPos.Variables;
                    if (currentList != listPos.Empty)
                        i -= 1;
                    else { }
                }
                #endregion
            }

            _tokenList.Add(new Tokens(_expression.Substring(startIndex, endIndex - startIndex + 1), currentList));
        }
        private int GetPriority(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }
        private void CreateNode()
        {
            Node _node = new Node((string)OperatorList.Pop());

            if (NodeList.Count != 0)
                _node.LeftNode = (Node)NodeList.Pop();
            else
                _node.LeftNode = null;
            if (NodeList.Count != 0)
                _node.RightNode = (Node)NodeList.Pop();
            else
                _node.RightNode = null;

            NodeList.Push(_node);
        }
        private double? GetValue(Node _node)
        {
            if (_node.isLeaf())
                return double.Parse(_node.Value);
            else 
            {
                if (_node.Value == "+")
                    return GetValue(_node.RightNode) + GetValue(_node.LeftNode);
                if (_node.Value == "-")
                    return GetValue(_node.RightNode) - GetValue(_node.LeftNode);
                if (_node.Value == "*")
                    return GetValue(_node.RightNode) * GetValue(_node.LeftNode);
                if (_node.Value == "/")
                    return GetValue(_node.RightNode) / GetValue(_node.LeftNode);
                if (_node.Value == "^")
                {
                    double? power = 1.0;
                    for (int i = 1; i <= GetValue(_node.LeftNode).Value; i++)
                    {
                        power *= GetValue(_node.RightNode).Value;
                    }
                    return power;
                }
            }
            return null;
        }

        public void CreateTree()
        {
            #region Loop for each Token
            foreach (Tokens str in _tokenList)
            {
                if (str.Value == "(")
                {
                    OperatorList.Push(str.Value);
                }

                if (str.Value == ")")
                {
                    while (OperatorList.Peek().ToString() != "(")
                    {
                        CreateNode();
                    }
                    OperatorList.Pop();
                }

                if (str.Type == listPos.Operands)
                {
                    Node _node = new Node(str.Value);
                    NodeList.Push(_node);
                }

                if (str.Type == listPos.Operators)
                {
                    while ((OperatorList.Count != 0) && (GetPriority(OperatorList.Peek().ToString()) >= GetPriority(str.Value)))
                    {
                        CreateNode();
                    }
                    OperatorList.Push(str.Value);
                }
            }
            #endregion

            #region End-Loop check if OperatorList != 0
            while (OperatorList.Count != 0)
            {
                CreateNode();
            }
            #endregion

            #region get Expression Tree's value
            _value = GetValue((Node)NodeList.Peek());
            #endregion
        }
        public double? Value
        {
            get { return this._value; }
        }
    }
}
