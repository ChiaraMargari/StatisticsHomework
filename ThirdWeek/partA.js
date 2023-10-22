const M = 5; // Numero di sistemi di sicurezza
const N = 10; // Numero di attacchi
const p = 0.3; // Probabilità di penetrazione costante

// Inizializza l'array dei punteggi per ogni sistema
const scores = new Array(M).fill(0);

// Loop principale per simulare gli attacchi
for (let attack = 0; attack < N; attack++) {
    for (let system = 0; system < M; system++) {
        // Genera un numero casuale tra 0 e 1 per rappresentare l'esito dell'attacco
        const outcome = Math.random();

        // Aggiorna il punteggio del sistema in base all'esito dell'attacco
        if (outcome <= p) {
            scores[system] -= 1; // Sistema violato
        } else {
            scores[system] += 1; // Sistema protetto
        }
    }
}

// Riferimento all'elemento HTML in cui visualizzerai i risultati
const risultatiDiv = document.getElementById("risultati");

// Creazione di un elemento <p> per ogni punteggio e aggiunta al div dei risultati
for (let system = 0; system < M; system++) {
    const punteggio = scores[system];
    const risultatoElement = document.createElement("p");
    risultatoElement.textContent = `Punteggio del sistema ${system + 1}: ${punteggio}`;
    risultatiDiv.appendChild(risultatoElement);
}