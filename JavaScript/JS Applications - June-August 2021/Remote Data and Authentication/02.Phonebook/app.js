function attachEvents() {
    let url = `http://localhost:3030/jsonstore/phonebook`;
    let buttonLoad = document.getElementById('btnLoad');
    buttonLoad.addEventListener('click', Load)

    let buttonCreate = document.getElementById('btnCreate');
    buttonCreate.addEventListener('click', Create)

    async function Load(){
        let response = await fetch(url);
        let data = await response.json();      
        let ul = document.getElementById('phonebook');
        ul.innerHTML = '';
        for (const key in data) {
            let li = document.createElement('li');
            li.setAttribute('id', data[key]._id);
            li.textContent = `${data[key].person}: ${data[key].phone}`;
            let buttonDelete = document.createElement('button');
            buttonDelete.textContent = 'Delete';
            li.appendChild(buttonDelete);
            buttonDelete.addEventListener('click', Delete);            
            ul.appendChild(li);
        }
    }

    async function Delete(event){
        let id = event.currentTarget.parentElement.id;
        event.currentTarget.parentElement.remove();
        let response = await fetch(`${url}/${id}`, {
            method: 'delete',
            headers: { 'Content-Type': 'application/json' },
        })        
    }

    async function Create(){
        let person = document.getElementById('person').value;
        let phone = document.getElementById('phone').value;
        document.getElementById('person').value = '';
        document.getElementById('phone').value = '';
        let contact = {
            person: person,
            phone: phone
        };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(contact)
        });
        Load();
    }
}

attachEvents();