using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using CnsApp09_Anagrams.IUIHandlers;
//using CnsApp09_Anagrams.AnagramRepos;


namespace CnsApp09_Anagrams.Gameplays
{
    /// <summary>
    /// Gameplay di tipo "Training", allenamento.
    /// Data una parola immessa, visualizza tutti i suoi anagrammi (presenti nel dizionario dato).
    /// </summary>
    class Training : IGameplay
    {
        public string Name => "Training";
        public string Description => "Data una parola immessa, visualizza tutti i suoi anagrammi.";
        public string Code => "t";

        public void RunGameplay(IAnagramRepo chosenRepo, List<IUIHandler> usedUIHandlers)
        {
            foreach (IUIHandler handler in usedUIHandlers)
            {
                string inWord = "?";
                while (inWord != "000")
                {


                    handler.WriteStringToUI($" ");
                    handler.WriteStringToUI($"Modalità {Name}: {Description}");
                    handler.WriteStringToUI($" ");

                    inWord = handler.AskForString("Immettere una parola (immettere «000» per uscire dalla modalità) ...");

                    if (inWord == "000")
                    { break; }

                    List<string> anagramList = new List<string>();
                    anagramList = chosenRepo.ReturnFullAnagramList();
                    anagramList = chosenRepo.FromWordToAnagramList(inWord);

                    handler.WriteStringToUI($"Lista d\'anagrammi di «{inWord}»:");

                    foreach (string anagram in anagramList)
                    {
                        handler.WriteStringToUI($" {anagram}");
                    }

                }
            }
        }


        public void GetDescription(List<IUIHandler> usedUIHandlers)
        {
            foreach (IUIHandler handler in usedUIHandlers)
            { handler.WriteStringToUI(Description); }
        }
    }
}