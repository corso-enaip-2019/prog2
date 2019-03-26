using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CnsApp09_Anagrams.UIHandlers;
using CnsApp09_Anagrams.AnagramRepos;
using CnsApp09_Anagrams.Gameplays;

/* 20190325 */

namespace CnsApp09_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Pre-Preparazione liste
            /* Creazione ed aggiunta degl'handler nella lista degl'handler. */
            List<IUIHandler> handlers = new List<IUIHandler>();
            UIConsoleHandler cnsHnd = new UIConsoleHandler();
            handlers.Add(cnsHnd);

            /* Creazione del dizionario d'anagrammi locale (già popolato nella classe). */
            //List<IAnagramRepo> anagramRepos = new List<IAnagramRepo>();
            LocalAnagramRepo localRepo = new LocalAnagramRepo();
            IAnagramRepo selectedRepo = localRepo;


            /* Creazione e popolamento della lista dei gameplay. */
            List<IGameplay> gameplays = new List<IGameplay>();
            Training training = new Training();
            gameplays.Add(training);
            Challenge challenge = new Challenge();
            gameplays.Add(challenge);
            #endregion

            foreach (IUIHandler handler in handlers)
            {
                handler.WriteStringToUI("Anagrammi!");
                handler.WriteStringToUI("");

                /* Visualizza modalità. */
                handler.WriteStringToUI("Modalità disponibili:");
                handler.WriteStringToUI("Codice\tNome\tDescrizione");
                foreach (IGameplay gameplayMode in gameplays)
                {
                    handler.WriteStringToUI($"- {gameplayMode.Code.ToLower()}\t{gameplayMode.Name}");
                    handler.WriteStringToUI($"\t\t{gameplayMode.Description}");
                    handler.WriteStringToUI($"");
                }

                /* Scelta modalità. */
                IGameplay selectedGameplay = SelectGameplay(gameplays, handler);
                selectedGameplay.RunGameplay(selectedRepo, handlers);
            }








            /*
            cnsHnd.WriteStringToUI("Scrittura tramite handler");

            string test01 = cnsHnd.AskForString("prova");
            cnsHnd.WriteStringToUI(test01);

            cnsHnd.WriteStringToUI(cnsHnd.AskForString("Richiesta d\'input"));
            */


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Premere [Invio] per uscire ... ");
            Console.ReadLine();
        }

        static IGameplay SelectGameplay(List<IGameplay> gameplays, IUIHandler handler)
        {
            bool sensedMode = false;
            int indexOfSelectedMode = 0;

            List<string> gameplayCodes = new List<string>();
            foreach (IGameplay gameplay in gameplays)
            { gameplayCodes.Add(gameplay.Code); }

            while (!sensedMode)
            {
                string selectedMode = handler.AskForString($"Selezionare la modalità immettendo il codice corrispondente: ").ToLower();
                sensedMode = (gameplayCodes.Contains(selectedMode)) ? true : false;
                if (sensedMode)
                {
                    indexOfSelectedMode = gameplayCodes.IndexOf(selectedMode);
                    handler.WriteStringToUI($"Modalità scelta: {gameplays[indexOfSelectedMode].Name}.");
                }
                else
                { handler.WriteStringToUI($"Modalità scelta ({selectedMode}) non valida."); }
            }

            return gameplays[indexOfSelectedMode];

        }


    }
}
