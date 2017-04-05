using Newtonsoft.Json;
using System;
using System.Linq;

namespace EFTableValuedFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Model1())
            {
                var r1 = db.Table1.ToList();
                Console.WriteLine(JsonConvert.SerializeObject(r1, Formatting.Indented));

                var r2 = db.Function1("a").OrderBy(x=> x.Name).Take(1).Skip(1);
                Console.WriteLine(JsonConvert.SerializeObject(r2, Formatting.Indented));
            }
            Console.ReadLine();
        }
    }
}
