import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/data.js";
import { Notify } from "../notification.js";

let templateRegister = (Submit) => html`
<section id="register">
    <form id="register-form" @submit=${Submit}>
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="#">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export async function pageRegister(ctx) {
    ctx.render(templateRegister(Submit));

    async function Submit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let username = form.get('username');
        let email = form.get('email');
        let password = form.get('password');
        let repeatPass = form.get('repeatPass');
        let gender = form.get('gender');
        try {
            if (username == '' || email == '' || password == '' || repeatPass == '' || !gender) {
                throw new Error('All fields are required!');
            }
            if (repeatPass != password) { throw new Error('Passwords don\'t match!'); }
            await register(username, email, password, gender);
            ctx.setNavigation();
            ctx.page.redirect('/dashboard');
        }
        catch (error) { Notify(error.message); }
    }
}