using System;

namespace CnsApp10Recap1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 9;

            int maxInt = int.MaxValue;
            int minInt = int.MinValue;
            uint maxUInt = uint.MaxValue;
            uint minUInt = uint.MinValue;

            Int32 maxInt32 = Int32.MaxValue;
            Int32 minInt32 = Int32.MinValue;
            UInt32 maxUInt32 = UInt32.MaxValue;
            UInt32 minUInt32 = UInt32.MinValue;

            Console.WriteLine($"maxInt    {maxInt.ToString().PadLeft(24)}");
            Console.WriteLine($"minInt    {minInt.ToString().PadLeft(24)}");
            Console.WriteLine($"maxUInt   {maxUInt.ToString().PadLeft(24)}");
            Console.WriteLine($"minUInt   {minUInt.ToString().PadLeft(24)}");
            Console.WriteLine($"maxInt32  {maxInt32.ToString().PadLeft(24)}");
            Console.WriteLine($"minInt32  {minInt32.ToString().PadLeft(24)}");
            Console.WriteLine($"maxUInt32 {maxUInt32.ToString().PadLeft(24)}");
            Console.WriteLine($"minUInt32 {minUInt32.ToString().PadLeft(24)}");



            Console.ReadLine();
        }
    }
}
