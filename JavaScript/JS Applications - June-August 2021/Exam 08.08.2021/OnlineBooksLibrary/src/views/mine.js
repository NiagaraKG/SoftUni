import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMine } from '../api/data.js';

let templateMine = (mine) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    ${mine.length == 0 ? 
    html`<p class="no-books">No books in database!</p>` :
    html`<ul class="my-books-list"> ${mine.map(templateItem)} </ul>` }
</section>`;

let templateItem = (item) => html`
<li class="otherBooks">
    <h3>${item.title}</h3>
    <p>Type: ${item.type}</p>
    <p class="img"><img src=${item.imageUrl}></p>
    <a class="button" href="/details/${item._id}">Details</a>
</li>`;

export async function pageMine(ctx) {
    let mine = await getMine(ctx.user._id);
    ctx.render(templateMine(mine));
}