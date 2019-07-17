using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    class JsonSaver : SaverToX
    {
        string SaverName = "Json Saver";
        string OutNamefile = "JsonStrings.json";

        string separator_KeyVal = ":";
        string separator_Data = ",";
        string strOpening = "\"";
        string strClosing = "\"";

        string recordOpening = "{";
        string recordClosing = "}";

        string fullNameOp = "\"FullName\"";
        string fullNameCl = "";

        string ageOp = "\"Opening\"";
        string ageCl = "";

        string salaryOp = "\"Salary\"";
        string salaryCl = "";

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