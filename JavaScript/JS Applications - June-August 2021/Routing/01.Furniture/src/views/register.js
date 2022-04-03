import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/data.js";

let templateRegister = (Submit, invalidEmail, invalidPass, invalidRePass) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${Submit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class=${'form-control' + (invalidEmail ? ' is-invalid' : 'is-valid' )} id="email" type="text"
                    name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class=${'form-control' + (invalidPass ? ' is-invalid' : 'is-valid' )} id="password" type="password"
                    name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class=${'form-control' + (invalidRePass ? ' is-invalid' : 'is-valid' )} id="rePass" type="password"
                    name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;

export async function pageRegister(ctx) {
    ctx.render(templateRegister(Submit));

    async function Submit(e) {
        e.preventDefault();
        let formData = new FormData(e.target);
        let email = formData.get('email');
        let password = formData.get('password');
        let rePass = formData.get('rePass');
        if (email == '' || password == '' || rePass == '') {
            ctx.render(templateRegister(Submit, email == '', password == '', rePass == ''));
            return alert('All fields are required!');
        }
        if (rePass != password) {
            ctx.render(templateRegister(Submit, false, true, true));
            return alert('Passwords don\'t match!');
        }
        await register(email, password);
        ctx.setNavigation();
        ctx.page.redirect('/');
    }
}