import { html, render } from "../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";

let section = document.getElementById('allCats');

let template = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id=${cat.id}>
            <h4 class="card-title">Status Code: ${cat.statusCode}</h4>
            <p class="card-text">${cat.statusMessage}</p>
        </div>
    </div>
</li>`;

let ul = html`
<ul @click=${ViewStatus}>
    ${cats.map(template)}
</ul>`;

render(ul, section);

function ViewStatus(e) {
    let status = e.target.parentElement.querySelector('.status');
    if (status.style.display == 'none') {
        status.removeAttribute('style');
        e.target.parentElement.querySelector('.showBtn').textContent = 'Hide status code';
    }
    else {
        status.style.display = 'none';
        e.target.parentElement.querySelector('.showBtn').textContent = 'Show status code';
    }
}
