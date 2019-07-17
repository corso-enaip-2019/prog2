using ConsoleIO;
using DepInvCon_Contracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DepInvCon_Main
{
    /*
     * DEPENDENCY INVERSION OF CONTROL
     * Normalmente sono tentato di far dipendere i moduli "alti" dell'applicazione dai moduli "bassi".
     * Ad esempio, in Program.Main() uso direttamente istruzioni come Console.WriteLine(), Console.Read().
     * 
     *      -----------------
     *      |  APPLICATION  |
     *      -----------------
     *              |
     *              |
     *              V
     *  -------------------------
     *  |   LOW-LEVEL LIBRARY   |
     *  -------------------------
     * 
     * 
     * Ho due scenari critici:
     * - i creatori di Console decidono di cambiare i metodi di Console. Se voglio aggiornare, devo rimodificare tutta la mia app.
     * - la libreria di basso livello con i dettagli implementativi non c'è ancora, è in sviluppo, chissà.
     * In questi scenari diventa cattivo design avere dipendenze strette verso i moduli bassi.
     * Il PRINCIPIO DI INVERSIONE DI DIPENDENZA mi dice che devo invertire la dipendenza:
     * devono essere le classi di basso livello a dipendere da interfacce decise dal modulo di alto livello:
     * 
     * -----------------             -----------------
     * |  APPLICATION  |  ---------> |   CONTRACTS   |
     * -----------------             -----------------
     *                                       A
     *                                       |
     *                                       |         
     *                           -------------------------
     *                           |   LOW-LEVEL LIBRARY   |
     *                           -------------------------
     *                           
     * In questo modo le librerie di basso livello sono "costrette" dentro regole ben precise.
     * 
     * Ovviamente, il modulo APPLICATION di alto livello deve ancora capire come utilizzare le classi concrete di LOW-LEVEL.
     * Abbiamo due opzioni:
     * 1) dipendenza statica (nell'esempio seguente: IGui), cioè importo la libreria a compile-time
     *      e verifico con il compilatore che le classi di LOW-LEVEL implementino l'interfaccia voluta
     * 2) caricamento dinamico della libreria (nell'esempio seguente: IMathCalculator). 
     */

    class Program
    {
        static void Main(string[] args)
        {
            IGui gui = new ConsoleGui();
            //IMath mathCalculator = LoadMathCalculatorRigid();
            IMath mathCalculator = LoadMathCalculatorDecoupled();

            var value = gui.ReadInt("Give me an integer: ");

            bool isPrime = mathCalculator.IsPrime(value);

            gui.Write($"The number {value} is {(isPrime ? "" : "not ")}prime.");

            Console.Read();
        }

        private static IMath LoadMathCalculatorRigid()
        {
            var library = Assembly.LoadFile(@"C:\Users\triprog-20\source\repos\corso-enaip-2019\src\Solid_principles\DevInvCon_MathSlow\bin\Debug\netstandard2.0\DevInvCon_MathSlow.dll");

            // vorrei mettere il percorso relativo, però così si rompe:
            //var library = Assembly.LoadFile(@"\..\..\..\..\DevInvCon_MathSlow\bin\Debug\netstandard2.0\DevInvCon_MathSlow.dll");

            var type = library.GetType("DevInvCon_MathSlow.PrimeCalculator");

            var mathCalculator = Activator.CreateInstance(type) as IMath;

            if (mathCalculator == null)
                throw new Exception("Type not found");

            return mathCalculator;
        }

        private static IMath LoadMathCalculatorDecoupled()
        {
            // nella cartella principale del progetto _Main abbiamo incollato la dll compilata
            // che c'era in _MathSlow/bin/debug/netcoreapp2.2 o _MathFast/bin/debug/netcoreapp2.2,
            // rinominandola.
            // Normalmente un utente di questa app può importare una libreria creata altrove,
            // mettendola nello stesso posto con lo stesso nome, e dinamicamente verrà caricata e eseguita.

            var directory = Directory.GetCurrentDirectory();

            // MAI concatenare i percorsi a mano.
            //var p = directory + @"\" + "DevInvCon_MathSlow.dll";

            var path = Path.Combine(directory, @"MathCalculatorLibrary.dll");

            var library = Assembly.LoadFile(path);

            var iMathInterface = typeof(IMath);

            var mathCalculatorType = library
                .GetTypes()
                .FirstOrDefault(t => t.GetInterfaces().Contains(iMathInterface));

            if (mathCalculatorType == null)
                throw new InvalidOperationException("Type implementing IMath not found");

            var mathCalculator = Activator.CreateInstance(mathCalculatorType) as IMath;

            if (mathCalculator == null)
                throw new InvalidOperationException("Cannot create instance of IMath");

            return mathCalculator;
        }
    }
}
