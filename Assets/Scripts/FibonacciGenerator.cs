public static class FibonacciGenerator
{
    /// <summary>
    /// Returns the n-th Fibonacci number using recursion.
    /// F(0) = 0, F(1) = 1, F(n) = F(n-1) + F(n-2).
    /// </summary>
    private static int Fibonacci(int n)
    {
        if (n < 2)
            return n;
        
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /// <summary>
    /// Generates the Fibonacci sequence up to 'steps' elements and returns it as an array.
    /// </summary>
    public static int[] GenerateFibonacciSequence(int steps)
    {
        var sequence = new int[steps];
        
        for (var i = 0; i < steps; i++)
            sequence[i] = Fibonacci(i);
        
        return sequence;
    }
}