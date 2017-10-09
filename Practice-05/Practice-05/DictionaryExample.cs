using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_05
{
  public class DictionaryExample
  {
    public class Person
    {
      public string Name { get; set; }
      public string LastName { get; set; }
    }


    public void RunExample()
    {
      Dictionary<int, Person> dict = new Dictionary<int, Person>();
      dict.Add(5, new Person() { Name = "Jonas" });
      dict.Add(1, new Person() { Name = "Vytautas" });

      Console.WriteLine(dict[5].Name);
      Console.WriteLine(dict[1].Name);
      Console.WriteLine(dict.ContainsKey(1));
      Console.WriteLine(dict.ContainsKey(10));

      Dictionary<int, Person> dict2 = new Dictionary<int, Person>()
      {
        { 5, new Person() { Name = "Jonas" } },
        { 1, new Person() { Name = "Vytautas" } }
      };

      Dictionary<string, Person> dict3 = new Dictionary<string, Person>()
      {
        { "Jonas", new Person() { Name = "Jonas", LastName = "Jonaitis" } },
        { "Vytautas", new Person() { Name = "Vytautas", LastName = "Vytautaitis" } }
      };
      Console.WriteLine(dict3.ContainsKey("Jonas"));
      Console.WriteLine(dict3.ContainsKey("Vytautas2"));
    }

  }
}
