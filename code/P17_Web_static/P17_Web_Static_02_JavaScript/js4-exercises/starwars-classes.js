class Person
{
    constructor(name) {
        if (!name || (typeof name !== 'string')) {
            throw new Error('Empty name!');
        }
        this.name = name;
    }
}

class Baby extends Person
{
    constructor(name) {
        super(name);
        this.comforters = [];
    }

    startCrying() {
        console.log(`${this.name} started crying!`);
        this.comforters.slice(0).forEach(c => c.comfort(this));
    }
}

class Dad extends Person
{
    constructor(name) {
        super(name);
    }

    comfort(baby) {
        console.log(`${this.name} escape in Mexico!`);
        var indexOfDad = baby.comforters.indexOf(this);
        baby.comforters.splice(indexOfDad, 1);
    }
}

class Mum extends Person
{
    constructor(name) {
        super(name);
    }

    makeChild(dad, babyName) {
        var baby = new Baby(babyName);
    
        baby.comforters.push(dad);
        dad.child = baby;
    
        baby.comforters.push(this);
        this.child = baby;
    }

    comfort(baby) {
        console.log(`${this.name} comforts the little crying baby ${baby.name}`);
    }
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

leila.child.startCrying();
leila.child.startCrying();
