using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    abstract class SaverToX
    {
        string SaverName { get; }
        string OutNamefile { get; }

        string separator_KeyVal;
        string separator_Data;
        string strOpening;
        string strClosing;

        string recordOpening;
        string recordClosing;

        string fullNameOp;
        string fullNameCl;

        string ageOp;
        string ageCl;

        string salaryOp;
        string salaryCl;

        public void Save(Person p)
        {
            CaricaStrNelTxt(FromPersonToString(p));
        }

        public void ShowToScreen(Person p)
        {
            Console.WriteLine(FromPersonToString(p));
        }

        public bool CaricaStrNelTxt(string str)
        {
            bool riuscito = false;
            return riuscito;
        }

        public abstract string FromPersonToString(Person p);
    }
}