import { html, render } from "../node_modules/lit-html/lit-html.js";
let tbody = document.querySelector('tbody');
let input = document.getElementById('searchField');

let template = (student, select) => html`
<tr class=${select ? 'select' : ''}>
   <td>${student.firstName} ${student.lastName}</td>
   <td>${student.email}</td>
   <td>${student.course}</td>
</tr>`;

function Update(list, match = '') {
   let result = list.map(el => template(el, Compare(el, match)));
   render(result, tbody);
}

function Compare(item, match) {
   return Object.values(item).some(x => match && x.toLowerCase().includes(match.toLowerCase()))
}

async function Start() {
   document.getElementById('searchBtn').addEventListener('click', () => { Update(students, input.value); });
   let url = `http://localhost:3030/jsonstore/advanced/table`;
   let response = await fetch(url);
   let data = await response.json();
   let students = Object.values(data);
   Update(students);
}

Start();