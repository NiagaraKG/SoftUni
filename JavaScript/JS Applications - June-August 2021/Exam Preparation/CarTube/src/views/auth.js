import { html } from '../../node_modules/lit-html/lit-html.js';
import { login, register } from '../api/data.js';

let templateLogin = (Submit) => html`
<section id="login">
    <div class="container">
        <form id="login-form" @submit=${Submit}>
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`;

export async function pageLogin(ctx) {
    ctx.render(templateLogin(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let username = form.get('username');
        let password = form.get('password');
        await login(username, password);
        e.target.reset();
        ctx.setNavigation();
        ctx.page.redirect('/dashboard');
    }
}


let templateRegister = (Submit) => html`
<section id="register">
    <div class="container">
        <form id="register-form" @submit=${Submit}>
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>`;

export async function pageRegister(ctx) {
    ctx.render(templateRegister(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let username = form.get('username');
        let password = form.get('password');
        let repeatPass = form.get('repeatPass');
        if (username == '' || password == '' || repeatPass == '') {
            alert('All fields are required!');
        }
        if (repeatPass != password) { alert('Passwords don\'t match!'); }
        await register(username, password);
        e.target.reset();
        ctx.setNavigation();
        ctx.page.redirect('/dashboard');
    }
}
