function solve() {
    let url = `http://localhost:3030/jsonstore/collections/books`;
    let buttonLoad = document.getElementById('loadBooks');
    buttonLoad.addEventListener('click', LoadTable);
    let form = document.querySelector('form');
    form.addEventListener('submit', SubmitBook);

    async function SubmitBook(event) {
        event.preventDefault();
        let title = document.querySelector("input[name='title']").value;
        let author = document.querySelector("input[name='author']").value;
        document.querySelector("input[name='title']").value = '';
        document.querySelector("input[name='author']").value = '';
        let book = {
            title: title,
            author: author,
        };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(book)
        });
        LoadTable();
    }

    async function LoadTable() {
        let response = await fetch(url);
        let data = await response.json();
        let table = document.querySelector('tbody');
        table.innerHTML = '';
        for (const key in data) {
            let tr = document.createElement('tr');
            let titleTD = document.createElement('td');
            titleTD.textContent = data[key].title;
            let authorTD = document.createElement('td');
            authorTD.textContent = data[key].author;
            let actionTD = document.createElement('td');
            let buttonEdit = document.createElement('button');
            buttonEdit.textContent = 'Edit';
            buttonEdit.setAttribute('id', key)
            buttonEdit.addEventListener('click', EditBook);
            let buttonDelete = document.createElement('button');
            buttonDelete.textContent = 'Delete';
            buttonDelete.addEventListener('click', Delete);
            actionTD.appendChild(buttonEdit);
            actionTD.appendChild(buttonDelete);
            tr.appendChild(titleTD);
            tr.appendChild(authorTD);
            tr.appendChild(actionTD);
            table.appendChild(tr);
        }
    }

    function EditBook(event) {
        let formTitle = document.querySelector('h3');
        formTitle.textContent = 'Edit Form';
        let titleField = document.querySelector("input[name='title']");
        let authorField = document.querySelector("input[name='author']");
        authorField.value = event.currentTarget.parentElement.previousElementSibling.textContent;
        titleField.value = event.currentTarget.parentElement.previousElementSibling.previousElementSibling.textContent;
        let button = document.querySelector('form button');
        button.textContent = 'Save';
        form.setAttribute('id', event.currentTarget.id);
        form.removeEventListener('submit', SubmitBook);
        form.addEventListener('submit', SaveBook);
    }

    async function SaveBook(event) {
        event.preventDefault();
        let id = event.currentTarget.id;
        let title = document.querySelector("input[name='title']").value;
        let author = document.querySelector("input[name='author']").value;
        document.querySelector("input[name='title']").value = '';
        document.querySelector("input[name='author']").value = '';
        let book = {
            title: title,
            author: author,
        };
        let response = await fetch(`${url}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(book)
        });
        let formTitle = document.querySelector('h3');
        formTitle.textContent = 'FORM';
        let button = document.querySelector('form button');
        button.textContent = 'Submit';
        button.setAttribute('id', '');
        form.removeEventListener('submit', SaveBook);
        form.addEventListener('submit', SubmitBook);
        LoadTable();
    }

    async function Delete(event) {
        let id = event.currentTarget.previousElementSibling.id;
        event.currentTarget.parentElement.parentElement.remove();
        let response = await fetch(`${url}/${id}`, {
            method: 'delete',
            headers: { 'Content-Type': 'application/json' },
        })  
    }
}
solve();