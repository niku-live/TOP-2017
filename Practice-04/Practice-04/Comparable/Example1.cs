using System;
using System.Collections.Generic;

namespace Practice_04.Comparable
{
  public class Example1: AbstractExample
  {
    public class ComplexNumber
    {
      public int Imaginary { get; set; }
      public int Real { get; set; }

      public ComplexNumber(int real, int imaginary)
      {
        Imaginary = imaginary;
        Real = real;
      }

      public override string ToString()
      {
        return $"{Real} + {Imaginary}i";
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

      //var number1 = new ComplexNumber(0, 1);
      //var number2 = new ComplexNumber(1, 0);
      //Console.WriteLine(number1.CompareTo(number2));
      //Console.WriteLine(number2.CompareTo(number1));
      //Console.WriteLine(number2.CompareTo(number2));
      //Console.WriteLine(number1.CompareTo(10));
    }

  }
}
