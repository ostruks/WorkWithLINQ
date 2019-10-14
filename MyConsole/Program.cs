using MyLibrary;
using System;
using System.Linq;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkLinq workLinq = new WorkLinq();

            Console.WriteLine("Array 1: ");
            workLinq.Show(workLinq.List1);
            Console.WriteLine("Array 2: ");
            workLinq.Show(workLinq.List2);

            int? firstPositive = workLinq.List1?.Where(number => number > -1).FirstOrDefault();
            Console.WriteLine("First positive: " + firstPositive);
            int? lastNegative = workLinq.List1?.Where(number => number < 0).LastOrDefault();
            Console.WriteLine("Last negative: " + lastNegative);
            Console.WriteLine("===========");

            workLinq.ShowStrings();

            var strs = workLinq.ListOfString.Select(str => str.ToUpper().StartsWith('C') ? str : "");
            string str1 = strs.Count(str => str != "") > 1 ? String.Join(" ", strs.Where(str => str != "").ToArray()) : strs.FirstOrDefault(str => str != "");
            Console.WriteLine(str1);
            Console.WriteLine("===========");

            var allOdd = workLinq.List1?.Where(number => number % 2 == 0).Distinct();
            Console.WriteLine("All odd: ");
            workLinq.Show(allOdd);

            int D = 5;
            int? moreThenD = workLinq.List1?.Where(number => number > D).FirstOrDefault();
            Console.WriteLine("More then D: " + moreThenD);
            Console.WriteLine("===========");

            var allOddPositive = workLinq.List1?.Where(number => number % 2 == 0 && number > 0).Reverse();
            Console.WriteLine("All odd & positive (Reverse): ");
            workLinq.Show(allOddPositive);

            var twoArray = workLinq.List1?.Where(number => number > D).Concat(workLinq.List2?.Where(number => number < D)).DefaultIfEmpty(155);
            Console.WriteLine($"Two array more and less than ({D}): ");
            workLinq.Show(twoArray);

            workLinq.AddProvider(new Provider { Name = "Samsung", Amount = 155.5, Date = new DateTime(2019, 10, 12) });
            workLinq.AddProvider(new Provider { Name = "Samsung", Amount = 175.5, Date = new DateTime(2019, 10, 12) });
            workLinq.AddProvider(new Provider { Name = "Apple", Amount = 212.6, Date = new DateTime(2019, 10, 13) });
            workLinq.AddProvider(new Provider { Name = "Huawei", Amount = 412.3, Date = new DateTime(2019, 10, 14) });
            workLinq.AddProvider(new Provider { Name = "", Amount = 0, Date = new DateTime(2019, 10, 14) });

            Console.WriteLine("Companies:");
            foreach (var provider in workLinq.Providers.Where(pro => pro.Name != "").GroupBy(c => c.Name)
                //.Where(pro => pro.Key != "")
                .Select(x => 
                new { x.Key, Amount = x.Sum(dt => dt.Amount), Date = x.Select(d => d.Date).FirstOrDefault() }
                ))
            {
                Console.WriteLine($"Company: {provider.Key}, Amount = {provider.Amount}, Date: {provider.Date.ToShortDateString()}");
            }
            Console.WriteLine("===========");

            Console.ReadKey();
        }
    }
}
