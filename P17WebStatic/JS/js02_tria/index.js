/* Caratteri per la griglia. */
var topLine='╔═╤═╤═╗';
var vExLine='║';
var vInLine='║';
var hInLine='╟═╬═╬═╢';
var bottomL='╚═╧═╧═╝';

/*
       /   /
    X / X / X
  ---/---/---
  X / X / X
---/---/---
X / X / X
 /   /
*/

/* Caratteri per le celle. */
//var nocell='░';
var noCel='░';
var xCell='x';
var oCell='o';
var xWCel='X';
var oWCel='O';

// ×●■▲ ×○□∆ XO#^ ><()[]/\

/* Print delle griglie */
function drawEmptyGrid() {
    console.clear();
    console.log(`${topLine}`);
    console.log(`${vExLine} ${vInLine} ${vInLine} ${vExLine}`);
    console.log(`${hInLine}`);
    console.log(`${vExLine} ${vInLine} ${vInLine} ${vExLine}`);
    console.log(`${hInLine}`);
    console.log(`${vExLine} ${vInLine} ${vInLine} ${vExLine}`);
    console.log(`${bottomL}`);
};

function drawMinimumEmptyGrid() {
    console.log('...');
    console.log('...');
    console.log('...');
}

function drawPopulated3x3GridFrom1x9Array(ry) {
    console.log(`${topLine}`);
    console.log(`${vExLine}${ry[0]}${vInLine}${ry[1]}${vInLine}${ry[2]}${vExLine}`);
    console.log(`${hInLine}`);
    console.log(`${vExLine}${ry[3]}${vInLine}${ry[4]}${vInLine}${ry[5]}${vExLine}`);
    console.log(`${hInLine}`);
    console.log(`${vExLine}${ry[6]}${vInLine}${ry[7]}${vInLine}${ry[8]}${vExLine}`);
    console.log(`${bottomL}`);
}

function drawMinimumPopulated3x3GridFrom1x9Array(ry) {
    console.log(ry[0],ry[1],ry[2]);
    console.log(ry[3],ry[4],ry[5]);
    console.log(ry[6],ry[7],ry[8]);
}


/* "Gestione" array 1x9 -> 3x3. */
function get1x9Array() {
    return [11,12,13,21,22,23,31,32,33];
}

function full1x9ArrayWithSymbol(symbol) {
    return [symbol,symbol,symbol,symbol,symbol,symbol,symbol,symbol,symbol];
}

function getCellIndexFor1x9ArrayFrom3x3(x,y) {
    return ((x-1)*3)+(y-1);
}

function getXYCellValuesFrom1x9Array(x,y,ry) {
    return ry[getCellIndexFor1x9ArrayFrom3x3(x,y)];
}

function getXCellIndexFromNthElementOf1x9Array(nth) {
    //grezzerrimo
    if (nth>5)      {return 3;}
    else if (nth<3) {return 1;}
    return 2;
}

function getYCellIndexFromNthElementOf1x9Array(nth) {
    //grezzerrimo
    if (nth==8) {return 3;}
    else if (nth==7) {return 2;}
    else if (nth==6) {return 1;}
    else if (nth==5) {return 3;}
    else if (nth==4) {return 2;}
    else if (nth==3) {return 1;}
    else if (nth==2) {return 3;}
    else if (nth==1) {return 2;}
    return 1;
}

function setXYCellTo1x9ArrayWithValue(x,y,ry,value) {
    ry[getCellIndexFor1x9ArrayFrom3x3(x,y)]=value;
    return ry;
}

/* Stampa il contenuto dell'array. */
function printArray(ry){
    ry.forEach(element => {console.log(element)});
}

/* » Algoritmo di gioco: */

/* Controllo della vittoria. */

/* Controllo se la cella è riempita con quel simbolo. */
function isXYCellOfArrayThisSymbol(x,y,ry, symbol) {
    return ry[getXYCellValuesFrom1x9Array(x,y,ry)]==symbol;
}

function isXYCellOfArrayEmpty(x,y,ry) {
    return isXYCellOfArrayThisSymbol(x,y,ry, noCel);
}

/* Acqisisci celle libere. */

/* « Algoritmo di gioco: */

/* main */
drawEmptyGrid();
console.log('');
drawMinimumEmptyGrid();

var flatgrid = get1x9Array();

/* V Controllo get1x9array(); */
// printarray(flatgrid);

/* V Controllo aggiunta di un valore all' interno dell'array con setXYcellfrom1x9arraywithvalue(x,y,ry,value); :*/
// flatgrid=setXYcellfrom1x9arraywithvalue(1,1,flatgrid,"nuovoval");
// printarray(flatgrid);

/* V Controllo di getXYcellindexfor1x9array(x,y) */
// console.log('1,1 ->',getXYcellindexfor1x9array(1,1));
// console.log('1,2 ->',getXYcellindexfor1x9array(1,2));
// console.log('1,3 ->',getXYcellindexfor1x9array(1,3));
// console.log('2,1 ->',getXYcellindexfor1x9array(2,1));
// console.log('2,2 ->',getXYcellindexfor1x9array(2,2));
// console.log('2,3 ->',getXYcellindexfor1x9array(2,3));
// console.log('3,1 ->',getXYcellindexfor1x9array(3,1));
// console.log('3,2 ->',getXYcellindexfor1x9array(3,2));
// console.log('3,3 ->',getXYcellindexfor1x9array(3,3));

drawMinimumPopulated3x3GridFrom1x9Array(flatgrid);

console.log('');

console.log('Aggiunta X! in 3,3:');
flatgrid=setXYCellTo1x9ArrayWithValue(3,3,flatgrid,"X!");
drawMinimumPopulated3x3GridFrom1x9Array(flatgrid);

console.log('');

console.log('Riempimento con simbolo per vuoto');
flatgrid=full1x9ArrayWithSymbol(noCel);
flatgrid=setXYCellTo1x9ArrayWithValue(3,3,flatgrid,"X");
drawMinimumPopulated3x3GridFrom1x9Array(flatgrid);

console.log('cella 11 vuota?',isXYCellOfArrayThisSymbol(1,1,flatgrid,noCel));
console.log('cella 33 vuota?',isXYCellOfArrayThisSymbol(3,3,flatgrid,noCel));

console.log('1,1',getXYCellValuesFrom1x9Array(1,1,flatgrid),noCel);
console.log('3,3',getXYCellValuesFrom1x9Array(3,3,flatgrid),noCel);

console.log('1,1',getXYCellValuesFrom1x9Array(1,1,flatgrid),noCel, (getXYCellValuesFrom1x9Array(1,1,flatgrid)==noCel));
console.log('3,3',getXYCellValuesFrom1x9Array(3,3,flatgrid),noCel, (getXYCellValuesFrom1x9Array(3,3,flatgrid)==noCel));

console.log(getXYCellValuesFrom1x9Array(1,1,flatgrid)==noCel);

console.log(drawPopulated3x3GridFrom1x9Array(flatgrid));

/* V Test get_col/row da indice 1x9 array. */
// console.log('0 1ª ry[0], 1,1',getXCellIndexFromNthElementOf1x9Array(0),getYCellIndexFromNthElementOf1x9Array(0));
// console.log('1 2ª ry[1], 1,2',getXCellIndexFromNthElementOf1x9Array(1),getYCellIndexFromNthElementOf1x9Array(1));
// console.log('2 3ª ry[2], 1,3',getXCellIndexFromNthElementOf1x9Array(2),getYCellIndexFromNthElementOf1x9Array(2));
// console.log('3 4ª ry[3], 2,1',getXCellIndexFromNthElementOf1x9Array(3),getYCellIndexFromNthElementOf1x9Array(3));
// console.log('4 5ª ry[4], 2,2',getXCellIndexFromNthElementOf1x9Array(4),getYCellIndexFromNthElementOf1x9Array(4));
// console.log('5 6ª ry[5], 2,3',getXCellIndexFromNthElementOf1x9Array(5),getYCellIndexFromNthElementOf1x9Array(5));
// console.log('6 7ª ry[6], 3,1',getXCellIndexFromNthElementOf1x9Array(6),getYCellIndexFromNthElementOf1x9Array(6));
// console.log('7 8ª ry[7], 3,2',getXCellIndexFromNthElementOf1x9Array(7),getYCellIndexFromNthElementOf1x9Array(7));
// console.log('8 9ª ry[8], 3,3',getXCellIndexFromNthElementOf1x9Array(8),getYCellIndexFromNthElementOf1x9Array(8));

