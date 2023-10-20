//---------------------------------ARRAY-------------------------------------------------------

// Creazione di un array
var myArray = [1, 2, 3, 4, 5];

// Loop con break e continue
for (var i = 0; i < myArray.length; i++) {
  // Usa break per uscire dal ciclo in base a una condizione
  if (myArray[i] === 3) {
    break;
  }

  // Usa continue per saltare un'iterazione in base a una condizione
  if (myArray[i] === 2) {
    continue;
  }

  console.log(myArray[i]);
}

// Aggiunta di elementi in coda
myArray.push(6);

// Rimozione dell'ultimo elemento
var removedElement = myArray.pop();

// Ottenere/Impostare un elemento
var elementAtIndex2 = myArray[2];
myArray[1] = 10;

// Verifica l'esistenza di un elemento in base all'indice
var indexToCheck = 4;
if (myArray[indexToCheck] !== undefined) {
  console.log("L'elemento all'indice " + indexToCheck + " esiste: " + myArray[indexToCheck]);
}

//------------------------------------------------------------LIST---------------------------------------------------------------
// Creazione di un "elenco" (usando un array)
var myList = [1, 2, 3, 4, 5];

// Loop con for...of
for (var item of myList) {
    console.log(item);
}

// Aggiunta di elementi in coda
myList.push(6);

// Rimozione dell'ultimo elemento
var removedElement = myList.pop();

// Ottenere/Impostare un elemento
var elementAtIndex = myList[2];
myList[1] = 10;

// Verifica l'esistenza di un elemento in base all'indice
var indexToCheck = 4;
if (myList[indexToCheck] !== undefined) {
    console.log("L'elemento all'indice " + indexToCheck + " esiste: " + myList[indexToCheck]);
}

//----------------------------------------------------------------DIZIONARIO------------------------------------------------------------
// Creazione di un oggetto simile a un dizionario
var dictionary = {
    "key1": "value1",
    "key2": "value2",
    "key3": "value3"
  };
  
  // Loop sulle chiavi
  for (var key in dictionary) {
    if (dictionary.hasOwnProperty(key)) {
      console.log(key + ": " + dictionary[key]);
    }
  }
  
  // Aggiungi un elemento
  dictionary["key4"] = "value4";
  console.log("Elemento con chiave key4: " + dictionary["key4"]);
  
  // Rimuovi un elemento
  delete dictionary["key2"];
  console.log("Elemento con chiave key2 rimosso.");
  
  // Verifica l'esistenza di una chiave
  var keyToCheck = "key1";
  if (dictionary.hasOwnProperty(keyToCheck)) {
    console.log(keyToCheck + " esiste.");
  }

  //----------------------------------------------------------SORTED LIST----------------------------------------------------------
  // Creazione di un "sorted list" simulato come un array
var sortedList = [
    { key: "key1", value: "value1" },
    { key: "key2", value: "value2" },
    { key: "key3", value: "value3" }
  ];
  
  // Loop con break/continue
  for (var i = 0; i < sortedList.length; i++) {
    if (sortedList[i].key === "key2") {
      continue; // Salta il valore con chiave "key2"
    }
    if (sortedList[i].key === "key3") {
      break; // Esci dal ciclo quando la chiave è "key3"
    }
    console.log(sortedList[i].key + ": " + sortedList[i].value);
  }
  
  // Aggiungi un elemento in modo ordinato
  function addElement(key, value) {
    for (var i = 0; i < sortedList.length; i++) {
      if (key < sortedList[i].key) {
        sortedList.splice(i, 0, { key: key, value: value });
        return; // Elemento aggiunto e uscita dalla funzione
      }
    }
    sortedList.push({ key: key, value: value }); // Aggiungi in coda
  }
  
  addElement("key4", "value4");
  console.log("Elemento con chiave key4 aggiunto.");
  
  // Rimuovi un elemento
  function removeElement(key) {
    for (var i = 0; i < sortedList.length; i++) {
      if (sortedList[i].key === key) {
        sortedList.splice(i, 1); // Rimuovi un elemento
        return; // Elemento rimosso e uscita dalla funzione
      }
    }
  }
  removeElement("key2");
  console.log("Elemento con chiave key2 rimosso.");
  
  // Get e check esistenza
  function getElement(key) {
    for (var i = 0; i < sortedList.length; i++) {
      if (sortedList[i].key === key) {
        return sortedList[i].value; // Restituisci il valore corrispondente
      }
    }
    return null; // Chiave non trovata
  }
  
  var keyValue = getElement("key1");
  console.log("Elemento con chiave key1: " + keyValue);

  //----------------------------------------------------------------------------HASH SET---------------------------------------------------------------
  // Inizializza un oggetto per simulare un HashSet
var hashSet = {};

// Aggiungi elementi
hashSet["value1"] = true;
hashSet["value2"] = true;
hashSet["value3"] = true;

// Loop con break/continue
for (var key in hashSet) {
  if (key === "value2") {
    continue; // Salta il valore "value2"
  }
  if (key === "value3") {
    break; // Esci dal ciclo quando si raggiunge "value3"
  }
  console.log("Chiave:", key);
}

// Aggiungi un elemento
hashSet["value4"] = true;
console.log("Elemento con chiave value4 aggiunto.");

// Rimuovi un elemento
if (hashSet["value2"]) {
  delete hashSet["value2"];
  console.log("Elemento con chiave value2 rimosso.");
}

// Check esistenza
if (hashSet["value1"]) {
  console.log("Chiave value1 esiste.");
} else {
  console.log("Chiave value1 non trovata.");
}

//----------------------------------------------------------------------SORTED SET------------------------------------------------------------
// Inizializza un set ordinato (emulato) utilizzando un array
var sortedSet = [];

// Aggiungi elementi (assicurandoti che siano ordinati)
function addToSortedSet(value) {
    if (!sortedSet.includes(value)) {
        sortedSet.push(value);
        sortedSet.sort(); // Ordina l'array dopo ogni aggiunta
    }
}

// Loop con break/continue
for (var i = 0; i < sortedSet.length; i++) {
    var item = sortedSet[i];
    
    if (item === "value2") {
        continue; // Salta il valore "value2"
    }
    
    if (item === "value3") {
        break; // Esci dal ciclo quando si raggiunge "value3"
    }

    console.log("Elemento: " + item);
}

// Aggiungi un elemento
addToSortedSet("value4");
console.log("Elemento con valore value4 aggiunto.");

// Rimuovi un elemento
function removeFromSortedSet(value) {
    var index = sortedSet.indexOf(value);
    if (index !== -1) {
        sortedSet.splice(index, 1);
        console.log("Elemento con valore " + value + " rimosso.");
    }
}

removeFromSortedSet("value2");

// Check esistenza
function existsInSortedSet(value) {
    return sortedSet.includes(value);
}

if (existsInSortedSet("value1")) {
    console.log("Chiave value1 esiste.");
} else {
    console.log("Chiave value1 non trovata.");
}

//-------------------------------------------------------------QUEUE---------------------------------------------------------
// Inizializza una coda (queue)
const queue = [];

// Aggiungi elementi in coda
queue.push("elemento1");
queue.push("elemento2");
queue.push("elemento3");

// Loop con break/continue
for (let i = 0; i < queue.length; i++) {
    const elemento = queue[i];

    if (elemento === "elemento2") {
        continue; // Salta "elemento2"
    }

    if (elemento === "elemento3") {
        break; // Esci dal ciclo quando si raggiunge "elemento3"
    }

    console.log("Elemento:", elemento);
}

// Aggiungi un elemento in coda
queue.push("elemento4");
console.log("Elemento 'elemento4' aggiunto in coda.");

// Rimuovi il primo elemento dalla coda
const elementoRimosso = queue.shift();
console.log("Elemento rimosso dalla coda:", elementoRimosso);

// Verifica l'esistenza di un valore
const elementoCercato = "elemento1";
const esiste = queue.includes(elementoCercato);
if (esiste) {
    console.log(`L'elemento '${elementoCercato}' esiste nella coda.`);
} else {
    console.log(`L'elemento '${elementoCercato}' non esiste nella coda.`);
}
//----------------------------------------------------------------STACK-------------------------------------------------------------------------------
// Inizializza uno stack utilizzando un array vuoto
let stack = [];

// Aggiungi elementi allo stack (push)
stack.push("elemento1");
stack.push("elemento2");
stack.push("elemento3");

// Loop con break/continue
for (let i = stack.length - 1; i >= 0; i--) {
    let elemento = stack[i];

    if (elemento === "elemento2") {
        continue; // Salta "elemento2"
    }

    if (elemento === "elemento3") {
        break; // Esci dal ciclo quando si raggiunge "elemento3"
    }

    console.log("Elemento: " + elemento);
}

// Aggiungi un elemento allo stack (push)
stack.push("elemento4");
console.log("Elemento 'elemento4' aggiunto allo stack.");

// Rimuovi l'ultimo elemento dallo stack (pop)
let elementoRimosso2 = stack.pop();
console.log("Elemento rimosso dallo stack: " + elementoRimosso);

// Verifica l'esistenza di un valore
let elementoCercato2 = "elemento1";
let esiste2 = stack.indexOf(elementoCercato) !== -1;

if (esiste2) {
    console.log("L'elemento '" + elementoCercato2 + "' esiste nello stack.");
} else {
    console.log("L'elemento '" + elementoCercato2 + "' non esiste nello stack.");
}


if (esiste) {
    console.log("L'elemento '" + elementoCercato + "' esiste nello stack.");
} else {
    console.log("L'elemento '" + elementoCercato + "' non esiste nello stack.");
}

//---------------------------------------------------------LINKED LIST----------------------------------------------------


class Node {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {
        this.head = null;
    }

    // Aggiungi un elemento alla fine della lista collegata
    add(value) {
        const newNode = new Node(value);
        if (!this.head) {
            this.head = newNode;
        } else {
            let current = this.head;
            while (current.next) {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    // Rimuovi un elemento dalla lista collegata
    remove(value) {
        if (!this.head) {
            return;
        }
        if (this.head.value === value) {
            this.head = this.head.next;
            return;
        }
        let current = this.head;
        while (current.next) {
            if (current.next.value === value) {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }

    // Verifica l'esistenza di un valore
    contains(value) {
        let current = this.head;
        while (current) {
            if (current.value === value) {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    // Loop con break/continue
    loopWithBreakContinue(searchValue) {
        let current = this.head;
        while (current) {
            if (current.value === searchValue) {
                break; // Esci dal ciclo quando si trova il valore cercato
            }
            // Puoi usare "continue" se desideri saltare un'iterazione
            current = current.next;
        }
    }

    // Visualizza gli elementi della lista collegata
    display() {
        let current = this.head;
        while (current) {
            console.log(current.value);
            current = current.next;
        }
    }
}

// Esempio di utilizzo
const linkedList = new LinkedList();
linkedList.add("Elemento1");
linkedList.add("Elemento2");
linkedList.add("Elemento3");

console.log("Lista collegata originale:");
linkedList.display();

linkedList.loopWithBreakContinue("Elemento2");

console.log("\nDopo il loop con break/continue:");
linkedList.display();

linkedList.remove("Elemento2");

console.log("\nDopo la rimozione di 'Elemento2':");
linkedList.display();

console.log("\nL'elemento 'Elemento3' ", linkedList.contains("Elemento3") ? "esiste" : "non esiste", " nella lista collegata.");


