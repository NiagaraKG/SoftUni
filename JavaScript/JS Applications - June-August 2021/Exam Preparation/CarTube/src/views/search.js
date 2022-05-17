import { html } from '../../node_modules/lit-html/lit-html.js';
import { Search } from '../api/data.js';

let templateSearch = (found, searchYear, year) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year" .value=${year || ''}>
        <button @click=${searchYear} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${found.length == 0 ? html`<p class="no-cars">No results.</p>` : found.map(templateItem)}
    </div>
</section>`;

let templateItem = (item) => html`
<div class="listing">
    <div class="preview">
        <img src=${item.imageUrl}>
    </div>
    <h2>${item.brand} ${item.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${item.year}</h3>
            <h3>Price: ${item.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${item._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function pageSearch(ctx) {
    let year = Number(ctx.querystring.split('=')[1]);
    let found = Number.isNaN(year) ? [] : await Search(year);
    ctx.render(templateSearch(found, searchYear, year));

    function searchYear() {
        let query = Number(document.querySelector('input[name="search"]').value);
        ctx.page.redirect(`/search?query=${query}`);
    }
}