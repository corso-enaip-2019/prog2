var mario={name:'Mario', surname:'Rossi', birthdate:new Date(2010,12,30) /*,wife:,*/ };
console.log(mario.name);
console.log(mario.birthdate);
console.log(new Date(1));

var daisy={
    name:       'daisy',
    surname:    '???', 
    rulingOver: 'regno dei fiori', 
    address:{
        kingdom:    'regno dei fiori', 
        street:     'castle mile', 
        nr:         101
    }
};

var luigi={
    name:           'luigi',
    surname:        'mario', 
    address:{
        kingdom:    'regno dei funghi', 
        street:     'pipe street', 
        nr:         1
    }, 
    princess:       daisy, 
    completeName:   function(){
        return `${this.name} ${this.surname}`
    }
};

console.log(luigi);
console.log(daisy);
console.log(luigi.completeName());

// ---

var r2d2 = {name:'r2',surname:'d2',completeName:generateCompleteName};

function generateCompleteName() {
    return `${this.name} - ${this.surname}`;
}

console.log(r2d2);
console.log(r2d2.completeName());

function PersonCns(name, surname){
    this.name=name;
    this.surn=surname;
}
var waluigi = new PersonCns('waluigi','myamoto');
console.log(waluigi);