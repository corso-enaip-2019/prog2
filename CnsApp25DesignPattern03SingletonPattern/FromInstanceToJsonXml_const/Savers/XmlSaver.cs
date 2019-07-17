using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    class XmlSaver : SaverToX
    {
        string SaverName = "Xml Saver";
        string OutNamefile = "XmlStrings.xml";

        string separator_KeyVal = "";
        string separator_Data = "";
        string strOpening = "";
        string strClosing = "";

        string recordOpening = "<Person>";
        string recordClosing = "</Person>";

        string fullNameOp = "<FullName>";
        string fullNameCl = "</FullName>";

        string ageOp = "<Age>";
        string ageCl = "</Age>";

        string salaryOp = "<Salary>";
        string salaryCl = "</Salary>";


        public override string FromPersonToString(Person p)
        {

            return
                recordOpening +

                fullNameOp + separator_KeyVal +
                strOpening + p.FullName + strClosing +
                fullNameCl +

                separator_Data +

                ageOp + separator_KeyVal +
                p.Age.ToString() +
                ageCl +

                separator_Data +

                salaryOp + separator_KeyVal +
                p.Salary.ToString() +
                salaryCl +

                recordClosing;
        }

        //public override string FromPersonToString(Person p) => recordOpening + fullNameOp + separator_KeyVal + strOpening + p.FullName + strClosing + fullNameCl + separator_Data + ageOp + separator_KeyVal + p.Age.ToString() + ageCl + separator_Data + salaryOp + separator_KeyVal + p.Salary.ToString() + salaryCl + recordClosing;
    }
}