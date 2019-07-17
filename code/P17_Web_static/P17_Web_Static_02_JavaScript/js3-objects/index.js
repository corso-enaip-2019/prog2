// I can create an object with the JSON notation:
var mario = {
  name: 'Mario',
  surname: 'Rossi',
  birth: new Date('1970-05-04'),
  gender: 'M',
  isMarried: true,
  completeName: function() {
      return `${this.name} ${this.surname}`;
  },
  address: {
      street: 'Via Roma',
      number: '1',
      city: 'Trieste'
  }
};
console.log('print of a whole object:');
console.log(mario);

console.log('value of a single property:');
console.log(mario.name);

console.log('get a not defined property:')
console.log(mario.wife); // undefined

console.log('I can add a property later and use it:');
mario.job = 'engineer';
console.log('mario.job: ' + mario.job);

// a result is UNDEFINED when:
// 1) a variable is declared but not yet assigned
// 2) I get the return value of a function that does not return anything
// 3) A function has a parameter that is not passed by the caller
// 4) a property/field that was not set on an object

console.log('A property can be a function:');
console.log('mario.completeName(): ' + mario.completeName());

console.log('I can get/set a property of an inner object:');
console.log('mario.address.street: ' + mario.address.street);
mario.address.number = 2;
console.log('mario.address.number: ' + mario.address.number);

mario.address = {
    street: 'via Milano',
    number: '3/A',
    city: 'Udine'
};
console.log('mario.address: ');
console.log(mario.address);

console.log('I cannot call a non-defined function:');
// console.log(mario.giveMeMoney());

console.log('I cannot call an identifier that is not a function:');
// console.log(mario());
// console.log(mario.name());

var robot = {
    name: 'R2',
    surname: 'D2'
};
function completeNameFunc() {
    return `completeName: ${this.name} ${this.surname}`;
}
console.log('I hooked the function completeNameFunc() on mario and robot.');
console.log('the "this" in the function refers always to the current object on which the function is hooked when it\'s invoked');
robot.completeName = completeNameFunc;
console.log('robot: ' + robot.completeName());

mario.completeName = completeNameFunc;
console.log('mario: ' + mario.completeName());

var orphan = {
    completeName: completeNameFunc
};
console.log("If I call completeName() on orphan, it looks for the properties 'name' and 'surname' on the object 'orphan'");
console.log("Since they are not set, the method prints 'undefined undefined':")
console.log('orphan: ' + orphan.completeName());

console.log('If I call the function per se, without a hooked object, the call is ignored:');
completeNameFunc();
console.log();

function Person(name, surname) {
    this.name = name;
    this.surname = surname;
}
// every function has a linked object, called 'prototype'
Person.prototype.walk = function() {
    console.log(`${this.name} is walking down the street!`);
}

// the prototype is linked back to the function via the property 'constructor':
console.log(Person.prototype);
console.log('Person === Person.prototype.constructor? ' + (Person === Person.prototype.constructor));

// I can use a function normally:
orphan.assignName = Person;
orphan.assignName('Bilbo', 'Esposito');
console.log(orphan);

// Or I can use it as a CONSTRUCTOR FUNCTION, using the 'new' operator:
var luigi = new Person('Luigi', 'Neri');
luigi.walk();

// 4 things happen:
// 1) a new object (o) is created
// 2) the 'this' is strongly bound to o
// 3) o.__proto__ is set to the Func.prototype
// 4) o is returned, even if the 'return' statement is not explicit.

function Student(name, surname, university) {
    this.name = name;
    this.surname = surname;
    this.university = university;
}
// In this way I create sort of a inheritance chain:
Student.prototype.__proto__ = Person.prototype;
var maria = new Student('Maria', 'Gialli', 'Cambridge');
maria.walk();

// When I call a property or a function on an object:
// 1) JavaScript looks on the object itself. If present, that value is used.
// 2) If the object does not contains such property/function, it is searched on the __proto__ of the object.
// 3) If it is not found on the __proto__, it is searched on the __proto__ of the __proto__, and so on.
// 4) If in the end the property is not found, 'undefined' is returned; if it was a function, an error is raised.

// I can redefine on an object an inherited function:
maria.walk = function() {
    console.log(`${this.name} is running because she's happy!`);
}
maria.walk();

var anna = new Student('Anna', 'Verdi', 'Stanford')

Student.prototype.income = 0;
console.log("Normal student's income: " + Student.prototype.income);
console.log("Maria's income: " + maria.income);
console.log("Anna's income: " + anna.income);

maria.income = 1000;
console.log("Normal student's income: " + Student.prototype.income);
console.log("Maria's income: " + maria.income);
console.log("Anna's income: " + anna.income);

console.log("I can modify even the default functions of JavaScript;");
console.log("In this case I create a first() function on the Array.prototype:")
Array.prototype.first = function() {
    if (this.length === 0) {
        throw new Error();
    }
    return this[0];
}

var array = [ 5, 6, 7 ];
console.log(array);
console.log("the first element of the array is: " + array.first());

// I can use the 'class' keyword, but JavaScript HAS NO CLASSES.
// This is just syntactic sugar, where the constructor contains what the old function used to contain,
// and the methods outside the constructor are set on the prototype of the function.
class Robot
{
    constructor(name) {
        this.name = name;
    }

    speak() {
        console.log(`${this.name} says: '0011100001010100010010'`);
    }
}

class WalkingRobot extends Robot
{
    constructor(name) {
        super(name);
    }
    walk() {
        console.log(`${this.name} is walking without feelings!`);
    }
}

var r2d2 = new WalkingRobot('R2D2');
console.log("r2d2 name: " + r2d2.name);
r2d2.speak();
r2d2.walk();

console.log(r2d2.walk)
console.log(WalkingRobot.walk)
console.log(Robot.walk)

console.log("I can decide who is the 'this' of a function");
console.log("For example, I can use the 'speak()' function on 'r2d2', but using 'bb8' as 'this':")
var bb8 = new Robot('BB8');
r2d2.speak.call(bb8);
