using System;
using System.Collections.Generic;
using System.Linq;
using CnsApp30_Ex10Queries.Classes;

namespace CnsApp30_Ex10Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create a mock list of `Farms`, every one with a list of `Fields`. */
            List<Farm> mockListOfFarms = GenerateMockListOfFarms();

            /* - A flat list of `Fields` (use `SelectMany`) */
            List<Field> flatListOfFields = GetFlatListOfFields(mockListOfFarms);
            /* - A list of items where every item has `Vegetable` and the list of `Fields` of that `Vegetable` (use `SelectMany` to flat the list, then use `GroupBy` to group by `Vegetable`, then `Select` to create the final items) */
            List<VegetableSFields> listOfVegetableSFields = GetListOfVegetableSFields(mockListOfFarms);
            /* - A list of items where every item has `Vegetable` and `TotalExtension` (use `SelectMany` to flat the list, then GroupBy using Vegetable as `Key`, then project with Select using `Aggregate` to calculate the total extension of every group) */
            List<VegetableSExtension> listOfVegetableSExtensions = GetListOfVegetableSExtensions(mockListOfFarms);
            /* - A list of `Farms` containing only the `Farms` with a total `Extension` of more than `100` */
            List<Farm> listOfFarmsWithTotalExtensionAbove100 = GetListOfFarmsWithTotalExtensionAboveX(mockListOfFarms, 100);
            /* - A list of all `Farms`, but every `Farm` must contain only the `Fields` with an `Extesion` greater than `20` */
            List<Farm> listOfFarms_AddedOnlyFieldsBiggerThan20 = GetListOfFarmsIncludingOnlyFieldsWithExtensionGreaterThanX(mockListOfFarms, 20);



            /* - A list of `Owners`, where every `Owner` has a `Name` and a list of `Farms` (and every `Farm` has its list of `Fields`) */
            List<OwnerSFarms> listOfOwnersWithTheirsFarms = GetListOfOwnersWithTheirsFarms(mockListOfFarms);



            /* - A list of `Owners`, where every `Owner` has a `Name` and a list of `VegetablePercentages`, where a `VegetablePercentage` has the Name of the `Vegetable` and the percentage of `Extension` of that `Vegetable` on the `Farms` of that `Owner` (for example, `Mario` has many `Farms` and `Fields`, for a total of 60 areas of corn and 140 areas of wheat: there will be 2 items in the `Mario`'s list, one with the infos 'Corn' and 30%, and the other with the infos 'Wheat' and 70%) */
            List<OwnerSVegetables> listOfOwnersWithPercentagesOfFieldUtilization = GetListOfOwnersWithPercentagesOfFieldUtilization(mockListOfFarms);



            Console.ReadLine();

            //Console.WriteLine("Create a mock list of `Farms`, every one with a list of `Fields`.");
            //Console.WriteLine();
            //Console.WriteLine("- A flat list of `Fields` (use `SelectMany`)");
            //Console.WriteLine();
            //Console.WriteLine("- A list of items where every item has `Vegetable` and the list of `Fields` of that `Vegetable` (use `SelectMany` to flat the list, then use `GroupBy` to group by `Vegetable`, then `Select` to create the final items)");
            //Console.WriteLine();
            //Console.WriteLine("- A list of items where every item has `Vegetable` and `TotalExtension` (use `SelectMany` to flat the list, then GroupBy using Vegetable as `Key`, then project with Select using `Aggregate` to calculate the total extension of every group)");
            //Console.WriteLine();
            //Console.WriteLine("- A list of `Farms` containing only the `Farms` with a total `Extension` of more than `100`");
            //Console.WriteLine();
            //Console.WriteLine("- A list of all `Farms`, but every `Farm` must contain only the `Fields` with an `Extesion` greater than `20`");
            //Console.WriteLine();
            //Console.WriteLine("- A list of `Owners`, where every `Owner` has a `Name` and a list of `Farms` (and every `Farm` has its list of `Fields`)");
            //Console.WriteLine();
            //Console.WriteLine("- A list of `Owners`, where every `Owner` has a `Name` and a list of `VegetablePercentages`, where a `VegetablePercentage` has the Name of the `Vegetable` and the percentage of `Extension` of that `Vegetable` on the `Farms` of that `Owner` (for example, `Mario` has many `Farms` and `Fields`, for a total of 60 areas of corn and 140 areas of wheat: there will be 2 items in the `Mario`'s list, one with the infos 'Corn' and 30%, and the other with the infos 'Wheat' and 70%)");
            //Console.WriteLine();

            Console.ReadLine();
        }



        /* Create a mock list of `Farms`, every one with a list of `Fields`. */
        static List<Farm> GenerateMockListOfFarms()
        {
            List<Farm> outList = new List<Farm>();

            List<Field> mockFieldsTom = new List<Field>
            {
                new Field("Patate", 25),
                new Field("Cavolfiori", 5),
                new Field("Viti", 30),
                new Field("Mais", 15)
            };
            outList.Add(new Farm("Tom", mockFieldsTom));

            List<Field> mockFieldsTobia = new List<Field>();
            mockFieldsTobia.Add(new Field("Carote", 25));
            mockFieldsTobia.Add(new Field("Carciofi", 5));
            outList.Add(new Farm("Tobia", mockFieldsTobia));

            List<Field> mockFieldsSam = new List<Field>
            {
                new Field("Patate", 125),
                new Field("Cavolfiori", 55),
                new Field("Viti", 330),
                new Field("Mais", 215),
                new Field("Carote", 25),
                new Field("Carote", 5),
                new Field("Carciofi", 555)
            };
            outList.Add(new Farm("Sam", mockFieldsSam));

            List<Field> mockFieldsBoris = new List<Field>
            {
                new Field("Fragole", 5),
                new Field("Carote", 2),
                new Field("Carciofi", 5)
            };
            outList.Add(new Farm("Boris", mockFieldsBoris));

            //fattoriaA con lo stesso proprietario di fattoriaB
            List<Field> mockFieldsIvanA = new List<Field>
            {
                new Field("Mais", 50),
                new Field("Carote", 30),
                new Field("Cavolfiori", 50)
            };
            outList.Add(new Farm("Ivan", mockFieldsIvanA));

            //fattoriaB con lo stesso proprietario di fattoriaA
            List<Field> mockFieldsIvanB = new List<Field>
            {
                new Field("Mais", 10),
                new Field("Mais", 25),
                new Field("Viti", 350)
            };
            outList.Add(new Farm("Ivan", mockFieldsIvanB));

            //fattoria senza campi
            List<Field> mockFieldsDragan = new List<Field>();
            outList.Add(new Farm("Dragan", mockFieldsDragan));


            return outList;
        }

        /* - A flat list of `Fields` (use `SelectMany`) */
        static List<Field> GetFlatListOfFields(List<Farm> inListOfFarms)
        {
            //List<Field> outList = new List<Field>();
            //outList = inListOfFarms.SelectMany(x => x.Fields).ToList();

            //return outList;

            return inListOfFarms.SelectMany(x => x.Fields).ToList();
        }

        /* - A list of items where every item has `Vegetable` and the list of `Fields` of that `Vegetable` (use `SelectMany` to flat the list, then use `GroupBy` to group by `Vegetable`, then `Select` to create the final items) */
        static List<VegetableSFields> GetListOfVegetableSFields(List<Farm> inListOfFarms)
        {
            List<VegetableSFields> outList = new List<VegetableSFields>();
            var tempList = GetFlatListOfFields(inListOfFarms)
                .GroupBy(x => x.Vegetable)
                .Select(x => x)
                .ToList();
            outList = tempList
                .Select(y => new VegetableSFields(y.Key.ToString(), y.ToList()))
                .OrderBy(z => z.Vegetable)
                .ToList();

            return outList;
        }

        /* - A list of items where every item has `Vegetable` and `TotalExtension` (use `SelectMany` to flat the list, then GroupBy using Vegetable as `Key`, then project with Select using `Aggregate` to calculate the total extension of every group) */
        static List<VegetableSExtension> GetListOfVegetableSExtensions(List<Farm> inListOfFarms)
        {
            List<VegetableSExtension> outList = new List<VegetableSExtension>();
            var tempList = GetListOfVegetableSFields(inListOfFarms);
            outList = tempList
                .Select(x => new VegetableSExtension(x.Vegetable, x.FieldsWhereItIsHarvested.Sum(y => y.Extension)))
                .OrderBy(z => z.Vegetable)
                .ToList();

            return outList;
        }

        /* - A list of `Farms` containing only the `Farms` with a total `Extension` of more than `100` */
        static List<Farm> GetListOfFarmsWithTotalExtensionAboveX(List<Farm> inListOfFarms, int minimumExtension)
        {
            //List<Farm> outList = new List<Farm>();

            //outList = inListOfFarms
            //    .Where(x => (x.Fields.Sum(y => y.Extension)) > minimumExtension)
            //    .OrderBy(z => z.Owner)
            //    .ToList();

            //return outList;

            return inListOfFarms
                .Where(x => (x.Fields.Sum(y => y.Extension)) > minimumExtension)
                .OrderBy(z => z.Owner)
                .ToList();
        }

        /* - A list of all `Farms`, but every `Farm` must contain only the `Fields` with an `Extesion` greater than `20` */
        static List<Farm> GetListOfFarmsIncludingOnlyFieldsWithExtensionGreaterThanX(List<Farm> inListOfFarms, int minimumFieldExtension)
        {
            List<Farm> outList = new List<Farm>();


            outList = inListOfFarms
            //.Where(x => x.Fields.Where(y => (y.Extension) > minimumFieldExtension))



            .OrderBy(z => z.Owner)
            .ToList();

            return outList;




            //inListOfFarms.RemoveAll(x => x.Fields.Where(y => y.Extension <= minimumFieldExtension))
        }

        /* - a list of `Owners`, where every `Owner` has a `Name` and a list of `Farms` (and every `Farm` has its list of `Fields`) */
        static List<OwnerSFarms> GetListOfOwnersWithTheirsFarms(List<Farm> inListOfFarms)
        {
            List<OwnerSFarms> outList = new List<OwnerSFarms>();



            return outList;

        }

        /* - a list of `Owners`, where every `Owner` has a `Name` and a list of `VegetablePercentages`, where a `VegetablePercentage` has the Name of the `Vegetable` and the percentage of `Extension` of that `Vegetable` on the `Farms` of that `Owner` (for example, `Mario` has many `Farms` and `Fields`, for a total of 60 areas of corn and 140 areas of wheat: there will be 2 items in the `Mario`'s list, one with the infos 'Corn' and 30%, and the other with the infos 'Wheat' and 70%) */
        static List<OwnerSVegetables> GetListOfOwnersWithPercentagesOfFieldUtilization(List<Farm> inListOfFarms) { return new List<OwnerSVegetables>(); }
    }
}