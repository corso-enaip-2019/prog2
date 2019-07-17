using System;
using System.Threading;

namespace P32_DesignPattern_Test_Solution
{
    /*
    * Ristrutturare il seguente programma seguendo il paradigma ad oggetti e utilizzando gli opportuni design pattern.
    * 
    * In particolare, il metodo BringDrunkToHome() dovrà diventare una classe FACTORY chiamata Pub con un metodo CreateDrunk().
    * Il metodo restituisce un'istanza di IDrunk.
    * L'osteria va realizzata come SINGLETON.
    * 
    * La classe Drunk ha un metodo GoHome(), dentro il quale c'è la logica che sposta la persona ubriaca verso casa.
    * Le coordinate dell'osteria (Pub) sono sempre (20, 0), quelle della casa (20, 20).
    * I due tipi di Drunk (WineDrunk e BeerDrunk) vanno realizzati col pattern TEMPLATE.
    * Questo perché la parte iniziale e finale sono le stesse. Quello che varia è la parte centrale, il modo in cui
    * l'ubriaco fa il suo percorso sgangherato (quindi questa parte sarà implementata nelle due classi derivate).
    * 
    * I parametri bool isDrunk e muchDrunk decidono di quanto si sposta l'ubriaco:
    * - se non è ubriaco, va dritto dall'osteria a casa;
    * - se è poco ubriaco, riesce a fare parecchi passi nella stessa direzione;
    * - se è molto ubriaco, fa un zig zag molto stretto perché barcolla di più.
    * Questi due parametri devono diventare un insieme di tre piccole classi,
    * accomunate da un'interfaccia IDrunkLevel, da settare in una proprietà della classe Drunk con il pattern STRATEGY.
    * L'interfaccia ha un metodo IsDrunk() che restituisce un bool, e un metodo CalculateMaxSteps().
    * 
    * Il metodo GoHome() dei Drunk funziona quindi così:
    * - chiedo all'IDrunkLevel IsDrunk().
    * - se no, vado dritto a casa perché sono sobrio.
    * - altrimenti, faccio il percorso sgangherato in base al mio tipo (è la parte abstract del metodo TEMPLATE)
    * - alla fine, arrivato all'ultima riga, faccio i passi necessari per arrivare dritto a casa.
    * 
    * LittleDrunkLevel e MuchDrunkLevel restituiscono true nel metodo IsDrunk()
    * NullDrunkLevel è un NullObject: IsDrunk() restituisce false e CalculateMaxSteps() restituisce 0.
    * Implementarlo come SINGLETON.
    * 
    * In ultimo, estrarre la funzionalità di stampa in console della posizione.
    * Deve esserci una classe statica con metodi:
    * - MoveLeft
    * - MoveRight
    * - MoveDown
    * - MoveLeftDown
    * Tutti prendono in input il numero di passi da percorrere,
    * aspettano un numero random di millisecondi (il Thread.Sleep(r.Next(1, 10) * 25))
    * e si muovono della direzione giusta.
    */
    class Program
    {
        static void Main(string[] args)
        {
            var drunk = Pub.Instance.CreateDrunk(true, "wine", false);

            drunk.GoHome();

            Console.Read();
        }

        class Pub
        {
            #region SINGLETON
            static Pub()
            {
                Instance = new Pub();
            }

            public static Pub Instance { get; }

            private Pub() { }
            #endregion

            public IDrunk CreateDrunk(bool isDrunk, string type, bool muchDrunk)
            {
                Drunk drunk = CreateDrunkInstance(type);
                drunk.DrunkLevel = CreateDrunkLevel(isDrunk, muchDrunk);
                return drunk;
            }

            private Drunk CreateDrunkInstance(string type)
            {
                switch (type)
                {
                    case "beer":
                        return new BeerDrunk();
                    case "wine":
                        return new WineDrunk();
                    default:
                        throw new ArgumentException("invalid type");
                }
            }

            private IDrunkLevel CreateDrunkLevel(bool isDrunk, bool muchDrunk)
            {
                if (isDrunk)
                {
                    if (muchDrunk)
                        return new MuchDrunkLevel();
                    else
                        return new LittleDrunkLevel();
                }
                else
                {
                    return NullDrunkLevel.Instance;
                }
            }
        }

        public interface IDrunk
        {
            void GoHome();
        }

        public abstract class Drunk : IDrunk
        {
            public Drunk()
            {
                DrunkLevel = NullDrunkLevel.Instance;
            }

            public IDrunkLevel DrunkLevel
            {
                get { return _DrunkLevel; }
                set
                {
                    if (value == null)
                        value = NullDrunkLevel.Instance;
                    _DrunkLevel = value;
                }
            }
            private IDrunkLevel _DrunkLevel;

            public void GoHome()
            {
                DoInitialSteps();

                if(DrunkLevel.IsDrunk())
                    GoHomeWobbling();
                else
                    GoHomeStraight();

                DoFinalSteps();
            }

            private void DoInitialSteps()
            {
                Console.CursorLeft = 20;
                Console.CursorTop = 0;

                Console.Write("0");
                Console.CursorLeft--;
            }

            protected abstract void GoHomeWobbling();

            private void GoHomeStraight()
            {
                Movements.MoveDown(20);
            }

            private void DoFinalSteps()
            {
                var xDiff = Console.CursorLeft - 20;

                if (xDiff > 0)
                    Movements.MoveLeft(xDiff);
                else if (xDiff < 0)
                    Movements.MoveRight(-xDiff);

                Console.Write("X");
                Console.CursorLeft--;
            }
        }

        public class BeerDrunk : Drunk
        {
            protected override void GoHomeWobbling()
            {
                var r = new Random();
                while (Console.CursorTop < 20)
                {
                    Thread.Sleep(500);
                    var maxSteps = DrunkLevel.CalculateMaxSteps();
                    Movements.MoveRight(r.Next(1, maxSteps));
                    Movements.MoveDown(r.Next(1, maxSteps));
                    Movements.MoveLeft(r.Next(1, maxSteps));
                    Movements.MoveDown(r.Next(1, maxSteps));
                }
            }
        }

        public class WineDrunk : Drunk
        {
            protected override void GoHomeWobbling()
            {
                var r = new Random();
                Thread.Sleep(500);
                while (Console.CursorTop < 20)
                {
                    var maxSteps = DrunkLevel.CalculateMaxSteps();
                    Movements.MoveRight(r.Next(1, maxSteps));
                    Movements.MoveLeftDown(r.Next(1, maxSteps));
                }
            }
        }

        public interface IDrunkLevel
        {
            bool IsDrunk();
            int CalculateMaxSteps();
        }

        class LittleDrunkLevel : IDrunkLevel
        {
            public int CalculateMaxSteps()
            {
                return 10;
            }

            public bool IsDrunk()
            {
                return true;
            }
        }

        class MuchDrunkLevel : IDrunkLevel
        {
            public int CalculateMaxSteps()
            {
                return 5;
            }

            public bool IsDrunk()
            {
                return true;
            }
        }

        class NullDrunkLevel : IDrunkLevel
        {
            #region SINGLETON
            static NullDrunkLevel()
            {
                Instance = new NullDrunkLevel();
            }

            public static NullDrunkLevel Instance { get; }

            private NullDrunkLevel() { }
            #endregion

            public int CalculateMaxSteps()
            {
                return 0;
            }

            public bool IsDrunk()
            {
                return false;
            }
        }

        static class Movements
        {
            public static void MoveRight(int steps)
            {
                for (int i = 0; i < steps; i++)
                {
                    Thread.Sleep(new Random().Next(1, 10) * 25);
                    Console.CursorLeft++;
                    Console.Write("0");
                    Console.CursorLeft--;
                }
            }

            public static void MoveLeft(int steps)
            {
                for (int i = 0; i < steps; i++)
                {
                    Thread.Sleep(new Random().Next(1, 10) * 25);
                    Console.CursorLeft--;
                    Console.Write("0");
                    Console.CursorLeft--;
                }
            }

            public static void MoveDown(int steps)
            {
                for (int i = 0; i < steps; i++)
                {
                    Thread.Sleep(new Random().Next(1, 10) * 25);
                    Console.CursorTop++;
                    Console.Write("0");
                    Console.CursorLeft--;
                }
            }

            public static void MoveLeftDown(int steps)
            {
                for (int i = 0; i < steps; i++)
                {
                    Thread.Sleep(new Random().Next(1, 10) * 25);
                    Console.CursorTop++;
                    Console.CursorLeft--;
                    Console.Write("0");
                    Console.CursorLeft--;
                }
            }
        }
    }
}
