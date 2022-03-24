function addDestination() {
    let city = document.getElementsByTagName('input')[0].value;
    let country = document.getElementsByTagName('input')[1].value;
    let season = document.getElementById('seasons').value;
    document.getElementsByTagName('input')[0].value = '';
    document.getElementsByTagName('input')[1].value = '';
    document.getElementById('seasons').value = 'summer';
    if (city != '' && country != '') {
        let tableBody = document.getElementById('destinationsList');
        let tr = document.createElement('tr');
        let destinationTd = document.createElement('td');
        destinationTd.textContent = `${city}, ${country}`;
        let seasonTd = document.createElement('td');
        seasonTd.textContent = season[0].toUpperCase() + season.substring(1);
        tr.appendChild(destinationTd);
        tr.appendChild(seasonTd);
        tableBody.appendChild(tr);
        let destinationSum = document.getElementById(season);
        destinationSum.value++;
    }
}