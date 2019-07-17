using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;

namespace FromInstanceToJsonXml_const.Savers
{
    class RflctnJsonSaver : SaverToX
    {
        const string SaverName = "Reflection - Json Saver";
        const string OutNamefile = "JsonStrings.json";

        /* escape-combos:
         * «"» = «"\""» (escape+") o = [non funziona colle verbatim]
         * «'» = «"\'"» (escape+') o = «@"'"» (non è obbligatorio l'escape di «'»)
         * «\» = «"\\"» (escape+\) o = «@"\"            */

        const string separator_KeyVal = ":";
        const string separator_ValKey = ",";

        const string recordOpening = "{";
        const string recordClosing = "}";

        const string KeyOp = "\"";
        const string KeyCl = "\"";
        const string ValOp = "";
        const string ValCl = "";

        const string strOpening = "\"";
        const string strClosing = "\"";
        const string nullValue = "\"null\"";




        public override string FromPersonToString(Person p)
        {
            return
                recordOpening +

                //                fullNameOp + Separator_KeyVal +
                strOpening + p.FullName + strClosing +
                //               fullNameCl +

                //               separator_DataData +

                //              ageOp + Separator_KeyVal +
                p.Age.ToString() +
                //               ageCl +

                //               separator_DataData +

                //               salaryOp + Separator_KeyVal +
                p.Salary.ToString() +
                //                salaryCl +

                recordClosing;

            //return recordOpening + fullNameOp + separator_KeyVal + strOpening + p.FullName + strClosing + fullNameCl + separator_Data + ageOp + separator_KeyVal + p.Age.ToString() + ageCl + separator_Data + salaryOp + separator_KeyVal + p.Salary.ToString() + salaryCl + recordClosing;
        }

        //public string FromInstanceToString(IEnumerable<T> instance)
        //{
        //    string classNameOpOp = "";   //es.Xml: 1°"<" di     <nomeClasse> ... [contenuto della classe in key-val ...] </nomeClasse>
        //    string classNameOpCl = "";   //es.Xml: 1°">" di     <nomeClasse> ... [contenuto della classe in key-val ...] </nomeClasse>
        //    string classNameClOp = "";   //es.Xml:ult"<" di     <nomeClasse> ... [contenuto della classe in key-val ...] </nomeClasse>
        //    string classNameClCl = "";   //es.Xml:ult">" di     <nomeClasse> ... [contenuto della classe in key-val ...] </nomeClasse>
        //
        //    string outStr_Start = recordOpening;
        //    string outStr_End = "";
        //    string outStr_Body = recordClosing;

        //    outStr_Start = recordOpening;


        /* Per ogni prop pubblica, leggi il nome della prop ed il suo dato(convertito in stringa).
         * */
        //    foreach (var publicProp in instance)
        //    {
        //        outStr_Body += publicProps.Name.ToString();
        //        outStr_Body += separator_KeyVal;

        //        if (publicProps.Value is null)
        //        {
        //            outStr_Body += nullValue;
        //        }

        //        if (publicProps.Value is string)
        //            outStr_Body += strOpening + publicProps.Value + strOpening;
        //        else
        //            outStr_Body += publicProps.Value.ToString();

        //        if (!isLastProp(publicProp))
        //            outStr_Body += separator_Data;
        //    }

        //    return (outStr_Start + outStr_End + outStr_Body);
        //}


    }
}