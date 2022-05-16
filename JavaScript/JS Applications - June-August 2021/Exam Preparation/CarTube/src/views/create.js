import { html } from '../../node_modules/lit-html/lit-html.js';
import { Create } from '../api/data.js';

let templateCreate = (Submit) => html`
<section id="create-listing">
    <div class="container">
        <form id="create-form" @submit=${Submit}>
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>`;

export async function pageCreate(ctx) {
    ctx.render(templateCreate(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let item = {
            brand: form.get('brand'),
            model: form.get('model'),
            description: form.get('description'),
            year: Number(form.get('year')),
            imageUrl: form.get('imageUrl'),
            price: Number(form.get('price'))
        };
        if (Number.isNaN(item.year) || Number.isNaN(item.price)
            || item.year <= 0 || item.price <= 0) {
            alert('Year and price must be positive numbers!');
        }
        if (item.brand == '' || item.model == '' || item.description == ''
            || item.imageUrl == '') { alert('All fields are required!'); }
        else {
            await Create(item);
            e.target.reset();
            ctx.page.redirect('/dashboard');
        }
    }
}