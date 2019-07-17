var mario = {
    name: 'Mario',
    surname: 'Rossi',
    age: 72,
    walk: function() {
        console.log(this.name + " is walking!");
    }
};

for (let p in mario) {
    console.log(p + ": " + mario[p]);
}
mario["complete name"] = mario.name + " " + mario.surname;

console.log("complete name" + ": " + mario["complete name"]);

for (let i in [ 1, 2, 3 ]) {
    console.log(i);
}

var mario2 = {};
Object.assign(mario2, mario);
console.log(mario2);
mario2.walk();
mario2.name = 'Mario2';
mario.walk();
mario2.walk();

var mario3 = Object.create(mario2);
var mario4 = Object.create(mario2);
console.log("mario2 === mario3.__proto__? " + (mario2 === mario3.__proto__));

console.log("this is mario before toString override: " + mario);

mario.toString = function() {
    return "{ " + this.name + " " + this.surname + " }";
}

// this is wrong:
// mario.toString = () => {
//     return "{ " + this.name + " " + this.surname + " }";
// }

console.log("this is mario after toString override: " + mario);

