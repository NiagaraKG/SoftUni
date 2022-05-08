import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAll } from "../api/data.js";

let templateDashboard = (all) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${all.length == 0 ? 
        html`<p class="no-memes">No memes in database.</p>`:
        all.map(templateItem)}        
    </div>
</section>`;

let templateItem = (item) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${item.title}</p>
            <img class="meme-image" alt="meme-img" src=${item.imageUrl}>
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${item._id}">Details</a>
        </div>
    </div>
</div>`;

export async function pageDashboard(ctx) {
   let all = await getAll();
    ctx.render(templateDashboard(all));
}