using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    class JsonSaver : SaverToX
    {
        const string SaverName = "Json Saver";
        const string OutNamefile = "JsonStrings.json";

        const string separator_KeyVal = ":";
        const string separator_Data = ",";
        const string strOpening = "\""; // «\"» (escape+") = «"»
        const string strClosing = "\"";

        const string recordOpening = "{";
        const string recordClosing = "}";

        const string fullNameOp = "\"FullName\"";
        const string fullNameCl = "";

        const string ageOp = "\"Opening\"";
        const string ageCl = "";

        const string salaryOp = "\"Salary\"";
        const string salaryCl = "";

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

            //return recordOpening + fullNameOp + separator_KeyVal + strOpening + p.FullName + strClosing + fullNameCl + separator_Data + ageOp + separator_KeyVal + p.Age.ToString() + ageCl + separator_Data + salaryOp + separator_KeyVal + p.Salary.ToString() + salaryCl + recordClosing;
        }
    }
}