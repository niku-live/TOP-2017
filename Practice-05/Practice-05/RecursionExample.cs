using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_05
{
  public class RecursionExample
  {

    public int GetNthFibonacciIteration(int n)
    {

      int number = n - 1; //Need to decrement by 1 since we are starting from 0
      int[] Fib = new int[number + 1];
      Fib[0] = 0;
      Fib[1] = 1;
      for (int i = 2; i <= number; i++)
      {
        Fib[i] = Fib[i - 2] + Fib[i - 1];
      }
      return Fib[number];
    }

    public int GetNthFibonacciRecursion(int n)
    {
      if ((n == 0) || (n == 1))
      {
        return n;
      }

      else
      {
        return GetNthFibonacciRecursion(n - 1) + GetNthFibonacciRecursion(n - 2);
      }
    }

    public void RunExample()
    {
      Console.WriteLine(GetNthFibonacciIteration(10));
      Console.WriteLine(GetNthFibonacciRecursion(10));
    }
  }
}
