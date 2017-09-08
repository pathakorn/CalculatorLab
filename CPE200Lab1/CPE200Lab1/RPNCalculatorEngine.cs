using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }


        public string Process (string str)

        {
            string result;
                Stack<string> rpnStack = new Stack<string>();
                string[] parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]) == true)
                {
                    string second = Convert.ToString(rpnStack.Pop());
                    string first = Convert.ToString(rpnStack.Pop());
                    rpnStack.Push(calculate(parts[i], first, second));
                }
                else
                {
                    
                    rpnStack.Push(parts[i]);
                }
                   
                }return Convert.ToString(rpnStack.Pop());
            }         
            
           //split str to parts
            //loop each part
            //if part is number
            //push to stack
            //if part is operator
            // pop two times => second, first operand
            //calculate (operator, first,second) => result
            //push result to stack
            //return result
           
        }

    }

