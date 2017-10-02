using System;
using System.Collections.Generic;

namespace Practice_04.Comparer
{
  public class Example1: Comparable.Example4
  {
    public class CompareOnlyReal : IComparer<ComplexNumber>
    {
      public int Compare(ComplexNumber x, ComplexNumber y)
      {
        return x.Real.CompareTo(y.Real);
      }
    }

    public class CompareOnlyImaginary : IComparer<ComplexNumber>
    {
      public int Compare(ComplexNumber x, ComplexNumber y)
      {
        return x.Imaginary.CompareTo(y.Imaginary);
      }
    }

    public class CompareWithOrder : IComparer<ComplexNumber>
    {
      public bool Descending { get; set; }
      public CompareWithOrder(bool descending) { Descending = descending; }

      public int Compare(ComplexNumber x, ComplexNumber y)
      {
        int result = x.CompareTo(y);
        return Descending ? -result : result;
      }
    }

    public override void RunExample()
    {
      List<ComplexNumber> numbers = new List<ComplexNumber>()
      {
        new ComplexNumber(0, 1),
        new ComplexNumber(0, 4),
        new ComplexNumber(1, 0),
        new ComplexNumber(1, 2),
        new ComplexNumber(0, 2),
        new ComplexNumber(-1, 0)
      };
      Console.WriteLine("Original");
      PrintList(numbers);

      numbers.Sort(new CompareOnlyReal());
      Console.WriteLine("Only real comparison");
      PrintList(numbers);
      numbers.Sort(new CompareOnlyImaginary());
      Console.WriteLine("Only imaginary comparison");
      PrintList(numbers);
      numbers.Sort(new CompareWithOrder(true));
      Console.WriteLine("Descending");
      PrintList(numbers);
      numbers.Sort(new CompareWithOrder(false));
      Console.WriteLine("Ascending");
      PrintList(numbers);
      numbers.Sort();
      Console.WriteLine("Normal sort");
      PrintList(numbers);
    }
  }
}
