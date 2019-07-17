/* Associa l'oggetto JS partendo dall'ID-HTML/CSS. */
let jSPlayBoard = document.getElementById('playArea');

/* Crea l'oggetto JS partendo dall'ID-HTML/CSS. */
var jSResetGrid = document.getElementById('resetPlayArea');
/* Al click, invoca la fx. */
jSResetGrid.onclick = resetGrid;

function generateEmptyGrid(size) {
for(let i=0; i<size; i++) {
/* Crea il <div> "orizzontale". */
var jSCreatedHDiv = document.createElement('div');

/* Aggiungi a quel div la classe 'column' e `column#`. */
jSCreatedHDiv.classList.add('column');
jSCreatedHDiv.classList.add(`column${i}`);

for(let j=0; j<size; j++) {
    /* Crea il <div> della singola cella. */
    var jSCreatedCDiv = document.createElement('div');
    /* Aggiungi a quel div la classe 'singleCell', `singleCellXY`, `singleCellZ`, 'notYetClickedCell'. */
    jSCreatedCDiv.classList.add('singleCell');
    jSCreatedCDiv.classList.add(`singleCell${i}${j}`);
    jSCreatedCDiv.classList.add(`singleCell${(i*3)+j}`);
    jSCreatedCDiv.classList.add('notYetClickedCell');
    jSCreatedCDiv.innerHTML = '&nbsp;';

        // if ((i*3+j)%2==0) {
        //     jSCreatedCDiv.classList.add('notYetClickedCell');
        // }else{
        //     jSCreatedCDiv.classList.add('clickedCell');
        // }

    /* Se ci si clicca sopra, a quella cella verrà aggiunta la classe 'clickedCell' [e rimossa quella 'notYetClickedCell']. */
    jSCreatedCDiv.onclick = function clickOnCell(ed) { 
        if (isXTurn) {
            ed.target.classList.add('xClickedCell'); 
            ed.target.classList.remove('oClickedCell');     
        } else {
            ed.target.classList.add('oClickedCell'); 
            ed.target.classList.remove('xClickedCell'); 
        }
    
        // ed.target.classList.add(isXTurn?'xClickedCell':'oClickedCell'); 
        // ed.target.classList.remove(!isXTurn?'xClickedCell':'oClickedCell'); 
        ed.target.classList.remove('notYetClickedCell');
        // ev.target.classList.add('clickedCell'); 
        // ev.target.classList.remove('notYetClickedCell');
        changeTurn();
    };

        /* Aggiungi il <div> appena creato 'jSCreatedCDiv' all'elemento JS 'jSPlayBoard'. */
        jSCreatedHDiv.appendChild(jSCreatedCDiv);
    }

    /* Aggiungi il <div> appena creato 'jSCreateHdDiv' all'elemento JS 'jSPlayBoard'. */
        jSPlayBoard.appendChild(jSCreatedHDiv);
}}


function resetGrid() {
    /* Prendi tutti gl'elementi che hanno la classe 'singleCell' e mettili in un array (riferimento). */
    var allCells = document.getElementsByClassName('singleCell');

    /* Ad ogni cella dellì'array, rimuovi le classi 'clickedCell' ed aggiungile 'notYetClickedCell'. */
    for (let i = 0; i < allCells.length; i++) {
            alert(allCells[i])
            allCells[i].classList.remove('notYetClickedCell','oClickedCell','xClickedCell');
            allCells[i].ClassList.add('notYetClickedCell');
    }

    var trnld = document.getElementsByClassName('turnLed');
    trnld.ClassList.remove('notYetClickedCell','oClickedCell','xClickedCell');
    trnld.ClassList.add('notYetClickedCell');
    var inftxt = document.getElementsByClassName('infoText');
    inftxt.ClassList.remove('notYetClickedCell','oClickedCell','xClickedCell');
    inftxt.ClassList.add('notYetClickedCell');
}

function changeTurn(){
    // var jSTurnLED = document.getElementById('turnLed');
    // var jSInfoText = document.getElementById('infoText');
    // jSTurnLED.ClassList.remove('notYetClickedCell'/*,'oClicked','xClicked'*/);
    // jSInfoText.ClassList.remove('notYetClickedCell'/*,'oClicked','xClicked'*/);

    // notYetClickedCell
    // if (isXTurn) {
    //     jSTurnLED.ClassList.add('oClicked');
    //     jSTurnLED.ClassList.add('oClicked');
    // } else {
    //     jSTurnLED.ClassList.add('xClicked');
    //     jSTurnLED.ClassList.add('xClicked');
    // }
    alert(!isXTurn);
    isXTurn=!isXTurn;
    return isXTurn;
}

/* Anche se si clicca su d'un elemento interno a jSPlayBoard, si clicca anche sugl'elementi più esterni e si può far eseguire  una funzione a quest'elemento (in questo caso è una funzione vuota). */
// jSPlayBoard.onclick = function(ev) { }

/* "main" */
generateEmptyGrid(3);
var isXTurn = true;
changeTurn();