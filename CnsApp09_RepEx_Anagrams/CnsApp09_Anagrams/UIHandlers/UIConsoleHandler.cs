using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams.UIHandlers
{
    class UIConsoleHandler : IUIHandler
    {

        /// <summary>
        /// Mostra a console il messaggio immesso come parametro e c'aggiunge un «" \a».
        /// Ritorna l' input dell'utente sotto forma di string in lower-case.
        /// Per ricevere l'input dell'utente usa «ReadInputtedString_OutputAllLowercase()».
        /// Non accetta stringhe vuote o null (risponde con un relativo messaggio d'errore a consolle) come messaggio da visualizzare.
        /// </summary>
        /// <param name="InviteMessage">Messaggio (string) che verrà visualizzato a consolle (se si vuole un «a capo» dopo il messaggio si deve aggiungerlo con un «\n»).</param>
        /// <returns></returns>
        public string AskForString(string InviteMessage)
        {
            InviteMessage = InviteMessage ?? "\aMessaggio non immesso (null) ...";
            //if (InviteMessage==null)
            // { throw new NotImplementedException()}

            InviteMessage = (InviteMessage == "") ? "Messaggio non immesso (stringa vuota) ..." : InviteMessage;
            //if (InviteMessage=="")
            // { throw new NotImplementedException()}

            Console.Write(InviteMessage);
            Console.Write(" \a");

            return ReadInputtedString_OutputAllLowercase();
            //return ReadInputtedString_OutputAllLowercase().ToLower();
        }

        public string ReadInputtedString_OutputAllLowercase()
        {
            string outputString = "";
            bool sensedInput = false;

            const string IN_DATA_NOT_VALID = "\a\tDato immesso non valido";

            while (!sensedInput)
            {
                outputString = Console.ReadLine();

                if (outputString == null)
                {
                    Console.WriteLine($"{IN_DATA_NOT_VALID} (null) ...");
                    Console.WriteLine();
                    Console.Write("Immettere nuovo dato: \a");
                    sensedInput = false;
                    //throw new NotImplementedException()
                }
                else if (outputString=="")
                {
                    Console.Write("\a");
                    sensedInput = false;
                }
                else
                { sensedInput = true; }

            }
            return outputString.ToLower();
        }

        public void WriteStringToUI(string MessageToDisplay)
        { Console.WriteLine(MessageToDisplay); }
    }
}