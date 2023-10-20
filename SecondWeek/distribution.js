function generateUniformRandomVariates(N, k) {
    const intervals = Array.from({ length: k }, (_, i) => i / k);
    const counts = new Array(k).fill(0);
  
    for (let i = 0; i < N; i++) {
      const randomValue = Math.random();
      for (let j = 0; j < k; j++) {
        if (randomValue >= intervals[j] && randomValue < intervals[j + 1]) {
          counts[j]++;
          break;
        }
      }
    }
  
    return counts;
  }
  
  const N = 1000;
  const k = 10;
  const distribution = generateUniformRandomVariates(N, k);
  
  const resultsElement = document.getElementById("results"); // Seleziona l'elemento risultati
  resultsElement.innerHTML = ""; // Pulisci il contenuto
  
  const header = document.createElement("h2");
  header.innerText = "Distribuzione delle variabili casuali generate in " + k + " classi:";
  resultsElement.appendChild(header);
  
  for (let i = 0; i < k; i++) {
    const intervalStart = i / k;
    const intervalEnd = (i + 1) / k;
    const frequency = distribution[i];
    const resultText = `Classe [${intervalStart.toFixed(1)}, ${intervalEnd.toFixed(1)}): ${frequency}`;
    const resultElement = document.createElement("p");
    resultElement.innerText = resultText;
    resultsElement.appendChild(resultElement);
  }
  
  