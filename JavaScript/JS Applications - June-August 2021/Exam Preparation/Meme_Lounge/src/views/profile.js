import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMine } from "../api/data.js";

let templateProfile = (mine, username, email, gender) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${gender}.png">
        <div class="user-content">
            <p>Username: ${username}</p>
            <p>Email: ${email}</p>
            <p>My memes count: ${mine.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        ${mine.length == 0 ? 
        html`<p class="no-memes">No memes in database.</p>`:
        mine.map(templateItem)}
    </div>
</section>`;

let templateItem = (item) => html`
<div class="user-meme">
    <p class="user-meme-title">${item.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${item.imageUrl}>
    <a class="button" href="/details/${item._id}">Details</a>
 </div>`;

export async function pageProfile(ctx) {
   let mine = await getMine();
   let username = sessionStorage.getItem('username');
   let email = sessionStorage.getItem('email');
   let gender = sessionStorage.getItem('gender');
    ctx.render(templateProfile(mine, username, email, gender));
}