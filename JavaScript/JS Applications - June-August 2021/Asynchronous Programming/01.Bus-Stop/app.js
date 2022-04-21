async function getInfo() {
    let ID = document.getElementById('stopId').value;    
    let ul = document.getElementById('buses');
    ul.innerHTML = '';
    let url = `http://localhost:3030/jsonstore/bus/businfo/${ID}`;
    try{
        let response = await fetch(url);
        let returnedStop = await response.json();
        document.getElementById('stopName').textContent = returnedStop.name;
        Object.keys(returnedStop.buses).forEach(busNum => {
            let li = document.createElement('li');
            li.textContent = `Bus ${busNum} arrives in ${returnedStop.buses[busNum]} minutes.`;
            ul.appendChild(li);
        });
        document.getElementById('stopId').value = '';
    }
    catch(error){
        document.getElementById('stopName').textContent = 'Error';
    }
}