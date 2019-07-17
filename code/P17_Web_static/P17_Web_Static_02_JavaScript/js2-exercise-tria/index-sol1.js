// Tic Tac Toe game
// with random choice for both players.

const PLAYER1 = "O";
const PLAYER2 = "X";
const EMPTY_CELL = " ";

function initializeGrid() {
    let grid = []
    for (let i = 0; i < 9; i++) {
        grid[i] = " ";
    }
    return grid;
}

function switchPlayer(p) {
    if (p == PLAYER1) {
        return PLAYER2;
    } else if (p == PLAYER2) {
        return PLAYER1;
    } else {
        throw new Error("Unknown player");
    }
}

function printGrid(grid) {
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

function chooseCellOnGrid(grid, player) {
    do {
        var choice = getRandomInt();
    }
    while(grid[choice] != EMPTY_CELL);
    grid[choice] = player;
}

function trioPresent(grid) {
    // *** more verbose and ripetitive implementation: ***
    // // 3 rows
    // for(let i = 0; i < 9; i += 3) {
    //     if (grid[i] != EMPTY_CELL && grid[i+1] == grid[i] && grid[i+2] == grid[i+1]) {
    //         return true;
    //     }
    // }
    // // 3 columns
    // for(let i = 0; i < 3; i += 1) {
    //     if (grid[i] != EMPTY_CELL && grid[i+3] == grid[i] && grid[i+6] == grid[i+3]) {
    //         return true;
    //     }
    // }

    // // 2 diagonals
    // if (grid[0] != EMPTY_CELL && grid[4] == grid[0] && grid[8] == grid[4]) {
    //     return true;
    // }
    // if (grid[2] != EMPTY_CELL && grid[4] == grid[2] && grid[6] == grid[4]) {
    //     return true;
    // }

    // // no trio
    // return false;

    // *** more concise implementation: ***
    var possibilities = [
        [ 0, 1, 2 ],
        [ 3, 4, 5 ],
        [ 6, 7, 8 ],
        [ 0, 3, 6 ],
        [ 1, 4, 7 ],
        [ 2, 5, 8 ],
        [ 0, 4, 8 ],
        [ 2, 4, 6 ]
    ]

    for (let trio of possibilities) {
        if (grid[trio[0]] != EMPTY_CELL &&
            grid[trio[0]] == grid[trio[1]] &&
            grid[trio[1]] == grid[trio[2]]) {
            return true;
        }
    }
    return false;
}

function noMoreSpace(grid) {
    for (let cell of grid) {
        if (cell == EMPTY_CELL) {
            return false;
        }
    }
    return true;
}

function playGame() {
    var player = PLAYER1;
    var grid = initializeGrid();

    while(true) {
        chooseCellOnGrid(grid, player);
        printGrid(grid);
        if (trioPresent(grid)) {
            console.log(`player ${player} won!`);
            break;
        } else if (noMoreSpace(grid)) {
            console.log("match even!");
            break;
        }
        player = switchPlayer(player);
    }
}
playGame();
