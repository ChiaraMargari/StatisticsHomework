using System;
using System.Collections.Generic;

//-----------------------------------------------------ARRAY--------------------------------------------

    
        // Creazione di un array
        int[] myArray = { 1, 2, 3, 4, 5 };

        // Loop con break e continue
        foreach (int item in myArray)
        {
            // Usa break per uscire dal ciclo in base a una condizione
            if (item == 3)
            {
                break;
            }

            // Usa continue per saltare un'iterazione in base a una condizione
            if (item == 2)
            {
                continue;
            }

            Console.WriteLine(item);
        }

        // Aggiunta di elementi in coda
        Array.Resize(ref myArray, myArray.Length + 1);
        myArray[myArray.Length - 1] = 6;

        // Rimozione dell'ultimo elemento
        int removedElement = myArray[myArray.Length - 1];
        Array.Resize(ref myArray, myArray.Length - 1);

        // Ottenere/Impostare un elemento
        int elementAtIndex2 = myArray[2];
        myArray[1] = 10;

        // Verifica l'esistenza di un elemento in base all'indice
        int indexToCheck = 4;
        if (indexToCheck >= 0 && indexToCheck < myArray.Length)
        {
            Console.WriteLine("L'elemento all'indice " + indexToCheck + " esiste: " + myArray[indexToCheck]);
        }


//------------------------------------------------------LIST---------------------------------------------------


        // Creazione di una lista
        List<int> myList = new List<int> { 1, 2, 3, 4, 5 };

        // Loop con foreach
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        // Aggiunta di elementi in coda
        myList.Add(6);

        // Rimozione dell'ultimo elemento
        int removedElement = myList[myList.Count - 1];
        myList.RemoveAt(myList.Count - 1);

        // Ottenere/Impostare un elemento
        int elementAtIndex = myList[2];
        myList[1] = 10;

        // Verifica l'esistenza di un elemento in base all'indice
        int indexToCheck = 4;
        if (indexToCheck >= 0 && indexToCheck < myList.Count)
        {
            Console.WriteLine("L'elemento all'indice " + indexToCheck + " esiste: " + myList[indexToCheck]);
        }


//--------------------------------------------------------------------DIZIONARIO------------------------------------------------
     
        
        // Crea un oggetto Dictionary
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            {"key1", "value1"},
            {"key2", "value2"},
            {"key3", "value3"}
        };

        // Loop sulle chiavi
        foreach (var key in dictionary.Keys)
        {
            Console.WriteLine(key + ": " + dictionary[key]);
        }

        // Aggiungi un elemento
        dictionary["key4"] = "value4";
        Console.WriteLine("Elemento con chiave key4: " + dictionary["key4"]);

        // Rimuovi un elemento
        dictionary.Remove("key2");
        Console.WriteLine("Elemento con chiave key2 rimosso.");

        // Verifica l'esistenza di una chiave
        string keyToCheck = "key1";
        if (dictionary.ContainsKey(keyToCheck))
        {
            Console.WriteLine(keyToCheck + " esiste.");
        }


//----------------------------------------------------------------SORTED LIST----------------------------------------------------------------

        SortedList sortedList = new SortedList();

        // Aggiungi elementi
        sortedList.Add("key1", "value1");
        sortedList.Add("key2", "value2");
        sortedList.Add("key3", "value3");

        // Loop con break/continue
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Key.Equals("key2"))
                continue; // Salta il valore con chiave "key2"
            if (entry.Key.Equals("key3"))
                break; // Esci dal ciclo quando la chiave è "key3"
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        // Aggiungi un elemento in modo ordinato
        sortedList["key4"] = "value4";
        Console.WriteLine("Elemento con chiave key4 aggiunto.");

        // Rimuovi un elemento
        sortedList.Remove("key2");
        Console.WriteLine("Elemento con chiave key2 rimosso.");

        // Get e check esistenza
        if (sortedList.ContainsKey("key1"))
        {
            var value = sortedList["key1"];
            Console.WriteLine($"Elemento con chiave key1: {value}");
        }
        else
        {
            Console.WriteLine("Chiave key1 non trovata.");
        }


//------------------------------------------------------------HASH SET---------------------------------------------------------------------

        // Inizializza un HashSet
        var hashSet = new HashSet<string>();

        // Aggiungi elementi
        hashSet.Add("value1");
        hashSet.Add("value2");
        hashSet.Add("value3");

        // Loop con break/continue
        foreach (var item in hashSet)
        {
            if (item == "value2")
            {
                continue; // Salta il valore "value2"
            }
            if (item == "value3")
            {
                break; // Esci dal ciclo quando si raggiunge "value3"
            }
            Console.WriteLine("Elemento: " + item);
        }

        // Aggiungi un elemento
        hashSet.Add("value4");
        Console.WriteLine("Elemento con valore value4 aggiunto.");

        // Rimuovi un elemento
        if (hashSet.Contains("value2"))
        {
            hashSet.Remove("value2");
            Console.WriteLine("Elemento con valore value2 rimosso.");
        }

        // Check esistenza
        if (hashSet.Contains("value1"))
        {
            Console.WriteLine("Chiave value1 esiste.");
        }
        else
        {
            Console.WriteLine("Chiave value1 non trovata.");
        }


//----------------------------------------------------------------------SORTED SET-------------------------------------------------------------------

        // Inizializza un set ordinato (emulato)
        var sortedSet = new SortedSet<string>();

        // Aggiungi elementi
        sortedSet.Add("value1");
        sortedSet.Add("value2");
        sortedSet.Add("value3");

        // Loop con break/continue
        foreach (var item in sortedSet)
        {
            if (item == "value2")
                continue; // Salta il valore "value2"

            if (item == "value3")
                break; // Esci dal ciclo quando si raggiunge "value3"

            Console.WriteLine("Elemento: " + item);
        }

        // Aggiungi un elemento
        sortedSet.Add("value4");
        Console.WriteLine("Elemento con valore value4 aggiunto.");

        // Rimuovi un elemento
        sortedSet.Remove("value2");
        Console.WriteLine("Elemento con valore value2 rimosso.");

        // Check esistenza
        bool exists = sortedSet.Contains("value1");
        if (exists)
            Console.WriteLine("Chiave value1 esiste.");
        else
            Console.WriteLine("Chiave value1 non trovata.");

        
//------------------------------------------------------------------QUEUE----------------------------------------------------------------------------

        // Inizializza una coda
        Queue queue = new Queue();

        // Aggiungi elementi in coda
        queue.Enqueue("elemento1");
        queue.Enqueue("elemento2");
        queue.Enqueue("elemento3");

        // Loop con break/continue
        foreach (var elemento in queue)
        {
            if (elemento.Equals("elemento2"))
            {
                continue; // Salta "elemento2"
            }

            if (elemento.Equals("elemento3"))
            {
                break; // Esci dal ciclo quando si raggiunge "elemento3"
            }

            Console.WriteLine("Elemento: " + elemento);
        }

        // Aggiungi un elemento in coda
        queue.Enqueue("elemento4");
        Console.WriteLine("Elemento 'elemento4' aggiunto in coda.");

        // Rimuovi il primo elemento dalla coda
        var elementoRimosso = queue.Dequeue();
        Console.WriteLine("Elemento rimosso dalla coda: " + elementoRimosso);

        // Verifica l'esistenza di un valore
        string elementoCercato = "elemento1";
        bool esiste = queue.Contains(elementoCercato);
        if (esiste)
        {
            Console.WriteLine("L'elemento '" + elementoCercato + "' esiste nella coda.");
        }
        else
        {
            Console.WriteLine("L'elemento '" + elementoCercato + "' non esiste nella coda.");
        }


//---------------------------------------------------------STACK-----------------------------------------------------------

        Stack stack = new Stack();

        // Aggiungi elementi allo Stack
        stack.Push("Elemento1");
        stack.Push("Elemento2");
        stack.Push("Elemento3");

        Console.WriteLine("Stack originale:");
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        // Loop con break/continue
        Console.WriteLine("\nLoop con break/continue:");
        foreach (var item in stack)
        {
            if (item.Equals("Elemento2"))
            {
                break; // Esci dal ciclo quando si trova "Elemento2"
            }
            Console.WriteLine(item);
        }

        // Rimuovi un elemento dallo Stack
        var elementoRimosso = stack.Pop();
        Console.WriteLine($"\nElemento rimosso dallo Stack: {elementoRimosso}");

        // Verifica l'esistenza di un valore
        string elementoCercato = "Elemento1";
        bool esiste = stack.Contains(elementoCercato);
        Console.WriteLine($"\nL'elemento '{elementoCercato}' {(esiste ? "esiste" : "non esiste")} nello Stack."); 


//----------------------------------------------------------LINKED LIST-------------------------------------------
class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}

class LinkedList<T>
{
    private Node<T> head;

    public void Add(T value)
    {
        var newNode = new Node<T>(value);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Remove(T value)
    {
        if (head == null)
        {
            return;
        }

        if (head.Value.Equals(value))
        {
            head = head.Next;
            return;
        }

        var current = head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(value))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public bool Contains(T value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void LoopWithBreakContinue(T searchValue)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(searchValue))
            {
                break; // Esci dal ciclo quando si trova il valore cercato
            }
            // Puoi usare "continue" se desideri saltare un'iterazione
            current = current.Next;
        }
    }

    public void Display()
    {
        var current = head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var linkedList = new LinkedList<string>();
        linkedList.Add("Elemento1");
        linkedList.Add("Elemento2");
        linkedList.Add("Elemento3");

        Console.WriteLine("Lista collegata originale:");
        linkedList.Display();

        linkedList.LoopWithBreakContinue("Elemento2");

        Console.WriteLine("\nDopo il loop con break/continue:");
        linkedList.Display();

        linkedList.Remove("Elemento2");

        Console.WriteLine("\nDopo la rimozione di 'Elemento2':");
        linkedList.Display();

        Console.WriteLine("\nL'elemento 'Elemento3' " + (linkedList.Contains("Elemento3") ? "esiste" : "non esiste") + " nella lista collegata.");
    }
}