import { html } from '../../node_modules/lit-html/lit-html.js';
import { Create } from '../api/data.js';

let templateCreate = (Submit) => html`
<section id="create-page" class="create">
    <form id="create-form" @submit=${Submit}>
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
        </fieldset>
    </form>
</section>`;

export async function pageCreate(ctx) {
    ctx.render(templateCreate(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let item = {
            title: form.get('title'),
            description: form.get('description'),
            imageUrl: form.get('imageUrl'),
            type: form.get('type')
        };
        if (item.title == '' || item.description == '' || item.imageUrl == ''
            || item.type == '') { alert('All fields are required!'); }
        else {
            await Create(item);
            e.target.reset();
            ctx.page.redirect('/dashboard');
        }
    }
}