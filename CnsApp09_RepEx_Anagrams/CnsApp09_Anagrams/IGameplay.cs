using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams
{
    /// <summary>
    /// Modalità di gioco.
    /// Ogni Gameplay ha
    /// - un nome(string);
    /// - una sua descrizione (string);
    /// - un codice (string) per richiamarlo;
    /// - un metodo contenente il nucleo del Gameplay.
    /// - un metodo che ritorna la sua descrizione (del Gameplay).
    /// </summary>
    interface IGameplay
    {
        /// <summary>
        /// Nome (string) della modalità di gioco, in minuscolo.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Descrizione (string) della modalità di gioco.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Codice (string) con cui s'identifica un gameplay (per richiamarlo).
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Contiene il nucleo del Gameplay.
        /// </summary>
        /// <param name="chosenRepo">Il dizionario da usare nello svolgimento del gioco.</param>
        /// <param name="usedUIHandlers">Lista delle interfacce UI in ascolto.</param>
        void RunGameplay(IAnagramRepo chosenRepo, List<IUIHandler>usedUIHandlers);
    }
}