import { html } from '../../node_modules/lit-html/lit-html.js';
import { Edit, getById } from '../api/data.js';

let templateEdit = (item, Submit) => html`
<section id="edit-listing">
    <div class="container">

        <form id="edit-form" @submit=${Submit}>
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value=${item.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value=${item.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value=${item.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value=${item.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value=${item.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value=${item.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

export async function pageEdit(ctx) {
    let itemId = ctx.params.id;
    let item = await getById(itemId);
    ctx.render(templateEdit(item, Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let newItem = {
            brand: form.get('brand'),
            model: form.get('model'),
            description: form.get('description'),
            year: Number(form.get('year')),
            imageUrl: form.get('imageUrl'),
            price: Number(form.get('price'))
        };
        if (Number.isNaN(newItem.year) || Number.isNaN(newItem.price)
            || newItem.year <= 0 || newItem.price <= 0) {
            alert('Year and price must be positive numbers!');
        }
        if (newItem.brand == '' || newItem.model == '' || newItem.description == ''
            || newItem.imageUrl == '') { alert('All fields are required!'); }
        else {
            await Edit(itemId, newItem);
            e.target.reset();
            ctx.page.redirect(`/details/${itemId}`);
        }
    }
}