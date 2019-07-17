console.log("Hello world!");

// I import the functionalities of a library
// with the 'require' keywork, putting them in a variable:
const _ = require('underscore');

let array = [ 1, 2, 3, 4, 5 , 6 ];

// I can then use the variable, with its functions:
console.log(_.any(array, i => i > 5));
console.log(_.all(array, i => i < 6));
console.log(_.groupBy(array, i => i % 2 == 0));
