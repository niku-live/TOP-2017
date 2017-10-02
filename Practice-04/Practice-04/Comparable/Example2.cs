using System;
using System.Collections.Generic;

namespace Practice_04.Comparable
{
  public class Example2: AbstractExample
  {
    public class ComplexNumber: Example1.ComplexNumber, IComparable
    {
      public ComplexNumber(int real, int imaginary) : base(real, imaginary) { }

      public int CompareTo(object obj)
      {
        if (!(obj is ComplexNumber))
        {
          throw new ArgumentException("Object is not complex number");
        }
        ComplexNumber other = (ComplexNumber)obj;
        int result = Real.CompareTo(other.Real);
        if (result != 0)
        {
          return result;
        }
        result = Imaginary.CompareTo(other.Imaginary);
        return result;
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
