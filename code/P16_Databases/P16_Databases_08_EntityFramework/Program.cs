using System;
using System.Diagnostics;
using System.Linq;

namespace P16_Databases_08_EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MainDbContext())
            {
                if (ctx.Models.Count() == 0)
                    LoadMocks(ctx);

                var _ = ctx.Models.First();

                var sw2 = Stopwatch.StartNew();
                var selected2 = ctx.Models.First(x => x.Value2 == "b6fc39d3-74aa-49d3-8a5c-e63a566b14d8");
                sw2.Stop();
                Console.WriteLine($"found in: {sw2.ElapsedMilliseconds} ms");

                var sw1 = Stopwatch.StartNew();
                var selected1 = ctx.Models.First(x => x.Value1 == "b6fc39d3-74aa-49d3-8a5c-e63a566b14d8");
                sw1.Stop();
                Console.WriteLine($"found in: {sw1.ElapsedMilliseconds} ms");

                
            }

            Console.Write("Press a key to exit...");
            Console.Read();
        }

        private static void LoadMocks(MainDbContext ctx)
        {
            for(int i = 0; i < 100_000; i++)
            {
                var guid = Guid.NewGuid().ToString();

                var m = new Model
                {
                    Value1 = guid,
                    Value2 = guid,
                };

                ctx.Models.Add(m);
            }

            ctx.SaveChanges();
        }
    }
}
