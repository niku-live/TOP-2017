using System;
using System.Collections.Generic;

namespace Practice_04.Comparable
{
  public class Example4: AbstractExample
  {
    public class ComplexNumber : Example1.ComplexNumber, IComparable<ComplexNumber>, IComparable<int>, IComparable
    {
      public ComplexNumber(int real, int imaginary) : base(real, imaginary) { }

      public int CompareTo(ComplexNumber other)
      {
        int result = Real.CompareTo(other.Real);
        if (result != 0)
        {
          return result;
        }
        result = Imaginary.CompareTo(other.Imaginary);
        return result;
      }

      public int CompareTo(int other)
      {
        return CompareTo(new ComplexNumber(other, 0));
      }

      public int CompareTo(object obj)
      {
        if (obj is ComplexNumber)
        {
          return CompareTo((ComplexNumber)obj);
        }

        if (obj is int)
        {
          return CompareTo((int)obj);
        }

        throw new ArgumentException("Object is not complex number");
      }

    }

    public override void RunExample()
    {
      List<ComplexNumber> numbers = new List<ComplexNumber>()
      {
        new ComplexNumber(0, 1),
        new ComplexNumber(0, 2),
        new ComplexNumber(1, 0),
        new ComplexNumber(1, 2),
        new ComplexNumber(0, 4),
        new ComplexNumber(-1, 0)
      };
      SortingExample(numbers);

      var number1 = new ComplexNumber(0, 1);
      var number2 = new ComplexNumber(1, 0);
      Console.WriteLine(number1.CompareTo(number2));
      Console.WriteLine(number2.CompareTo(number1));
      Console.WriteLine(number2.CompareTo(number2));
      Console.WriteLine(number1.CompareTo(10));
    }
  }
}
