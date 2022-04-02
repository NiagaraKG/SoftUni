import { html } from "../../node_modules/lit-html/lit-html.js";
import { Create } from "../api/data.js";

let templateCreate = (Submit, invalidMake, invalidModel, invalidYear,
    invalidDescription, invalidPrice, invalidImage) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${Submit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control' + (invalidMake ? ' is-invalid' : 'is-valid' )} id="new-make" type="text" name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (invalidModel ? ' is-invalid' : 'is-valid' )} id="new-model" type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (invalidYear ? ' is-invalid' : 'is-valid' )} id="new-year" type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (invalidDescription ? ' is-invalid' : 'is-valid' )} id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (invalidPrice ? ' is-invalid' : 'is-valid' )} id="new-price" type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (invalidImage ? ' is-invalid' : 'is-valid' )} id="new-image" type="text" name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-info" value="Create" />
        </div>
    </div>
</form>`;

export async function pageCreate(ctx) {
    ctx.render(templateCreate(Submit));

    async function Submit(e) {
        e.preventDefault();
        let formData = new FormData(e.target);
        let make = formData.get('make');
        let model = formData.get('model');
        let year = Number(formData.get('year'));
        let description = formData.get('description');
        let price = Number(formData.get('price'));
        let img = formData.get('img');
        let material = formData.get('material');
        let newItem = {make, model, year, description, price, img, material};

        let invalidMake = false, invalidModel = false;
        let invalidYear = false, invalidDescription = false;
        let invalidPrice = false, invalidImage = false;
        let errorMessage = '';

        if (make.length < 4) {
            invalidMake = true;
            errorMessage += 'Make must be at least 4 symbols.\n';
        }
        if (model.length < 4) {
            invalidModel = true;
            errorMessage += 'Model must be at least 4 symbols.\n';
        }
        if (year == '' || year < 1950 || year > 2050) {
            invalidYear = true;
            errorMessage += 'Year must be between 1950 and 2050.\n';
        }
        if (description.length <= 10) {
            invalidDescription = true;
            errorMessage += 'Description must be more than 10 symbols.\n';
        }
        if (price == '' || price <= 0) {
            invalidPrice = true;
            errorMessage += 'Price must be positive number.\n';
        }
        if (img == '') {
            invalidImage = true;
            errorMessage += 'Image URL is required.\n';
        }
        if (invalidMake || invalidModel || invalidYear
            || invalidDescription || invalidPrice || invalidImage) {
            ctx.render(templateCreate(Submit, invalidMake, invalidModel,
                invalidYear, invalidDescription, invalidPrice, invalidImage));
            return alert(errorMessage);
        }
        await Create(newItem);
        ctx.page.redirect('/');
    }
}