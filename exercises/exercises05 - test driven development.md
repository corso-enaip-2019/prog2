# TEST DRIVEN DEVELOPMENT
These exercises must be done following the TDD metodology. This means that these steps must be followed in order:
1) You create the classes with their methods and properties, but WITHOUT implementing anything
2) You write all the necessary tests
3) You verify that every test is broken, at least one time
4) You implement the classes until all the tests pass.


## 1 - Cup version 3

Take the Cup exercise, version 2.
Add these edits:
1) The `Fill()` method takes a quantity as parameter, as the `Drink()` one;
2) If the user tries to fill too much, the Cup throws Exception;
3) There is a property IsEmpty, specular to IsFull: IsEmpty is true only if the FillLevel is 0.


## 2 - Cup version 4

You can choose to base this exercise on Cup v2 or v3.
You must add this rules:
1) When a Cup is drunk, we must specify also the person who drinks; the person can be a simple string with his/her name;
2) If a person starts to drink a Cup, he/she is the only one that can continue to drink;
3) The Cup has a method `Wash()`; after the method is called, another person can drink.


### 3.1 - Simple Queue

A Queue is a data structure of type FIFO (First In, First Out). We want to implement a Queue<T> with these functionalities:
1) we can add an element with the `Enqueue()` method;
2) we can retrieve an element (that is removed from the queue) with the `Dequeue()` method;
3) a bool property that tells if the Queue is empty;
4) an int property that tells how many elements are in the Queue;
3) If we call `Dequeue()` on an empty Queue, an EmptyQueueException is thrown.


## 3.2 - Notifying Queue

We want to create a `NotifyingQueue<T>`, that inherits from `Queue<T>` (implemented in 3.1) and also that does also the following:
1) There is an event on the Queue, `ItemEnqueued`. It is raised in the method `Enqueue()` after the item is actually saved internally;
    the delegate of the event has two parameter: an `object` (that will be the queue itself) and a QueueEventArgs, derived from EventArgs, containing the added element.

When you finish, answer this question: was is a good choice to inherit the `NotifyingQueue<T>` from the `Queue<T>`? Why?


## 4 - Reversable Stack 

A Stack is a data structure LIFO (Last In First Out).

We want to realize a `ReversableStack<T>` with the following functionalities:
1) a metod `Push()` allows to add an element to the Stack;
2) a method `Pop()` get from the Stack the last element added;
3) if `Pop()` is called on an empty Stack, an exception is thrown;
4) a Count property tells how many items the Stack has;
5) a method `Reverse()` inverts completely the order of the Stack, so the next calls on `Pop()` removed the first items saved and not the last; think about a pile of plates: you can only remove them from the top, but if you take the entire pile and you turn it completely, now you have on the top the elements that were on the bottom before.

Question: would it be useful/good to derive our `ReversableStack<T>` from the .NET `Stack<T>` class?


## 5 - Employee

Take the classes of the project DesignPatterns that have Employees and PayCheckCalculators.

Write a sufficient number of tests to verify the behavior of all the PayCheckCalculators, with different Employees passed as parameters.
