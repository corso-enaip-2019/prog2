using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp04Classes
{
    class ToggleSwitch
    {
        void Click()
        {
            Bulb philips_Hue314;
            philips_Hue314 = new Bulb(400, 1200);

            /* Versione con semplice if. */
            /*
            if (philips_Hue314.TurnedOn)
            { philips_Hue314.TurnOff(); }
            else
            { philips_Hue314.TurnOn(); }
            */

            /* Versione con semplice ternario. */
            /*
            philips_Hue314.TurnedOn = (philips_Hue314.TurnedOn) ? false : true;
            */

            /* Versione con logica booleana pura. */
            philips_Hue314.TurnedOn = !(philips_Hue314.TurnedOn);



            Bulb ikea_Whalallah1500 = new Bulb(15, 600);



            return;
        }
    }
}