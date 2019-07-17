var obj = {
    name: 'Mario',
    walk: function() {
        console.log(this.name);
    },
    upperName: function() {
        return this.name.toUpperCase();
    }
}
obj.walk();

var filter = {
    value: 12,
    applyWithFunc: function(arr) {
        return arr.filter(function(a) {
            return a < this.value;
        })
    },
    applyWithLambda: function(arr) {
        return arr.filter(x => x < this.value);
    }
}
console.log(filter.applyWithFunc([1, 2, 20]));
console.log(filter.applyWithLambda([1, 2, 20]));


var func1 = function() { };
var func2 = function aFunc() { };
console.log(func1);
console.log(func2);
console.log(func1.name);
console.log(func2.name);

var obj = {
    propFunc1: function() { },
    propFunc2: function aFunc() { },
}
console.log(obj.propFunc1.name);
console.log(obj.propFunc2.name);
console.log(obj.propFunc1);

function aFuncWithVisibleName() {

}

console.log(aFuncWithVisibleName);