import { html } from "../../node_modules/lit-html/lit-html.js";
import { DeleteById, getById } from "../api/data.js";

let templateDetails = (item, isOwner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${item.title} </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${item.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${item.description} </p>
            ${isOwner ? html`
            <a class="button warning" href="/edit/${item._id}">Edit</a>
            <button class="button danger" @click=${onDelete}>Delete</button>` : ''}
        </div>
    </div>
</section>`;

export async function pageDetails(ctx) {
    let userId = sessionStorage.getItem('userId');
    let itemId = ctx.params.id;
    let item = await getById(itemId);
    let isOwner = userId === item._ownerId;
    ctx.render(templateDetails(item, isOwner, onDelete));

    async function onDelete() {
        let confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await DeleteById(itemId);
            ctx.page.redirect('/dashboard');
        }
    }
}