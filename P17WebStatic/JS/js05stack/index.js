/* Stack costruito come un oggetto js "standard". */
var oStack = {
    _items: [],
    push:   function(x) {
            this.addElement(x);
    },
    pop:    function() { 
            if (this._items.length<1) {
                throw new exception("The stack is empty!");        
            }

            let poppedElement = this._items[this._items.length-1];
            this._items.slice(1, -1);
            return poppedElement;
    },
    planeStack: function() {
        this._items = [];
    },
    addElement: function(x) {
        this._items[this._items.length]=x;
    }
};

/* Notifying-Stack costruito come un oggetto js "standard". */
var oNStack = {
    _items: [],
    _listeners: [],
    push: function(x) {
        this.addElement(x);
    },
    pop:function() { 
        if (_items.length < 1) {
            throw new exception("The stack is empty!");
        }
        notifyListeners
        return _items[_items.count()-1];
    },
    addListener:function(x) {
        _this._listeners[_this._listeners.length] = x;
    },
    removeListener: function(x) {
        if (_listeners.length < 1) {
            throw new exception("The listeners list is empty!");
        }
        var listenerFound = false;
        /* Semplificabile con una λ. */
        for (var/*let*/ i = 0; i < array.length; i++) {
            if (_listeners[i] == x) {
                this._listeners[i] = null;
                listenerFound = true;
            }
        }
        ////////_listeners.forEach((listener==x) => { listener=null;});
        if (listenerFound == false) {
            throw new exception(`The listener «${x}» isn't in listeners list!`);
        }
    },
    notifyListeners: function(retrievedObject) {
        this._listeners.forEach(listener => { oNStack.notifyListeners.call(listener, retrievedObject);            
        });
    },
    planeStack: function() {
        this._items = [];
    },
    planeListeners: function() {
        this._listeners = [];
    },
    addElement: function(x) {
        this._items[this._items.length=x];
    }
};

// Stack costruito come una "classe" js.
// class CStack {
//     _items = [];
//     push(x) {
//         _items.add(x);
//     }
//     pop() {
//         if (_items.count()<1) {
//             throw new exception("The stack is empty!");        
//         }
//         return _items[_items.count()-1];
//     }
// }

// Notifying-Stack costruito come una "classe" js.
// Costruttore
// constructor MyStack(items, listeners) {
    
//     _items = [];
//     _listeners = [listeners];
//     push(x) {
//         _items.add(x);
//     };
//     pop() { 
//         if (_items.count() < 1) {
//             throw new exception("The stack is empty!");
//         }
//         return _items[_items.count()-1];
//     };
//     addListener(x) {
//         _listeners.add(x);
//     };
//     removeListener(x) {
//         if (_listeners.length < 1) {
//             throw new exception("The listeners list is empty!");
//         }
//         var listenerFound = false;
//         /* Semplificabile con una λ. */
//         for (let i = 0; i < array.length; i++) {
//             if (_listeners[i] == x) {
//                 this._listeners[i] = null;
//                 listenerFound = true;
//             }
//         }
//         //_listeners.forEach((listener==x) => { listener=null;});
//         if (listenerFound == false) {
//             throw new exception(`The listener «${x}» isn't in listeners list!`);
//         }
//     };
//     notifyListeners(retrievedObject) {
//         _listeners.forEach(listener => { oNStack.notofy.call(listener, retrievedObject);            
//         });
//     }
// };

// // Classe
// class CNStack {
//     _items= [];
//     _listeners= [];
//     push(x) {
//         _items.add(x);
//     };
//     pop() { 
//         if (_items.count() < 1) {
//             throw new exception("The stack is empty!");
//         }
//         return _items[_items.count()-1];
//     };
//     addListener(x) {
//         _listeners.add(x);
//     };
//     removeListener(x) {
//         if (_listeners.length < 1) {
//             throw new exception("The listeners list is empty!");
//         }
//         var listenerFound = false;
//         /* Semplificabile con una λ. */
//         for (let i = 0; i < array.length; i++) {
//             if (_listeners[i] == x) {
//                 this._listeners[i] = null;
//                 listenerFound = true;
//             }
//         }
//         //_listeners.forEach((listener==x) => { listener=null;});
//         if (listenerFound == false) {
//             throw new exception(`The listener «${x}» isn't in listeners list!`);
//         }
//     };
//     notifyListeners(retrievedObject) {
//         _listeners.forEach(listener => { oNStack.notofy.call(listener, retrievedObject);            
//         });
//     }
// };

function genNewOStack() {
    var outStack = oStack;
    outStack.planeStack();
    return outStack;
}

function genNewNOStack() {
    var outStack = NOStack;
    outStack.planeStack();
    outStack.planeListeners();
    return outStack;
}

function planeContentOfThisStack() {
    this._items = [];
}

function planeListenersOfThisStack() {
    this._listeners = [];
}

/* "main" */
var mioOStack = genNewOStack();
mioOStack.push('ciao');
mioOStack.push('sono');
mioOStack.push('io');
mioOStack.push('!');
console.log(mioOStack.pop());
console.log(mioOStack.pop());
console.log(mioOStack.pop());
console.log(mioOStack.pop());