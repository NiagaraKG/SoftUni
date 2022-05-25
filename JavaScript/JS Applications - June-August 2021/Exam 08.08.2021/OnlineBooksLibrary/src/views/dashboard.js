import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAll } from '../api/data.js';

let templateDashboard = (all) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    ${all.length == 0 ? 
        html`<p class="no-books">No books in database!</p>` :
        html`<ul class="other-books-list"> ${all.map(templateItem)} </ul>` }
</section>`;

let templateItem = (item) => html`
<li class="otherBooks">
    <h3>${item.title}</h3>
    <p>Type: ${item.type}</p>
    <p class="img"><img src=${item.imageUrl}></p>
    <a class="button" href="/details/${item._id}">Details</a>
</li>`;

export async function pageDashboard(ctx) {
    let all = await getAll();
    ctx.render(templateDashboard(all));
}