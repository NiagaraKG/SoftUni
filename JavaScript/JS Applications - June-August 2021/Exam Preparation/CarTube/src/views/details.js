import { html } from '../../node_modules/lit-html/lit-html.js';
import { DeleteById, getById } from '../api/data.js';

let templateDetails = (item, isOwner, DeleteItem) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${item.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${item.brand}</li>
            <li><span>Model:</span>${item.model}</li>
            <li><span>Year:</span>${item.year}</li>
            <li><span>Price:</span>${item.price}$</li>
        </ul>

        <p class="description-para">${item.description}</p>
        ${isOwner ? html`
        <div class="listings-buttons">
            <a href="/edit/${item._id}" class="button-list">Edit</a>
            <a @click=${DeleteItem} href="javascript:void(0)" class="button-list">Delete</a>
        </div>`: ''}
    </div>
</section>`;

export async function pageDetails(ctx) {
    let itemId = ctx.params.id;
    let item = await getById(itemId);
    let isOwner = ctx.user && item._ownerId == ctx.user._id;
    ctx.render(templateDetails(item, isOwner, DeleteItem));

    async function DeleteItem() {
        let confirmed = confirm('Are you sure you want to delete this item?');
        if(confirmed){
            await DeleteById(itemId);
            ctx.page.redirect('/dashboard');
        }
    }
}