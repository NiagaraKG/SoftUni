import { html, render } from "../node_modules/lit-html/lit-html.js";

let template = (list) => html`
<select id="menu">
    ${list.map(el => html`<option value=${el._id}>${el.text}</option>`)}
</select>`;

let mainDiv = document.querySelector('div');
let url = `http://localhost:3030/jsonstore/advanced/dropdown`;
let input = document.getElementById('itemText');
Initialize();

function Update(list) {
    let result = template(list);
    render(result, mainDiv);
}

async function Initialize() {
    document.querySelector('form').addEventListener('submit', (e) => addItem(e, list));;
    let response = await fetch(url);
    let data = await response.json();
    let list = Object.values(data);
    Update(list);
}

async function addItem(e, list) {
    e.preventDefault();
    if (input.value == '') { alert('Text field can not be empty!'); }
    else {
        let item = { text: input.value };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(item)
        });
        let result = await response.json();
        list.push(result);
        Update(list);
        input.value = '';
    }
}