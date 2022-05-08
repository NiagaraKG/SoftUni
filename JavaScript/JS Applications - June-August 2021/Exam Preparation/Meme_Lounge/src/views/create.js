import { html } from "../../node_modules/lit-html/lit-html.js";
import { Create } from "../api/data.js";
import { Notify } from "../notification.js";

let templateCreate = (Submit) => html`
<section id="create-meme">
    <form id="create-form" @submit=${Submit}>
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>`;

export async function pageCreate(ctx) {
    ctx.render(templateCreate(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let title = form.get('title');
        let description = form.get('description');
        let imageUrl = form.get('imageUrl');
        try {
            if (title == '' || description == '' || imageUrl == '') {
                throw new Error('All fields are required!');
            }
            await Create({ title, description, imageUrl });
            ctx.page.redirect('/dashboard');
        } catch(error) { Notify(error.message); }
    }
}