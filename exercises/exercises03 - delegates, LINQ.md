## 1 delegates
Declare a delegate `ConvertToStringDelegate` that accepts an int and returns a string.

Three functionalities have the shape of this delegate:
1) one takes an int and uses just the `ToString()` on the int;
2) one takes an int and converts it to a string using the coma ',' as thousands separator
3) one takes an int and returns a string that tells if the int is odd or even.

Implement these 3 functionalities:
1) through static methods in the `Program` class
2) as instance-methods (i.e., non-static methods), on a class `IntToStringUtility`
2) as anonymous lambda functions

In the `Program` class create a method that:
1) accepts a list of integers and an "instance" of the delegate `ConvertToStringDelegate`
2) returns a list with the projected string values

In the `Main`:
1) create a list of int
2) pass the 9 methods (the 3 functionalities have all 3 implementations), creating 9 new lists
3) print all the lists on the Console.


## 2 Filtered people
Using the `Filter()` and `Project()` generic methods implemented in the classroom, we want to obtain a list of the names of people born after 1975, starting from a list of objects of type `Person`, where the class `Person` has Name, Surname, Address, YearOfBirth, Gender.

The resulting names are the concatenation of Name + Surname.

Create a mock list, use the two member to filter and project the list, and print the result on the Console.


## 3.1 Grouped people
Using the same mock data as **2**, create a method, just for the `Person` class, that groups people by `YearOfBirth`.

The result is a list of groups, every group has a Key property with the Year, and a list of people that were born in that year (thus, all the people in a group share the same exact Year).

Then implement a similar method, but grouping by gender. The result is a list of groups, where every group has a Key property with the gender.


## 3.2 Grouped people **
Create a generic static method, like `Filter` or `Project`, that:
1) takes a collection of items of type `TInput`, and a lambda that has a `TInput` as input and `TKey` as output
2) returns a collection of `Group<TKey, TInput>`, where `Group` is a class you have to write.

Use this method to group by year or by gender.

The use should be something like:

    IEnumerable<Group<int, Person>> groups = GroupBy<int, Person>(people, person => person.YearOfBirth);


## 4 trivial logger
We create a logger method.

This method takes as input a delegate with no parameters and no return type.

The method prints on the Console "starting execution...", then it executes the input method, and finally it prints "execution finished.".

Create some mock methods, and use them as input parameters for the logger method.


## 5 Performance testers *
We want to write a utility method that measures the performance of another method, and returns the number of taken ms.

This method, called `Measure()`, is a static method in a static class. It takes as input a delegate that has no parameters and returns void.

In the body, `Measure()` instantiates a Stopwatch, starts it, then it executes the method passed as a parameter, then it stops the stopwatch and returns the `ElapsedMilliseconds` value.

In order to test this method, create two methods to be measured. Both calculate the max prime number up to 1.000.000.000.

1) the first method just iterates through all the integers between 2 and 1.000.000.000, if a new prime is found, it is put in a local variable `max`. In the end, it prints `max` on the Console.
2) the second method creates an array with all the int values up to 1.000.000.000.

    Then it iterates through all the cells. When a cell is not 0, the value is used to erase every following cell that has a multiple of that number.
    
    For example, in the cell at index 2 we find the number 2. We iterate between 2 and 1.000.000.000, and every cell that contains a multiple of 2 is set to 0.

    Then we pass to the next cell with a non-zero value. For example, 3. We iterate between 3 and 1.000.000.000 and every cell that contains a multiple of 3 is set to 0.

    In the end, we look at the last cell with a value different from 0: that's the max prime number; we print it on the Console.

Use the `Measure()` method to measure the performance of both methods (if it takes too long, use a lower range, for example 100.000.000).

The `Main` method calls `Measure()` twice, one for every version of the prime number search, and prints the returned milliseconds to the Console.


## 6 The Multiplier
Create a method `CreateMultiplier()` that returns another method.

This is the goal: we call `CreateMultiplier()` passing an int `multiplierFactor` as parameter.

The method returns a method that takes an int as parameter and returns the multiplication between this int and the `multiplierFactor`.

This is the use in the `Main()`:

    var multiplier = CreateMultiplier(5); // "multiplier" is a function!
    var result1 = multiplier(2); // 10
    var result2 = multiplier(3); // 15

    var multiplier2 = CreateMultiplier(10);
    var result3 = multiplier2(200); // 2000
    var result4 = multiplier2(-3); // -30


## 7 Number properties
Create a method `PrintIfProperty()` that takes as input:
1) an int (the number to check),
2) a string (the description of the checked property)
3) a delegate that takes an int and returns a bool (this method checks the property).

The method gets the result from the passed delegate and prints it on the Console.

3 methods adhere to the delegate:
1) `bool IsPrime(int i)` tells if a number is prime,
2) `bool IsTriangular(int i)` tells if a number is triangular.
3) `bool IsEven(int i)` tells if a number is even.

Use `PrintIfProperty()` 3 times, once for every check-method.

For example, in the `Main()` we will see:

    PrintIfProperty(37, "prime", IsPrime);
    PrintIfProperty(37, "triangular", IsTriangular);
    PrintIfProperty(37, "even", IsEven);

And the result on the Console will be:

    37 is prime
    37 is not triangular
    37 is not even


## 8 - Queries 1
we have a collection of mock objects of this class:

    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool HasPets { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
        public string Street { get; set; }
        public int Number
        public string City { get; set; }
    }

Write LINQ queries to obtain:

1) all the Person with pets living in "London"
2) all the Person ordering first by City and then by Surname
3) the list of cities involved (but without duplication of names)
3) a list of cities, every city with the number of people living in it
4) a list of "addresses", every address with the property of the Address class but also a list with all the people leaving in that address


## 9 - Queries 2
Given a list of strings, create a LINQ query such that you revert every string (ex: "ciao" => "oaic"), then you keep only the resulting strings that are convertible in a double but not in an int (ex: "5.4" is fine, but "5" or "5.0" are not), then you convert them in doubles, than you calculate for every one its square root, that you keep only the ones whose value is less than 5.

Use only LINQ methods, don't implement anything manually (even the Revert functionality).


## 10 - Queries 3

You have these classes:

    public class Field
    {
        public string Vegetable { get; set; }
        public int Extension { get; set; }
    }

    public class Farm
    {
        public string Owner { get; set; }
        public List<Field> Fields { get; set; }
    }

Create a mock list of `Farms`, every one with a list of `Fields`.

Write LINQ queries to obtain:

- A flat list of `Fields` (use `SelectMany`)
- A list of items where every item has `Vegetable` and the list of `Fields` of that `Vegetable` (use `SelectMany` to flat the list, then use `GroupBy` to group by `Vegetable`, then `Select` to create the final items)
- A list of items where every item has `Vegetable` and `TotalExtension` (use `SelectMany` to flat the list, then GroupBy using Vegetable as `Key`, then project with Select using `Aggregate` to calculate the total extension of every group)
- a list of `Farms` containing only the `Farms` with a total `Extension` of more than `100`
- a list of all `Farms`, but every `Farm` must contain only the `Fields` with an `Extesion` greater than `20`
- a list of `Owners`, where every `Owner` has a `Name` and a list of `Farms` (and every `Farm` has its list of `Fields`)
- a list of `Owners`, where every `Owner` has a `Name` and a list of `VegetablePercentages`, where a `VegetablePercentage` has the Name of the `Vegetable` and the percentage of `Extension` of that `Vegetable` on the `Farms` of that `Owner` (for example, `Mario` has many `Farms` and `Fields`, for a total of 60 areas of corn and 140 areas of wheat: there will be 2 items in the `Mario`'s list, one with the infos 'Corn' and 30%, and the other with the infos 'Wheat' and 70%)


## 11

Si ha una collezione di istanze di queste due classi:

    class FriendshipEntity
    {
        public int Id { get; set; }
        public int FriendId1 { get; set; }
        public int FriendId2 { get; set; }
    }

    class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

Si vuole arrivare ad una lista di istanze della seguente classe:

    class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Person> Friends { get; set; }
    }

Con una query di LINQ manipolare le due collezioni di Friendships e PersonEntity per ottenere una lista di persone ognuna con la sua lista di amici. Le istanze di Person possono anche risultare duplicate.

Lo scopo dell'esercizio è scrivere un'unica query LINQ, concatenando un qualsivoglia numero di metodi.

