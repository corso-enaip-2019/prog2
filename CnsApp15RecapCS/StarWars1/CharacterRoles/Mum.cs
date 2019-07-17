using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars1
{
    class Mum : Parent
    {
        public Baby Child { get; set; }
        public int Patience { get; set; }

        public Mum(string name)
              : base(name)
        {
            Patience = 3;
        }

        #region Metodi pubblici
        public void MakeBaby(Dad dad, string childName)
        {
            Baby baby = new Baby(childName);
            Child = baby;
            dad.Child = baby;
            //non è possibile connvertire da «StarWars1.Dad» a «StarWars1.Parent»
            //baby.AddParent(dad);
            baby.AddParent(this);


            Console.WriteLine($"{Name} e {dad.Name} hanno fatto un figlio chiamato {childName}.");
        }

        public override void ComfortChild(Baby baby)
        {
            /* ??? */

            if (Patience > 0)
            {
                Console.WriteLine($"{Name} prende in braccio {baby.Name} e lo culla.");
            }
            else
            {
                Console.WriteLine($"{Name} scappa con Chewbacca.");
            }

            Patience--;

        }

        #endregion

    }
}