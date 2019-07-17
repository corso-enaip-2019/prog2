console.log("Hell-O World!");

var aVariable="a striing value";
console.log(aVariable);

aVariable=314;
console.log(aVariable);

if(aVariable) {
    console.log("\tthis is the double of "+aVariable+": "+aVariable*2+".");
}

console.log("\t\t\t\t\t\t\t\t\t²+");

if(aVariable) {
    console.log("√\tEntrato nel ramo \"true\".");
}
else {
    console.log("×\tEntrato nel ramo \"false\".");
}

console.log("");

console.log("    ♦♦♦♦♦♦♦♦♦♦♦");
console.log("   ♦ ♦♦   ♦♦ ♦♦");
console.log("  ♦         ♦ ♦");
console.log(" ♦ ♦♦   ♦♦ ♦  ♦");
console.log("♦♦♦♦♦♦♦♦♦♦♦   ♦");
console.log("♦         ♦ ♦ ♦");
console.log("♦     ♦♦  ♦   ♦");
console.log("♦         ♦  ♦ ");
console.log("♦  ♦♦     ♦ ♦  ");
console.log("♦         ♦♦   ");
console.log("♦♦♦♦♦♦♦♦♦♦♦    ");

console.log("");

console.log("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
console.log("♦♦♦♦♦           ♦");
console.log("♦♦♦♦ ♦  ♦♦♦  ♦  ♦");
console.log("♦♦♦ ♦♦♦♦♦♦♦♦♦ ♦ ♦");
console.log("♦♦ ♦  ♦♦♦  ♦ ♦♦ ♦");
console.log("♦           ♦♦♦ ♦");
console.log("♦ ♦♦♦♦♦♦♦♦♦ ♦ ♦ ♦");
console.log("♦ ♦♦♦♦♦  ♦♦ ♦♦♦ ♦");
console.log("♦ ♦♦♦♦♦♦♦♦♦ ♦♦ ♦♦");
console.log("♦ ♦♦  ♦♦♦♦♦ ♦ ♦♦♦");
console.log("♦ ♦♦♦♦♦♦♦♦♦  ♦♦♦♦");
console.log("♦           ♦♦♦♦♦");
console.log("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");

console.log("");

var number1=101;
console.log("Is the number « "+number1+" » prime?");
var isPrime=true;
for(var i=2;i<number1;i++){
    if(number1%i){
        isPrime=false;
        break;
    }
}

console.log("");

console.log(isPrime?"√\tThe number « "+number1+ " » IS prime!":"×\tThe number « "+number1+ " » IS NOT prime.");

console.log("");

console.log("stringa « \"0\" » = numero « 0 »?\t","0"==0);
console.log("array vuoto « [] » = numero « 0 »?\t",[]==0);
console.log("stringa « \"0\" » = array vuoto « [] »?\t","0"==[]);

console.log("");

console.log("▼ == ►\t0\t\"0\"\t\'0\'\t[]\t\"\"\t\" \"\tnull\tfalse\ttrue");
console.log("");
console.log("0"     ,"\t","TRUE"       ,"\t",0=="0"     ,"\t",0=='0'     ,"\t",0==[]      ,"\t",0==""      ,"\t",0==" "     ,"\t",0==null        ,"\t",0==false       ,"\t",0==true);
console.log("\"0\"" ,"\t","0"==0     ,"\t","TRUE"   ,"\t","0"=='0'   ,"\t","0"==[]    ,"\t","0"==""    ,"\t","0"==" "   ,"\t","0"==null      ,"\t","0"==false     ,"\t","0"==true);
console.log("\'0\'" ,"\t",'0'==0     ,"\t",'0'=="0"   ,"\t","TRUE"   ,"\t",'0'==[]    ,"\t",'0'==""    ,"\t",'0'==" "   ,"\t",'0'==null      ,"\t",'0'==false     ,"\t",'0'==true);
console.log("");
console.log("[]"    ,"\t",[]==0      ,"\t",[]=="0"    ,"\t",[]=='0'    ,"\t","TRUE"     ,"\t",[]==""     ,"\t",[]==" "    ,"\t",[]==null       ,"\t",[]==false      ,"\t",[]==true);
console.log("\"\""  ,"\t",""==0      ,"\t",""=="0"    ,"\t",""=='0'    ,"\t",""==[]     ,"\t","TRUE"     ,"\t",""==" "    ,"\t",""==null       ,"\t",""==false      ,"\t",""==true);
console.log("\" \"" ,"\t"," "==0     ,"\t"," "=="0"   ,"\t"," "=='0'   ,"\t"," "==[]    ,"\t"," "==""    ,"\t","TRUE"   ,"\t"," "==null      ,"\t"," "==false     ,"\t"," "==true);
console.log("");
console.log("null"  ,"\t",null==0    ,"\t",null=="0"  ,"\t",null=='0'  ,"\t",null==[]   ,"\t",null==""   ,"\t",null==" "  ,"\t","TRUE"      ,"\t",null==false   ,"\t",null==true);
console.log("false" ,"\t",false==0   ,"\t",false=="0" ,"\t",false=='0' ,"\t",false==[]  ,"\t",false==""  ,"\t",false==" " ,"\t",false==null ,"\t","TRUE"        ,"\t",false==true);
console.log("true"  ,"\t",true==0    ,"\t",true=="0"  ,"\t",true=='0'  ,"\t",true==[]   ,"\t",true==""   ,"\t",true==" "  ,"\t",true==null  ,"\t",true==false   ,"\t","TRUE");

console.log("");

console.log('parseInt("15f12") ->',parseInt("15f12"));
console.log('parseInt("f15f12") ->',parseInt("f15f12"));

console.log("");

var ry01=['Ciao',',','come','stai','?','Io','sto','bene',',','grazie','della','domanda','!'];

function print1st10nr(inputRy) {
    console.log();
    for (let i = 0; i < 10; i++) {
        console.log(inputRy[i]+" ");
    }
};

print1st10nr(ry01);