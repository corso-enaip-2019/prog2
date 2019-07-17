function Stack() {
    this._items = [];
}
// If I put _items here, the same collection is shared
// among all Stacks!
// Stack.prototype._items = [];

Stack.prototype.push = function(item) {
    this._items.push(item);
}
Stack.prototype.pop = function() {
    if (!this._items.length) {
        throw new Error('Cannot pop from empty Stack!');
    }
    return this._items.pop();
}

var s1 = new Stack();
var s2 = new Stack();

s1.push("a");
s1.push("b");
s1.push("c");

// must throw Error:
// console.log(s2.pop());

console.log(s1.pop()); // "c"
console.log(s1.pop()); // "b"
console.log(s1.pop()); // "a"

function NotifyingStack() {
    Stack.call(this);
    this._listeners = [];
}
NotifyingStack.prototype.__proto__ = Stack.prototype;

NotifyingStack.prototype.addListener = function(listener) {
    this._listeners.push(listener);
}
NotifyingStack.prototype.removeListener = function(listener) {
    let listenerIndex = this._listeners.indexOf(listener);
    this._listeners.splice(listenerIndex, 1);
}
NotifyingStack.prototype.push = function(item) {
    NotifyingStack.prototype.__proto__.push.call(this, item);
    for(let l of this._listeners) {
        l.listen(item);
        // I could have different method names, like:
        // l.consume(item);
        // l.receive(item);
        // l.onNext(item);
    }
}

var consoleListener = {
    listen: function(item) {
        console.log(item);
    }
}

var cheerfulConsoleListener = {
    listen: function(item) {
        console.log("Yey, I have a new item! This is it: " + item);
    }
}

var ns1 = new NotifyingStack();
ns1.addListener(consoleListener);
ns1.addListener(cheerfulConsoleListener);
ns1.push("item1");
ns1.push("item2");
ns1.removeListener(consoleListener);
ns1.push("item3");
