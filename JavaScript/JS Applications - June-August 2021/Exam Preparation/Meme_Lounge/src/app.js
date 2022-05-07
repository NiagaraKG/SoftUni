import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { logout } from './api/data.js';
import { pageHome } from './views/home.js';
import { pageLogin } from './views/login.js';
import { pageRegister } from './views/register.js';
import { pageDashboard } from './views/dashboard.js';
import { pageCreate } from './views/create.js';
import { pageDetails } from './views/details.js';
import { pageEdit } from './views/edit.js';
import { pageProfile } from './views/profile.js';

let mainContainer = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('çlick', LogOut);

setNavigation();

page('/', middleware, pageHome);
page('/login', middleware, pageLogin);
page('/register', middleware, pageRegister);
page('/dashboard', middleware, pageDashboard);
page('/profile', middleware, pageProfile);
page('/create', middleware, pageCreate);
page('/details/:id', middleware, pageDetails);
page('/edit/:id', middleware, pageEdit);

page.start();

function middleware(ctx, next) {
    ctx.render = (content) => render(content, mainContainer);
    ctx.setNavigation = setNavigation;
    next();
}

function setNavigation() {
    let email = sessionStorage.getItem('email');
    if (email != null) {
        let nav = document.querySelector('.user');
        nav.style.display = '';
        nav.querySelector('span').textContent = `Welcome, ${email}`;
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.user').style.display = '';
    }
    else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = '';
    }
}

async function LogOut() {
    await logout();
    setNavigation();
    page.redirect('/');
}