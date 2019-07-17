console.log("This is my first JavaScript app!");

var aVariable = "a string value";
console.log(aVariable);
aVariable = 123;
console.log(aVariable);

// JS is WEAKLY-TYPED: it tries to convert from a type to another
// to satisfy the required operations
if (aVariable) {
    console.log("this is the double: " + (aVariable * 2));
}
aVariable = 0;
if (aVariable) {
    console.log("this is the double: " + (aVariable * 2));
}
if (-100000000001) {
    console.log("the if was true");
} else {
    console.log("the if was false")
}

var a = "123";
var b = 56;

var sum = a + b;
var diff = a - b;
var prod = a * b;
var div = a / b;
console.log("sum: " + sum);
console.log("diff: " + diff);
console.log("prod: " + prod);
console.log("div: " + div);

var aa = "pippo";
sum = aa - b;
console.log("sum: " + sum);

// this is a line comment
/*
    this is
    a multi-line comment
*/

// FOR loop:
console.log("is 101 prime?");
var isPrime = true;
for(var i = 2; i < 101; i++) {
    if (101 % i == 0) {
        isPrime = false;
        break;
    }
}
isPrime ? console.log("YES") : console.log("NO");

// WHILE loop
console.log("print all the squares minor than 100");
var i = 1;
var square;
while (square = i*i < 100) {
    console.log(i*i);
    i++;
}

console.log("The 'weird' ways of the JavaScript equality:")
console.log("'0' == 0? ", "0" == 0);
console.log("[] == 0? ", 0 == []);
console.log("'0' == []? ", "0" == []);

console.log("'0' == 0? ", "0" == 0);
console.log("0 == false? ", 0 == false);
console.log("'0' == false? ", "0" == false);
console.log("'' == false? ", '' == false);
console.log("null == false? ", null == false);

// JavaScript operations between different types may have unexpected results:
// console.log(5 * undefined); // NaN
// console.log(5 * null); // 0
// console.log(5 * "ciao"); // NaN
// console.log(5 * mario); // NaN
// console.log("ciao" * null); // NaN

// In JS strings with '' or "" are equivalent:
var s = 'ciao';
var s = "In una stringa\n posso mettere caratteri \t di escape";
console.log(s);
var name = "Mario";
var message =  `Hello ${name}, I love you ${name}`;
console.log("stringa composta con la 'string interpolation':");
console.log(message);

var notDefinedVariable;
console.log("not defined/assigned variable:", notDefinedVariable);

// when I write a function, I don't specify the type of the parameters nor the return type
function compare(n1, n2) {
    if (isNaN(n1)) {
        // if nothing is returned, the caller receives "undefined"
        return;
    }
    if (isNaN(n2)) {
        // I can throw Exceptions:
        throw new Error("the parameters n2 is not valid!");
    }
    if (n1 < n2) {
        return -1;
    } else if (n1 > n2) {
        return 1;
    } else {
        return 0;
    }
}

// console.log(compare("ciao", "Caio")); // 1
// console.log(compare("adamo", "Eva")); // 1
// console.log(compare("(", "{")); // -1
// console.log(compare("(", "a")); // -1
// console.log(compare("[", "A")); // 1
// console.log(compare("à", "a")); // 1
// console.log(compare(96, "a")); // 0
// console.log(compare(98, "a")); // 0

// parseInt() converts a string to an int
console.log(parseInt("1000", 2));
// if the string is not a valid number, the result is NaN
console.log(parseInt("pippo", 10));

function factorial(n) {
    if (n == 0) {
        return 1;
    }
    return n * factorial(n-1);
}

console.log("factorial of 9: " + factorial(9));

// JAVASCRIPT ARRAY:
var array = []; // array vuoto
array = [ 1, 2, 3 ];
console.log("first element of the array: " + array[0]);
console.log("element out of range: " + array[10]);
array.push(4);
console.log("pushed element: " + array[3]);
console.log("array length: " + array.length);
console.log("pop() of an element: " + array.pop());
console.log("array length: " + array.length);
array.splice(1, 2);
console.log("array after splice of 2 items from index 1:");
console.log(array);

array = [ 1, 2, 3, 4 ]
console.log("map() function to double the values produces the array:");
console.log(array.map(x => x * 2)); // as C#'s Select()
console.log("filter() function to filter out items that are too little:");
console.log(array.filter(x => x < 2));  // as C#'s Where()

// There is NO deferred execution!

console.log("reduce() function to accumulate the values:");
console.log(array.reduce((acc, curr) => acc += curr, 0)); // C#'s Aggregate()

// I can pass functions written as lambdas or with 'function':
console.log(array.reduce(
    function(acc, curr) {
        return acc += curr;
    },
    -10)); // I can indicate the first value

console.log("foreach - or 'for OF'");
for (var item of array) {
    console.log(item);
}
console.log("for-IN: this is NOT a classical foreach.");
console.log("it prints the properties of an object (in this case, the indexes of the array):");
for (var item in array) {
    console.log(item);
}
console.log(item);

var item = 123;
console.log(item);

for(let counter = 0; counter < 2; counter++) {
    let counter2 = 123;
    var counter3 = 124;
}
// counter3 is visibile because the scope is 'global':
console.log(counter3);
// counter2 is not visibile, because it's declared with 'let'
// so the scope is the 'for' block
// console.log(counter2);
// counter is not visibile, because it's declared with 'let'
// so the scope is the 'for' block
// console.log(counter1);

function printFirst10Numbers() {
    console.log("function that prints the first 10 numbers:");
    for(var ii = 0; ii < 10; ii++) {
        console.log(ii);
    }
    console.log("finally I see 'ii' outside the for:");
    console.log(ii);
}
printFirst10Numbers();
// 'ii' has the function 'printFirst10Numbers()' as scope,
// so it cannot be seen outside the scope of that function.
// This line throws an error:
// console.log(ii);

try {
    console.log("I'm in a try");
    throw new Error("A custom error");
} catch(err) {
    console.log(err.message);
}

function outerFunc(number) {
    console.log("I can define a function inside another function:");
    function doubleNumber(n) {
        return n * 2;
    }
    let double = doubleNumber(number);
    console.log(`The double of ${number} is ${double}`);
}
// I can't call a function defined in another scope, this line throws an Error:
// doubleNumber(10);
outerFunc(10);

// eval evaluates a string as JS code:
eval("console.log('This is an evaluated string!');");

// if I override the 'eval' identifier, the old function is no more accessible:
eval = function F() { }
eval("console.log('This is an evaluated string!');");

console.log("'arguments' is a special keyword inside every function, that contains all the passed parameters")
function f(p1, p2, p3, p4, p5, p6, p7) {
    console.log(arguments);
}
f();
f("a", "b", "c");
f(1, 2, 3, 4);
f({}, "ciao", undefined, 2, null, new Date('2019-04-05'));
