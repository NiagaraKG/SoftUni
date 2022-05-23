import { html } from '../../node_modules/lit-html/lit-html.js';
import { Edit, getById } from '../api/data.js';

let templateEdit = (item, Submit) => html`
<section id="edit-page" class="edit">
    <form id="edit-form" @submit=${Submit}>
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value=${item.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" .value=${item.description}></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${item.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${item.type}>
                        <option value="Fiction" >Fiction</option>
                        <option value="Romance" >Romance</option>
                        <option value="Mistery" >Mistery</option>
                        <option value="Classic" >Clasic</option>
                        <option value="Other" >Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>`;

export async function pageEdit(ctx) {
    let itemId = ctx.params.id;
    let item = await getById(itemId);
    ctx.render(templateEdit(item, Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let newItem = {
            title: form.get('title'),
            description: form.get('description'),
            imageUrl: form.get('imageUrl'),
            type: form.get('type')
        };
        if (newItem.title == '' || newItem.description == '' || newItem.imageUrl == '' || newItem.type == '') {
            alert('All fields are required!');
        }
        else {
            await Edit(itemId, newItem);
            e.target.reset();
            ctx.page.redirect(`/details/${itemId}`);
        }
    }
}