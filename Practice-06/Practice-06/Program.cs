using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_06
{
    //See LinqPadScript.linq for same examples in LinqPad version
    public static class LinqPadExtensions
    {
        public static void Dump(this string value)
        {
            Console.WriteLine(value);
        }

        public static void Dump(this int value)
        {
            Console.WriteLine(value);
        }
        public static void Dump<T>(this IEnumerable<T> list)
        {
            Console.WriteLine("----------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------");
        }

    }

    class Program
    {
        public class NumberInfo
        {
            public int Number { get; set; }
            public string Text { get; set; }
        }

        public class PersonItem
        {
            public string PersonName { get; set; }
            public int Price { get; set; }
        }

        public static void Main()
        {
            "Original List".Dump();
            var list = new List<int>() { 1, 5, 7, 3, 9, 15, 11, 10, 8, 4 };
            list.Dump();

            "Example 1: Select only even number and sort".Dump();

            "Bad example: Foreach-way".Dump();
            var list2 = new List<int>();
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    list2.Add(item);
                }
            }
            list2.Sort();
            list2.Dump();

            "Good example: Linq-way:".Dump();
            var list3 = (
              from item in list
              where item % 2 == 0
              orderby item
              select item);
            list3.Dump();

            "Example 2: Projection - anonymous type".Dump();
            var list4 = (
              from item in list
              where item % 2 == 0
              orderby item
              select new { Number = item, Text = item.ToString() + "%" });
            list4.Dump();

            "Example 3: Projection - to defined class".Dump();
            var list5 = (
              from item in list
              where item % 2 == 0
              orderby item
              select new NumberInfo { Number = item, Text = item.ToString() + "%" });
            list5.Dump();

            "Example 4: Linq by methods".Dump();
            var list6 = list.
               Where(item => item % 2 == 0).
               OrderBy(item => item).
               Select(item => item.ToString() + "%");

            list6.Dump();

            "Example 5: Inner Join".Dump();
            var slist = new List<int>() { 1, 5, 9, 15, 10, 8, 4 };
            slist.Dump();

            var list7 = from item1 in list
                        join item2 in slist
                        on item1 equals item2
                        select new { Item1 = item1, Item2 = item2 };
            list7.Dump();

            "Example 6: Outter join".Dump();
            var list8 = from item1 in list
                        join item2 in slist
                        on item1 equals item2 into temp
                        from t in temp.DefaultIfEmpty()
                        select new { Item1 = item1, Item2 = t };
            list8.Dump();

            "Example 7: Grouping".Dump();
            var personItems = new List<PersonItem>()
            {
              new PersonItem() { PersonName = "Jonas", Price = 10 },
              new PersonItem() { PersonName = "Jonas", Price = 15 },
              new PersonItem() { PersonName = "Petras", Price = 10 },
            };

            personItems.Dump();
            var gr = from p in personItems
                     group p by p.PersonName into grouped
                     select new
                     {
                         Person = grouped.Key,
                         Sum = grouped.Sum(g => g.Price),
                         Count = grouped.Count(),
                         GroupData = grouped
                     };
            gr.Dump();

            "Example 8: First even number in list".Dump();
            list.FirstOrDefault(item => item % 2 == 0).Dump();
            "Example 9: Count of all even nmbers in list".Dump();
            list.Count(item => item % 2 == 0).Dump();
            "Example 10: Sum of all even nmbers in list".Dump();
            list.Sum(item => item).Dump();

        }

    }
}
