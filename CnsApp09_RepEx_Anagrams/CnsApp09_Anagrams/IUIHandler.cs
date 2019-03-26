using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams
{
    /// <summary>
    /// Gestisce l'I/O della relativa UI.
    /// Ogni UIHandler deve avere un metodo
    /// - che chieda all'utente l'immissione del dato e restituisca il dato immesso (string);
    /// - uno che analizzi il dato immesso
    /// - ed uno che scriva un messaggio (generico) in ingresso.
    /// </summary>
    interface IUIHandler
    {
        /// <summary>
        /// Mostra sull'UI il messaggio immesso come parametro (string) e restituisce il dato immesso dall'utente in lower-case.
        /// </summary>
        /// <param name="InviteMessage">Stringa che verrà visualizzata sull'UI richiedente l'input dall'utente.</param>
        /// <returns>La stringa immessa dall'utente (in lowercase).</returns>
        string AskForString(string InviteMessage);
        
        /// <summary>
        /// Una volta chiamata, controlla il dato in input dell'utente.
        /// Cicla finchè l'utente non immette una stringa valida (non vuota).
        /// Restituisce la stringa immessa (se valida) in lower-case.
        /// </summary>
        /// <returns>La stringa immessa dall'utente (in lowercase).</returns>
        string ReadInputtedString_OutputAllLowercase();

        /// <summary>
        /// Mostra sull'UI la stringa immessa come parametro.
        /// </summary>
        /// <param name="MessageToDisplay">Stringa che verrà visualizzata sull'UI.</param>
        void WriteStringToUI(string MessageToDisplay);
    }
}