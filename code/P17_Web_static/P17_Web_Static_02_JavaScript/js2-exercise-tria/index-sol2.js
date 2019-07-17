// Tic Tac Toe game
// with random choice for both players.

const PLAYER1 = "O";
const PLAYER2 = "X";
const EMPTY_CELL = " ";

var player;
var grid;
var possibilities;

function initializeGrid() {
    grid = []
    for (let i = 0; i < 9; i++) {
        grid[i] = " ";
    }
}

function initializePossibilities() {
    possibilities = [
        [ 0, 1, 2 ],
        [ 3, 4, 5 ],
        [ 6, 7, 8 ],
        [ 0, 3, 6 ],
        [ 1, 4, 7 ],
        [ 2, 5, 8 ],
        [ 0, 4, 8 ],
        [ 2, 4, 6 ]
    ];
}

function switchPlayer() {
    if (player == PLAYER1) {
        player = PLAYER2;
    } else if (player == PLAYER2) {
        player = PLAYER1;
    } else {
        throw new Error("Unknown player");
    }
}

function printGrid() {
    var message =
` ${grid[0]} │ ${grid[1]} │ ${grid[2]}
───┼───┼───
 ${grid[3]} │ ${grid[4]} │ ${grid[5]}
───┼───┼───
 ${grid[6]} │ ${grid[7]} │ ${grid[8]} 
`;
    console.log(message);
}

function getRandomInt() {
    return Math.floor(Math.random() * 9);
}

function chooseCellOnGrid() {
    do {
        var choice = getRandomInt();
    }
    while(grid[choice] != EMPTY_CELL);
    grid[choice] = player;
}

function trioPresent() {
    for (let trio of possibilities) {
        if (grid[trio[0]] != EMPTY_CELL &&
            grid[trio[0]] == grid[trio[1]] &&
            grid[trio[1]] == grid[trio[2]]) {
            return true;
        }
    }
    return false;
}

function noMoreSpace() {
    for (let cell of grid) {
        if (cell == EMPTY_CELL) {
            return false;
        }
    }
    return true;
}

function playGame() {
    initializePossibilities();
    initializeGrid();
    player = PLAYER1;

    while(true) {
        chooseCellOnGrid();
        printGrid();
        if (trioPresent()) {
            console.log(`player ${player} won!`);
            break;
        } else if (noMoreSpace()) {
            console.log("match even!");
            break;
        }
        switchPlayer(player);
    }
}
playGame();
