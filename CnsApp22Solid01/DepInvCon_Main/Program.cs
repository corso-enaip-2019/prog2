using System;

using DepInvCon_Contracts;
using ConsoleIO;
using System.Reflection;
using System.IO;

namespace DepInvCon_Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IGui gui = new ConsoleGui();

            #region Caricamento dipendenze
            LoadMathCalculator();
            #endregion

            gui.Write("Messaggio scritto.");




            var value = gui.ReadInt("Immettere un numero intero.");
            gui.Write(value.ToString());

        }

        private static IMath LoadMathCalculator()
        {
            /* Il percorso viene solitamente preso dal/dai file di configurazione, non è hard-coded. */
            var library = Assembly.LoadFile(@"C:\Users\triprog-2\source\repos\prog2\CnsApp22Solid01\DepInvCon_Main\obj\Debug\netcoreapp2.0\DepInvCon_Main.dll");

            return library as IMath;
        }

        private static IMath LoadMathCalculatorDecoupled()
        {
            /* Il percorso viene solitamente preso dal/dai file di configurazione, non è hard-coded. */
            var library = Assembly.LoadFile(@"C:\Users\triprog-2\source\repos\prog2\CnsApp22Solid01\DepInvCon_Main\obj\Debug\netcoreapp2.0\DepInvCon_Main.dll");

            return library as IMath;
        }

        private static IMath LoadMathCalculatorDecoupled_2()
        {
            /* Il percorso viene solitamente preso dal/dai file di configurazione, non è hard-coded. */
            /* Oppure, fissando il percorso relativo della dll (rispetto al bin) usando (System.IO.)Directory.GetCurrentDirectory() */
            var currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, @"MathCalculatorLibrary.dll");
            var library = Assembly.LoadFile(path);

            return library as IMath;
        }
    }
}