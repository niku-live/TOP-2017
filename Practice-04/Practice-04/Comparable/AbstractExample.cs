using System;
using System.Collections.Generic;

namespace Practice_04.Comparable
{
  public abstract class AbstractExample
  {
    public void PrintList<T>(List<T> data)
    {
      Console.WriteLine("----->");
      foreach (var item in data)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine("<-----");
    }

    public void SortingExample<T>(List<T> data)
    {
      Console.WriteLine("Unsorted:");
      PrintList(data);
      data.Sort();
      Console.WriteLine("Sorted:");
      PrintList(data);
    }

    public abstract void RunExample();
  }
}
