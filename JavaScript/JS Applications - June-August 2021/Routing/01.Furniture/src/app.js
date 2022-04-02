import page from '../node_modules/page/page.mjs';
import { render } from "../node_modules/lit-html/lit-html.js";
import { logout } from "./api/data.js";
import { pageCreate } from './views/create.js';
import { pageDashboard } from './views/dashboard.js';
import { pageDetails } from './views/details.js';
import { pageEdit } from './views/edit.js';
import { pageLogin } from './views/login.js';
import { pageRegister } from './views/register.js';
import { pageMyFurniture } from './views/myFurniture.js';

let mainContainer = document.querySelector('.container');

page('/', middleware, pageDashboard);
page('/dashboard', middleware, pageDashboard);
page('/details/:id', middleware, pageDetails);
page('/create', middleware, pageCreate);
page('/edit/:id', middleware, pageEdit);
page('/register', middleware, pageRegister);
page('/login', middleware, pageLogin);
page('/my-furniture', middleware, pageMyFurniture);

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setNavigation();
    page.redirect('/');
});

setNavigation();
page.start();

function middleware(ctx, next) {
    ctx.render = (content) => render(content, mainContainer);
    ctx.setNavigation = setNavigation;
    next();
}

function setNavigation() {
    let userId = sessionStorage.getItem('userId');
    if (userId != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    }
    else {
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('user').style.display = 'none';
    }
}