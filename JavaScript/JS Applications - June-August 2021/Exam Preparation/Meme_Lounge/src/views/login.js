import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/data.js";
import { Notify } from "../notification.js";

let templateLogin = (Submit) => html`
<section id="login">
    <form id="login-form" @submit=${Submit}>
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="#">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export async function pageLogin(ctx) {
    ctx.render(templateLogin(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let email = form.get('email');
        let password = form.get('password');
        try {
            if (email == '' || password == '') { throw new Error('All fields are required!'); }
            await login(email, password);
            ctx.setNavigation();
            ctx.page.redirect('/dashboard');
        }
        catch (error) { Notify(error.message); }
    }
}