using System;
using System.Collections.Generic;

namespace LCValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "){";

            Dictionary<char, char> parenthesesDict = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            Console.WriteLine(IsValid(s));

            bool IsValid(string s)
            {
                if (s.Length % 2 != 0) return false;

                Stack<char> openParentheses = new Stack<char>();

                foreach (char parentheses in s)
                {
                    if (parenthesesDict.ContainsKey(parentheses))
                    {
                        openParentheses.Push(parentheses);                     
                    } 
                    else
                    {
                        if (openParentheses.Count != 0 && parenthesesDict[openParentheses.Peek()] == parentheses)
                        {
                            openParentheses.Pop();
                            continue;
                        }

                        return false;
                    }
                }
                
                return openParentheses.Count == 0;
            }
        }
    }
}
