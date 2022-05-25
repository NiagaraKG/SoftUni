import { html } from '../../node_modules/lit-html/lit-html.js';
import { DeleteById, getById, getLikesByBookId, getOwnLikesByBookId, likeBook } from '../api/data.js';

let templateDetails = (item, isLogged, isOwner, DeleteItem, Like, likes, ownLike) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src=${item.imageUrl}></p>
        <div class="actions">
            ${isOwner ? html`
            <a class="button" href="/edit/${item._id}">Edit</a>
            <a class="button" @click=${DeleteItem} href="javascript:void(0)">Delete</a>` : ''}

            ${(!isLogged || isOwner || ownLike.length > 0) ? '' : html` <a class="button" @click=${Like}
                href="javascript:void(0)">Like</a>`}

            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likes ? likes.length : 0}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>`;

export async function pageDetails(ctx) {
    let itemId = ctx.params.id;
    let item = await getById(itemId);
    let isOwner = ctx.user && item._ownerId == ctx.user._id;
    let isLogged = ctx.user;
    let [likes, ownLike] = await Promise.all([getLikesByBookId(itemId), getOwnLikesByBookId(itemId, ctx.user._id)]);
    ctx.render(templateDetails(item, isLogged, isOwner, DeleteItem, Like, likes, ownLike));

    async function DeleteItem() {
        let confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await DeleteById(itemId);
            ctx.page.redirect('/dashboard');
        }
    }

    async function Like() {
        await likeBook({ bookId: itemId });
        [likes, ownLike] = await Promise.all([getLikesByBookId(itemId), getOwnLikesByBookId(itemId, ctx.user._id)]);
        ctx.render(templateDetails(item, isLogged, isOwner, DeleteItem, Like, likes, ownLike));
    }

}

