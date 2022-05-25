import { html } from '../../node_modules/lit-html/lit-html.js';
import { login, register } from '../api/data.js';

let templateLogin = (Submit) => html`
<section id="login-page" class="login">
    <form id="login-form" @submit=${Submit}>
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
        </fieldset>
    </form>
</section>`;

export async function pageLogin(ctx) {
    ctx.render(templateLogin(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let email = form.get('email');
        let password = form.get('password');
        if (email == '' || password == '') { alert('All fields are required'); }
        else {
            await login(email, password);
            e.target.reset();
            ctx.setNavigation();
            ctx.page.redirect('/dashboard');
        }
    }
}


let templateRegister = (Submit) => html`
<section id="register-page" class="register">
    <form id="register-form" @submit=${Submit}>
        <fieldset>
            <legend>Register Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>`;

export async function pageRegister(ctx) {
    ctx.render(templateRegister(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let email = form.get('email');
        let password = form.get('password');
        let repeatPass = form.get('confirm-pass');
        if (email == '' || password == '' || repeatPass == '') {
            alert('All fields are required!');
        }
        else if (repeatPass != password) { alert('Passwords don\'t match!'); }
        else {
            await register(email, password);
            e.target.reset();
            ctx.setNavigation();
            ctx.page.redirect('/dashboard');
        }
    }
}
