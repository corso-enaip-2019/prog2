using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b.TypesOfEmployment
{
    class Commissioneer : TypeOfEmployment
    {

        public string _name;
        public string Name_ { get { return _name; } set { _name = value; } }


        public override string Description { get; set; }
        //public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IPayCalc CalculatePay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public Commissioneer()
        {
            Name = "A commissione";
            Description = "Il suo stipendio viene calcolato in base alle ore lavorate.";
        }
    }
}
