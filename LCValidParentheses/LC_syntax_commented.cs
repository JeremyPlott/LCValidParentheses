using System.Collections.Generic;

public class Solution
{
    public bool IsValid(string s)
    {
        //we can immediately remove any cases that don't have complete paren sets by using modulus.
        //if it is not divisible by two, throw it out before wasting any effort.
        //this is not required, however.
        if (s.Length % 2 != 0) return false;

        //this dictionary will give us a nice way to link our opening parens with closing parens
        Dictionary<char, char> parenthesesDict = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        //we will store all of our consecutive open parens in this stack
        Stack<char> openParentheses = new Stack<char>();

        //now we will iterate through every character in our input string.
        //if it is an opening paren we will add it to the stack, and if not, we will check
        //if it closes the most recent open paren. If it closes it, we can remove it from the stack.
        foreach (char parentheses in s)
        {
            //first, check if the character is an opening parentheses
            if (parenthesesDict.ContainsKey(parentheses))
            {
                //if it does, we can add it to our opening parentheses stack
                openParentheses.Push(parentheses);
            }
            else
            {
                //if the character is not an opening parentheses:

                //if we have already found an opening paren and the character is the matching
                //closing paren for the one at the top of the stack...
                if (openParentheses.Count != 0 && parenthesesDict[openParentheses.Peek()] == parentheses)
                {
                    //...remove that opening paren from the top of the stack since it has been completed
                    //and continue to the next character in the foreach loop.
                    openParentheses.Pop();
                    continue;
                }

                //if the character isn't an opening paren and we don't have any opening parens yet
                //it cannot be a valid string of parentheses
                return false;
            }
        }

        //if all parens have been closed in the right order, they will have been removed from the stack.
        //as long as that stack is empty, we know it went through successfully.
        return openParentheses.Count == 0;
    }
}