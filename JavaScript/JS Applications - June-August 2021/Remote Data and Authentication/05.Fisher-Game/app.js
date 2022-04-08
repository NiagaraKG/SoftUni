function solve() {
    let url = `http://localhost:3030/data/catches`;
    let buttonLoad = document.querySelector('.load');
    buttonLoad.addEventListener('click', Load);
    let catchesDiv = document.querySelector('#catches');
    let buttonAdd = document.querySelector('.add');
    buttonAdd.addEventListener('click', Add);
    const token = sessionStorage.getItem('userToken');

    if (token) {
        buttonAdd.disabled = false;
        let buttonLogOut = document.querySelector('#guest [href="login.html"]');
        buttonLogOut.textContent = 'Logout';
        buttonLogOut.addEventListener('click', Logout);
        catchesDiv.innerHTML = '';
    }

    async function Add(event) {
        event.preventDefault();
        let angler = document.querySelector('#addForm .angler').value;
        let weight = document.querySelector('#addForm .weight').value;
        let species = document.querySelector('#addForm .species').value;
        let location = document.querySelector('#addForm .location').value;
        let bait = document.querySelector('#addForm .bait').value;
        let captureTime = document.querySelector('#addForm .captureTime').value;
        let currCatch = {
            angler: angler,
            weight: Number(weight),
            species: species,
            location: location,
            bait: bait,
            captureTime: Number(captureTime)
        };
        let response = await fetch(url, {
            method: 'Post',
            headers: { 'Content-Type': 'application/json', 'X-Authorization': token },
            body: JSON.stringify(currCatch)
        });
        let data = await response.json();
        let catchElement = CreateCatchElement(data);
        catchesDiv.appendChild(catchElement);

        document.querySelector('#addForm .angler').value = '';
        document.querySelector('#addForm .weight').value = '';
        document.querySelector('#addForm .species').value = '';
        document.querySelector('#addForm .location').value = '';
        document.querySelector('#addForm .bait').value = '';
        document.querySelector('#addForm .captureTime').value = '';
    }

    async function Load(event) {
        event.preventDefault();
        let response = await fetch(url);
        let catches = await response.json();
        catchesDiv.innerHTML = '';
        catches.array.forEach(c => catchesDiv.appendChild(CreateCatchElement(c)));
    }

    async function UpdateCatch(event) {
        event.preventDefault();
        let current = event.target.parentElement;
        let id = current.dataset.id;
        let angler = document.querySelector('.angler').value;
        let weight = document.querySelector('.weight').value;
        let species = document.querySelector('.species').value;
        let location = document.querySelector('.location').value;
        let bait = document.querySelector('.bait').value;
        let captureTime = document.querySelector('.captureTime').value;
        let updated = {
            angler: angler,
            weight: Number(weight),
            species: species,
            location: location,
            bait: bait,
            captureTime: Number(captureTime)
        };
        let response = await fetch(`${url}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', 'X-Authorization': token },
            body: JSON.stringify(updated)
        });
    }

    async function DeleteCatch(event) {
        event.preventDefault();
        let current = event.target.parentElement;
        let id = current.dataset.id;
        let response = await fetch(`${url}/${id}`, {
            method: 'Delete',
            headers: { 'X-Authorization': token },
        });
        current.remove();
    }

    function CreateCatchElement(currCatch) {
        let anglerLabel = CreateElement('label', undefined, 'Angler');
        let anglerInput = CreateElement('input', { type: 'text', class: 'angler' }, currCatch.angler);
        let hr1 = CreateElement('hr');
        let weightLabel = CreateElement('label', undefined, 'Weight');
        let weightInput = CreateElement('input', { type: 'number', class: 'weight' }, currCatch.weight);
        let hr2 = CreateElement('hr');
        let speciesLabel = CreateElement('label', undefined, 'Species');
        let speciesInput = CreateElement('input', { type: 'text', class: 'species' }, currCatch.species);
        let hr3 = CreateElement('hr');
        let locationLabel = CreateElement('label', undefined, 'Location');
        let locationInput = CreateElement('input', { type: 'text', class: 'location' }, currCatch.location);
        let hr4 = CreateElement('hr');
        let baitLabel = CreateElement('label', undefined, 'Bait');
        let baitInput = CreateElement('input', { type: 'text', class: 'bait' }, currCatch.bait);
        let hr5 = CreateElement('hr');
        let captureTimeLabel = CreateElement('label', undefined, 'Capture Time');
        let captureTimeInput = CreateElement('input', { type: 'number', class: 'captureTime' }, currCatch.captureTime);
        let hr6 = CreateElement('hr');
        let buttonUpdate = CreateElement('button', { disabled: true, class: 'update' }, 'Update');
        buttonUpdate.addEventListener('click', UpdateCatch);
        buttonUpdate.disabled = sessionStorage.getItem('userId') !== currCatch._ownerId;
        let buttonDelete = CreateElement('button', { disabled: true, class: 'delete' }, 'Delete');
        buttonDelete.addEventListener('click', DeleteCatch);
        buttonDelete.disabled = sessionStorage.getItem('userId') !== currCatch._ownerId;
        let catchElement = CreateElement('div', { class: 'catch' },
            anglerLabel, anglerInput, hr1, weightLabel, weightInput, hr2, speciesLabel, speciesInput,
            hr3, locationLabel, locationInput, hr4, baitLabel, baitInput, hr5, captureTimeLabel,
            captureTimeInput, hr6, buttonUpdate, buttonDelete);
        catchElement.dataset.id = currCatch._id;
        catchElement.dataset.ownerId = currCatch._ownerId;
        return catchElement;
    }


    function CreateElement(tag, attributes, ...params) {
        let el = document.createElement(tag);
        if (params.length === 1) {
            if (tag === 'input') { el.value = params[0]; }
            else { el.textContent = params[0]; }
        }
        else { el.append(...params); }
        if (attributes !== undefined) {
            Object.keys(attributes).forEach(k => { el.setAttribute(k, attributes[k]) });
        }
        return el;
    }

    async function Logout(event) {
        event.preventDefault();
        let token = sessionStorage.getItem('userToken');
        let id = sessionStorage.getItem('userId');
        let response = await fetch('http:localhost:3030/users/logout', {
            method: 'GET',
            headers: { 'X-Authorization': token }
        });
        if (!response.ok) {
            const error = await response.json();
            alert(error.message);
            return;
        }
        sessionStorage.removeItem('userToken');
        sessionStorage.removeItem('userId');
        event.target.textContent = 'Login';
        location.assign('./index.html');
    }
}
solve();