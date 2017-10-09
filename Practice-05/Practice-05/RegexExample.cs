using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice_05
{
  public class RegexExample
  {

    public void RunExample()
    {
      string value = "25";

      Console.WriteLine(Regex.IsMatch(value, @"\d+"));
      var match = Regex.Match(value, @"\d");
      if (match.Success)
      {
        Console.WriteLine(match.Value);
      }

      match = match.NextMatch();
      if (match.Success)
      {
        Console.WriteLine(match.Value);
      }
    }

  }
}
