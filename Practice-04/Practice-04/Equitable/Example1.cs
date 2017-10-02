using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_04.Equitable
{
    public class Example1 : Comparable.Example4
    {
        public class ComplexNumber: Comparable.Example1.ComplexNumber, IEquatable<ComplexNumber>
        {
            public ComplexNumber(int real, int imaginary) : base(real, imaginary) { }

            public bool Equals(ComplexNumber other)
            {
                return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);
            }
        }

        public class ComplexNumberOld : Comparable.Example1.ComplexNumber
        {
            public ComplexNumberOld(int real, int imaginary) : base(real, imaginary) { }

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
            var item1 = numbers[0];
            var item2 = new ComplexNumber(0, 1);

            Console.WriteLine(numbers.Contains(item1));
            Console.WriteLine(numbers.Contains(item2));


        }
    }
}
