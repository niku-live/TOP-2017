using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_05
{
  public class StringBuilderExample
  {

    const int count = 20000;
    const string someValue = "quick brown fox jumps over the lazy dog";

    string SlowConcat()
    {
      string result = string.Empty;

      for (int i = 0; i < count; i++)
      {
        result += someValue;
      }

      return result;
    }

    string FastConcat()
    {
      StringBuilder SB = new StringBuilder(String.Empty);

      for (int i = 0; i < count; i++)
      {
        SB.Append(someValue);
      }

      return SB.ToString();
    }

    public void RunExample()
    {
      string result = String.Empty;

      DateTime t1 = DateTime.Now;
      result = SlowConcat();


      DateTime t2 = DateTime.Now;
      result = FastConcat();
      DateTime t3 = DateTime.Now;

      double diff1 = (t2 - t1).TotalMilliseconds;
      double diff2 = (t3 - t2).TotalMilliseconds;

      Console.WriteLine("Slow was {0:F} miliseconds: ", diff1.ToString());
      Console.WriteLine("Fast was {0:F} miliseconds: ", diff2.ToString());

      Console.WriteLine("For {0} concatanations it was {1:F} times faster", count, diff1 / diff2);

      Console.ReadLine();
    }

  }
}
