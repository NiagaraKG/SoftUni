import { html } from "../../node_modules/lit-html/lit-html.js";
import { getById, Edit } from "../api/data.js";
import { Notify } from "../notification.js";

let templateEdit = (item, Submit) => html`
<section id="edit-meme">
    <form id="edit-form" @submit=${Submit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${item.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"
                .value=${item.description}> </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${item.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

export async function pageEdit(ctx) {
    let id = ctx.params.id;
    let item = await getById(id);
    ctx.render(templateEdit(item, Submit));

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
            await Edit(id, { title, description, imageUrl });
            ctx.page.redirect(`/details/${id}`);
        }
        catch (error) { Notify(error.message); }
    }
}