using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicsNAV100Entities context = new DynamicsNAV100Entities();


            //Naujo elemento idejimas
            Table newTableEntry = new Table();
            newTableEntry.Name = "Naujas EF";
            newTableEntry.Amount = 100M;
            context.Table.Add(newTableEntry);

            //Atnaujinimas
            Table existingEntry = context.Table.OrderByDescending(t => t.Id).FirstOrDefault();
            existingEntry.Name = "Updated EF";

            //Panaikinimas
            Table existingEntry2 = context.Table.OrderBy(t => t.Id).Skip(1).Take(1).First();
            context.Table.Remove(existingEntry2);

            //Išrinkimas iš tam tikros lentelės
            foreach (var user in context.Company)
            {
                Console.WriteLine(user.Name);
            }

            //Susijusios lentelės papildymas (tiesiogiai nekoreguojant išorinio rakto)
            existingEntry.TableDetail.Add(new TableDetail() { Id = 2, Name = "Test Detal" });

            //Susijusios lentelės papildymas (tiesiogiai koreguojant išorinį raktą) - NEREKOMENDUOJAMAS ir VENGTINAS
            TableDetail tst = new TableDetail();
            tst.Id = 3;
            tst.Name = "Blogas";
            tst.Table = existingEntry;
            tst.Table_Id = 3;
            context.TableDetail.Add(tst);

            foreach (var detail in context.TableDetail)
            {
                Console.WriteLine($"{detail.Id} {detail.Name} {detail.Table_Id}");
            }

            //Po visko būtina visus pakeitimus įvykdyti SQL serveryje:
            context.SaveChanges();
        }
    }
}
