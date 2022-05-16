import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAll } from '../api/data.js';

let templateDashboard = (all) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
        ${all.length == 0 ? html`<p class="no-cars">No cars in database.</p>` : all.map(templateItem)}
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

export async function pageDashboard(ctx) {
    let all = await getAll();
    ctx.render(templateDashboard(all));
}