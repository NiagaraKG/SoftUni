import { html, render } from "../node_modules/lit-html/lit-html.js";

let root = document.getElementById('root');
let buttonLoad = document.getElementById('btnLoadTowns');
buttonLoad.addEventListener('click', Load);

let template = (data) => html`
<ul>
    ${data.map(t=> html`<li>${t}</li>`)}
</ul>`;

function Load(e){
    e.preventDefault();
    let towns = document.getElementById('towns').value.split(', ');
    let result = template(towns);
    render(result, root);
}