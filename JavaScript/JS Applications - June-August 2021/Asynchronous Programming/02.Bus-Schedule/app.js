function solve() {   
    let buttonDepart = document.getElementById('depart');
    let buttonArrive = document.getElementById('arrive');
    let currStop = {next: 'depot'};
    let banner = document.querySelector('#info span');

    async function depart() {
        let url = `http://localhost:3030/jsonstore/bus/schedule/${currStop.next}`;
        let response = await fetch(url);
        let returnedData = await response.json();
        currStop = returnedData;
        banner.textContent = `Next stop: ${currStop.name}`;
        buttonDepart.disabled = true;
        buttonArrive.disabled = false;
    }

    function arrive() {
        banner.textContent = `Arriving at: ${currStop.name}`;
        buttonDepart.disabled = false;
        buttonArrive.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();