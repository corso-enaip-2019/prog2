/* Creazione classi. */

class Field {
    constructor(vegetable, extension) {
        this.vegetable = vegetable;
        this.extension = extension;
    }
}

class Farm {
    constructor(owner, fields) {
        this.owner = owner;
        this.fields = fields;
    }
}

/* Creazione "popolamento" degl'oggetti. */

var farms = [
    new Farm('Tom', [
        new Field('Patate', 25),
        new Field('Cavolfiori', 5),
        new Field("Viti", 30),
        new Field("Mais", 15)
    ]),

    new Farm('Tobia', [
        new Field("Carote", 25),
        new Field("Carciofi", 5)
    ]),

    new Farm('Tobia', [
        new Field("Patate", 125),
        new Field("Cavolfiori", 55),
        new Field("Viti", 330),
        new Field("Mais", 215),
        new Field("Carote", 25),
        new Field("Carote", 5),
        new Field("Carciofi", 555)
    ]),

    new Farm('Boris', [
        new Field("Fragole", 5),
        new Field("Carote", 2),
        new Field("Carciofi", 5)
    ]),

    //fattoriaA con lo stesso proprietario di fattoriaB
    new Farm('Ivan', [
        new Field("Mais", 50),
        new Field("Carote", 30),
        new Field("Cavolfiori", 50)
    ]),

    //fattoriaB con lo stesso proprietario di fattoriaA
    new Farm('Ivan', [
        new Field("Mais", 10),
        new Field("Mais", 25),
        new Field("Viti", 350)
    ]),

    //fattoria senza campi
    new Farm('Dragan', [])
]

/* --- */

var biggerFarms = farms.filter(frm => frm.fields.reduce((acc, fld) => acc += fld.extension, 0) > 100);

/* --- */

var products = [{ unitPrice: 2.99, quantity: 10 }, { unitPrice: 7.89, quantity: 3 }];
var cost = products.reduce((acc, p) => acc = p += p.products * p.quantity,0);

/* "Main" */

console.log(`All farms: ${farms}.`);
console.log(`Bigger farms: ${biggerFarms}.`);
console.log(`Total cost: ${cost}.`);