var ExcelToJSON = function() {

    this.parseExcel = function(file) {
      var reader = new FileReader();

      reader.onload = function(e) {
        var data = e.target.result;
        var workbook = XLSX.read(data, {
          type: 'binary'
        });

        workbook.SheetNames.forEach(function(sheetName) {
          var XL_row_object = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
          displayDataInTable(XL_row_object);
          document.getElementById('output').innerHTML = '';
          calculateFrequency(XL_row_object, "Age", "frequencyAge");
          calculateFrequency(XL_row_object, "height", "frequencyheight");
          calculateFrequency(XL_row_object, "Country", "frequencyCountry");
          calculateJointDistribution(XL_row_object, "Country", "Age", "jointDistributionCountryAge");
        });

      };

      reader.onerror = function(ex) {
        console.log(ex);
      };

      reader.readAsBinaryString(file);
    };
  };

  function displayDataInTable(data) {
    var table = document.createElement('table');
    var thead = table.createTHead();
    var tbody = table.createTBody();

    var headerRow = thead.insertRow(0);
    for (var key in data[0]) {
      var th = document.createElement('th');
      th.innerHTML = key;
      headerRow.appendChild(th);
    }

    data.forEach(function (row) {
      var newRow = tbody.insertRow();
      for (var key in row) {
        var cell = newRow.insertCell();
        cell.innerHTML = row[key];
      }
    });

    document.getElementById('output').innerHTML = '';
    document.getElementById('output').appendChild(table);
  }

  function calculateFrequency(data, variableName, outputElementId) {
    var frequencies = {};
    var totalEntries = data.length;

    data.forEach(function (entry) {
      var value = entry[variableName];

      if (value in frequencies) {
        frequencies[value]++;
      } else {
        frequencies[value] = 1;
      }
    });

    var result = '<h3>Variable: '+ variableName+ '</h3>';
    result += '<table>';
    result += '<tr><th>Valore</th><th>Absolute frequence</th><th>Relative frquence </th><th>Percentage frequence</th></tr>';

    for (var value in frequencies) {
      var frequency = frequencies[value];
      var relativeFrequency = frequency / totalEntries;
      var percentage = (relativeFrequency * 100).toFixed(2);

      result += '<tr><td>' + value + '</td><td>' + frequency + '</td><td>' + relativeFrequency.toFixed(2) + '</td><td>' + percentage + '%</td></tr>';
    }

    result += '</table>';

    document.getElementById(outputElementId).innerHTML = result;
  }

  function calculateJointDistribution(data, variable1, variable2, outputElementId) {
    var jointDistribution = {};

    data.forEach(function (entry) {
      var value1 = entry[variable1];
      var value2 = entry[variable2];

      var key = value1 + ' | ' + value2;

      if (jointDistribution[key]) {
        jointDistribution[key]++;
      } else {
        jointDistribution[key] = 1;
      }
    });

    var result = '<h3>JOINT DISTRIBUITION: ' + variable1 + ' and ' + variable2 + '</h3>';
    result += '<table>';
    result += '<tr><th>Valore</th><th>Absolute frequence</th><th>Relative Frequence</th><th>Percentage frequence</th></tr>';

    for (var key in jointDistribution) {
      var frequency = jointDistribution[key];
      var relativeFrequency = frequency / data.length;
      var percentage = (relativeFrequency * 100).toFixed(2);

      result += '<tr><td>' + key + '</td><td>' + frequency + '</td><td>' + relativeFrequency.toFixed(2) + '</td><td>' + percentage + '%</td></tr>';
    }

    result += '</table>';

    document.getElementById(outputElementId).innerHTML = result;
  }

  
  document.getElementById('fileInput').addEventListener('change', function (e) {
    var file = e.target.files[0];
    if (file) {
      var excelParser = new ExcelToJSON();
      excelParser.parseExcel(file);
    }
  });