using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190307 */
/* Esempio di Class, una lampadina. */

namespace CnsApp04Classes
{
    class Bulb
    {
        #region Attributi
        /* Attributo private. */
        int _consumption_Watt;

        /* Attributo private. */
        /* Non serve, con la property col "backing field". */
        //int _luminousFlux_lumen; 

        bool _turnedOn; /* Attributo/Stato private. */
        #endregion

        #region Proprieta
        /* Property (public). */
        public int Consumption_Watt
        {
            get
            { return _consumption_Watt; }
            set
            { _consumption_Watt = value; }
        }

        /* Property (public). */
        // Usando il "prop", non serve questa.
        /*
        public int LuminousFlux_lumen
        {
            get
            { return _luminousFlux_lumen; }
            set
            { _luminousFlux_lumen = value; }
        }
        */

        /* Property (public) con il "prop compatto". */
        public int LuminousFlux { get; set; }

        //public int LuminousFlux { get; set; }             -> Lettura e Scrittura pubbliche.
        //public int LuminousFlux { get; private set; }     -> Lettura pubblica e Scrittura privata (read only)

        public bool TurnedOn
        {
            get
            { return _turnedOn; }
            set
            { _turnedOn = value; }
        }
        #endregion

        #region Metodi
        public void TurnOn() /* Metodo della classe (ch'agisce su un attributo della classe). */
        { _turnedOn = true; }

        public void TurnOff() /* Metodo della classe (ch'agisce su un attributo della classe). */
        { _turnedOn = false; }

        /* Metodo della classe (ch'agisce su un attributo della classe). */
        /*
        public void TurnToggle()
        { _turnedOn = !(_turnedOn); }
        */
        #endregion

        #region Costruttori
        public Bulb()
        { }

        public Bulb(int consumption, int luminousFlux)
        {
            _turnedOn = false;

            _consumption_Watt = consumption;

            /* _luminousFlux_lumen "non esiste più" perché ho usato il prop ridotto (la variabile privata interna non è esplicitata). */
            LuminousFlux = luminousFlux;
        }
        #endregion
    }
}