public static class ComplexStack {
    /// <summary>
    /// Validates that all brackets/parentheses/braces in a string are properly matched and balanced.
    /// Uses a stack to track opening brackets and verify they match their closing counterparts.
    /// 
    /// Examples:
    /// - "()" -> true (balanced)
    /// - "([{}])" -> true (balanced)
    /// - "([)]" -> false (mismatched closing brackets)
    /// - "(((" -> false (unclosed opening brackets)
    /// </summary>
    /// <param name="line">The string to validate</param>
    /// <returns>True if all brackets are properly matched, false otherwise</returns>
    public static bool DoSomethingComplicated(string line) {
        // Create a stack to store opening brackets
        var stack = new Stack<char>();
        
        // Iterate through each character in the input string
        foreach (var item in line) {
            // If we encounter an opening bracket, push it onto the stack
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            // If we encounter a closing parenthesis
            else if (item is ')') {
                // Check if stack is empty OR the most recent opening bracket is not a '('
                // If either condition is true, the brackets are mismatched
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            // If we encounter a closing square bracket
            else if (item is ']') {
                // Check if stack is empty OR the most recent opening bracket is not a '['
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            // If we encounter a closing curly brace
            else if (item is '}') {
                // Check if stack is empty OR the most recent opening bracket is not a '{'
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
            // All other characters (letters, numbers, etc.) are ignored
        }

        // At the end, the stack should be empty. If it still has items,
        // there are unclosed opening brackets, so return false.
        // Return true only if all brackets were matched and stack is empty.
        return stack.Count == 0;
    }
}