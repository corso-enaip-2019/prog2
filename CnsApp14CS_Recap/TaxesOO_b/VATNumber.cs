using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesOO_b
{
    abstract class VATNumber
    {
        public string VATCode;
        public List<decimal> Bills;

        public abstract void CalculateAndPrint();
        public abstract void AddBill();
        public abstract void AddExpense();
    }

    class VATNumberNormal : VATNumber
    {
        const decimal VAT_PERCENTAGE = 22m; // IVA 22%
        const decimal INCOME_TAX = 23m; // IRPEF 23%

        public List<decimal> Expenses;

        public override void AddBill()
        {
            throw new NotImplementedException();
        }

        public override void AddExpense()
        {
            throw new NotImplementedException();
        }

        override public void CalculateAndPrint()
        { }

        private decimal CalculateProfit()
        {
            decimal outDec = 0m;
            return outDec;
        }
    }

    class VATNumberSimple : VATNumber
    {
        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78m; // [% d'importo tassabile se P.IVA"semplice", 78%]
        const decimal SIMPLE_TAX_PERCENTAGE = 15m; // [% aliquota se P.IVA"semplice"?, 78%]

        public override void AddBill()
        {
            throw new NotImplementedException();
        }

        public override void AddExpense()
        {
            throw new NotImplementedException();
        }

        override public void CalculateAndPrint()
        { }
    }
}