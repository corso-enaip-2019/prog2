# DESIGN PATTERNS

## 1 - validations

Si hanno le seguenti classi:

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
      public string Street { get; set; }
      public int ZIP { get; set; }
    }

Vanno creati, in test-driven, i seguenti punti:

### 1.1 - Validatori con TEMPLATE

Bisogna creare dei validatori, in modo che istanze della classe `Person` siano controllate prima di essere salvate sul database.

Ogni validatore funziona così: ha un metodo `Validate` che prende in input una `Person`, e fa il suo controllo.
Se il controllo riesce, il metodo esce.
Altrimenti, restituisce una lista di errori (ogni errore è una stringa).

I validatori sono:
- `IdValid` (l'`Id` non può essere negativo)
- `NameNotEmpty` (il `Name` non può essere null o stringa blank),
- `BirthInRange` (la data di nascita non può essere fuori dal range 1900 - 2017)

I validatori vanno realizzati col pattern TEMPLATE.


### 1.2 Validatori con COMPOSITE

Per validare la proprietà Address, bisogna usare un validatore `AddressValidator` _composto_. Esporrà un metodo pubblico `Validate` come gli altri validatori, ma dentro avrà una lista di validatori privati per validare tutte le proprietà di Address:
- `AddressNotNull` (l'intero oggetto `Address` non può essere null sulla `Person`)
- `StreetNotEmpty` (la strada non può essere stringa blank)
- `ZipValid` (il numero deve avere 5 cifre)

### 1.3 Validatori con Factory

Per creare la lista di Validatori da usare, bisogna implementare un **Factory Method** che prende in input una lista di stringhe con i nomi dei validatori (es: `"IdValid"`, `"BirthInRange"`), e restituisce una lista coi Validatori voluti. Per implementare il factory method non fare uno switch sul valore della stringa: usare invece **Reflection** per costruire l'istanza di una classe dato il suo nome.

### 1.4 Database

Una classe `Database` ha una lista di validatori passati nel costruttore, e un metodo `Save` che prende in input una `Person`. La persona viene validata:
- se la validazione passa l'istanza viene salvata in una lista privata di `Person` del Database
- se la validazione non passa, viene restituita la lista di errori di tutti i validatori messi assieme.

Un metodo `Get` prende in input un `id` e restituisce una `Person` trovata nella lista privata con quell'`Id`.

Il database va realizzato come `Singleton`.

---

## 2 - DvdStore

### 2.1 Strategy

Un DvdStore ha un elenco di iscritti.

Ogni iscritto ha nickname e codice fiscale.

Inoltre, ogni iscritto può sottoscrivere un abbonamento.

Ogni iscritto può fare la richiesta di un dvd. Ogni richiesta ha una data, il titolo del dvd e l'importo del noleggio di quel dvd.

Gli abbonamenti sono di tipo diverso:

- a tempo: un abbonamento è valido solo in un range temporale

- a budget: c'è un totale di budget, ad ogni richiesta di noleggio si scala dal totale

Entrambi gli abbonamenti funzionano così: hanno un metodo per ricevere la richiesta di noleggio.
- Se la richiesta è valida, viene eseguita (ad esempio, in quello a budget viene scalato il totale)
- Se la richiesta non è valida, viene lanciata una `InvalidRentException`.

Implementare gli abbonamenti sugli abbonati con il pattern strategy

### 2.2 NullObject

Un utente, appena viene iscritto, non ha ancora un abbonamento. Il caso di non-abbonamento va gestito con il pattern **Null Object**.

### 2.3 Template

I due abbonamenti "operativi" possono essere realizzati con il pattern template

### 2.4 Singleton

La classe NullSubscription può essere implementata come Singleton

---

## 3 Pens

### 3.1 Abstract Factory

Una fabbrica produce penne.

Lo fa avendo in due aree separate la produzione del tubo principale e del tappo.

Ognuna di queste due va implementata come Factory Class.

Ognuna di queste factory ha un metodo `Create`:

    Tube TubeFactory.Create(double length, double radius)
    Cap CapFactory.Create(double radius)

Rispetto alla `length` o al `radius` indicati, le factory hanno un fattore di incertezza del 2%. Il che significa che, se chiedo una penna lunga 20 cm, la lunghezza effettiva del tubo principale potrebbe avere tra `19.6` e `20.4` cm.

queste factory sono contenute in una classe, `PenFactory`, che ha un metodo:

    Create(double length, double radius)

Questa factory principale passa i due parametri alle sotto-factory, crea quindi tubo e tappo, e poi verifica:

- che la `length` effettiva del tubo creato non si discosti più dell'1% dal valore di progetto. Se si discosta, viene lanciata un'eccezione;

- che il radius del tappo e quello del tubo non abbiano una differenza maggiore dello 0.5%, altrimenti o il tappo è troppo lasco, oppure non si riesce proprio a infilarci il tubo.

L'applicazione va realizzata con metodo test - driven, implementando un sistema di **Abstract Factory**.

Per testare la factory principale `PenFactory`, le due factory secondarie vanno passate nel costruttore, ognuna tramite relativa interfaccia.

Le classi di test per la `PenFactory` creeranno le dovute implementazioni di mock per la `ITubeFactory` e la `ICapFactory`, testando scenari diversi della `PenFactory`.

Ovviamente serviranno due classi di modle `Tube` e `Cap`.

### 3.2 Template

Volendo, le due factory secondarie si possono implementare con il pattern Template, avendo un algoritmo di funzionamento molto simile.

---

## 4.1 Carts and products

Un carrello della spesa online contiene un elenco di prodotti, ognuno con nome e prezzo.
Abbiamo una lista di carrelli da controllare.

Implementare tre classi per lo sconto:
1) una classe fa lo sconto del 10% se siamo di lunedì e se ci sono più di 10 acquisti;
2) una classe fa lo sconto del 15% se siamo in giorno del mese dispari e la spesa è di almeno 100 €;
3) una classe non applica nessuno sconto, mai.

Nel Main(), iterare sulla lista di carrelli, per ogni carrello iterare sulla lista di sconti passando il carrello corrente come parametro.

Il comportamento di ogni classe, nel metodo ApplyDiscount(), è il seguente:
1) viene passato un carrello in input;
2) si controlla se è il giorno giusto per applicare lo sconto
3) se sì, controlla se il carrello soddisfa le condizioni per ricevere uno sconto
4) se sì, si itera su tutti i prodotti del carrello, applicando al prezzo di ogni prodotto lo sconto.

Se capita un giorno in cui più sconti andrebbero applicati, vanno applicati tutti. Ogni sconto non sa niente di quanto e se sono stati applicati sconti precedenti.

Implementare le classi di sconto come TEMPLATE.

Inoltre, implementare ogni sconto come SINGLETON.

Inoltre, sulla classe base degli sconti, creare una proprietà statica di tipo lista che contenga i tre singleton, quindi un MULTITON, in modo che iterare sui vari sconti sia semplice.

Le classi non usano il DateTime.Now, ma viene passata la data da fuori.


## 4.2 Carts and products

Separare le due funzionalità di:
1) calcolare se è il giusto giorno di sconto
2) calcolare quant'è lo sconto

Utilizzare quindi il pattern STRATEGY per implementare il sistema invece del pattern TEMPLATE.