// var maria = new Person("Maria");
// console.log(maria.constructor);

// var mario = {
//     name: 'Mario'
// };
// console.log(mario.constructor);
// console.log(mario.__proto__);
// console.log(mario.constructor.prototype);

// var marioClone = mario.constructor();

// var mario = new Object();
// mario.name = 'Mario';

function Person(name) {
    if (!name || (typeof name !== 'string')) {
        throw new Error('Empty name!');
    }
    this.name = name;
}

function Baby(name) {
    // More "manual" ways:
    // var baby = new Person(name);
    // baby.__proto__ = Baby.prototype;
    
    // more elegant way (see folder 'js3'):
    Person.call(this, name);
    this.comforters = [];
}
Baby.prototype.__proto__ = Person.prototype;
Baby.prototype.startCrying = function() {
    console.log(`${this.name} started crying!`);
    this.comforters.slice(0).forEach(c => c.comfort(this));
}

function Dad(name) {
    Person.call(this, name);
}
Dad.prototype.__proto__ = Person.prototype;
Dad.prototype.comfort = function(baby) {
    console.log(`${this.name} escape in Mexico!`);
    var indexOfDad = baby.comforters.indexOf(this);
    baby.comforters.splice(indexOfDad, 1);
}

function Mum(name) {
    Person.call(this, name);
}
Mum.prototype.__proto__ = Person.prototype;
Mum.prototype.makeChild = function(dad, babyName) {
    var baby = new Baby(babyName);

    baby.comforters.push(dad);
    dad.child = baby;

    baby.comforters.push(this);
    this.child = baby;
}
Mum.prototype.comfort = function(baby) {
    console.log(`${this.name} comforts the little crying baby ${baby.name}`);
}

var leila = new Mum('Leila');
var hanSolo = new Dad('Han Solo');
leila.makeChild(hanSolo, 'Kylo Ren');

var r2d2 = {
    name: 'R2D2',
    comfort: function(baby) {
        console.log(`${this.name} comforts the little human ${baby.name}`);
    }
}

leila.child.comforters.push(r2d2);

// Just to verify the properties on the objects:
// console.log(leila.child.name);
// console.log(hanSolo.child.name);
// console.log('the child is the same? ' + (leila.child === hanSolo.child));

leila.child.startCrying();
leila.child.startCrying();