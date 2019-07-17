/* La principale differenza fra lambda e fx, è il comportamento della variabile «this»: 
  * Con le lambda, il this è riferito allo scope in cui è contenuta;
  * Con le fx, il this è riferito da chi l'invoca, dalle condizioni in cui viene chiamata, se viene invocata tramite «call()» o «apply()», ed altro. */

 var nm = "Global'sName\\";
 var sn = "Global'§urnme\\";

var oggetto01 = {
    nm:"/\\/ome!", 
    sn:"cog/\\/ome!", 
    complNm_FxInsideObj: function complName01() {
            return this.nm + " - " + this.sn;
        },
    complNm_LambdaInsideObj: () => { this.nm + " - " + this.sn; },
    complNm_FxOutsideObj: complName02
}

function complName02() {
    return this.nm + " - " + this.sn;
}

function complName03(obj) {
    return obj.nm + " _ " + obj.sn;
}



    //main

    /* Ritornano il nome della fx e che sono fx (meno la 4ª che prende ha già i "parametri" () con i dati presi dal "global" («undefined» ed «undefined») e gira). */
    console.log('Con l\'oggetto (oggetto01) già pronto con variabili e funzioni:');
    console.log('Chiamata "diretta" oggetto01.fx, senza "()" (tranne la 4ª ch\'è "esterna"):');
    console.log(oggetto01.complNm_FxInsideObj);
    console.log(oggetto01.complNm_LambdaInsideObj);
    console.log(oggetto01.complNm_FxOutsideObj);
    console.log(complName02());
    console.log(oggetto01.complName03);
    
    
    //Non può funzionare perché non è definita all'infuori di «oggetto01».
    //console.log(complName01());
    
    console.log();
    
    console.log('Chiamata "diretta" oggetto01.fx(), con "()" (tranne la 4ª ch\'è "esterna"):');
    console.log(oggetto01.complNm_FxInsideObj());
    console.log(oggetto01.complNm_LambdaInsideObj());
    console.log(oggetto01.complNm_FxOutsideObj());
    console.log(complName02());
    console.log('X\toggetto01.complName03()');
    console.log(complName03(oggetto01));
    
    console.log();
    
    console.log('Con un oggetto diverso (object02) con solo le variabili, senza le funzioni:');

    var object02 = {
        nm:"/\\/ame?", 
        sn:"sur/\\/ame?", 
        }

console.log('Chiamata "diretta" oject02.fx, senza "()" (tranne la 4ª ch\'è "esterna"):');
console.log(object02.complNm_FxInsideObj);
console.log(object02.complNm_LambdaInsideObj);
console.log(object02.complNm_FxOutsideObj);
console.log(complName02());

console.log();

console.log('Chiamata "diretta" object02.fx(), con "()" (tranne la 4ª ch\'è "esterna"):');
console.log('Non possono funzionare perché all\'interno dell\'oggetto non vengono definite le funzioni.');
console.log("X\tobject02.complNm_FxInsideObj()");
console.log("X\tobject02.complNm_LambdaInsideObj()");
console.log("X\tobject02.complNm_FxOutsideObj()");
console.log(complName02());

console.log();

console.log('.create');
console.log('')