import { render } from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'
import  {logout} from './api/data.js';
import { getUser } from './utility.js';
import { pageLogin, pageRegister } from './views/authentication.js';
import { pageCreate } from './views/create.js';
import { pageDashboard } from './views/dashboard.js';
import { pageDetails } from './views/details.js';
import { pageEdit } from './views/edit.js';
import { pageMine } from './views/mine.js';


let mainContainer = document.getElementById('site-content');
document.getElementById('user').lastElementChild.addEventListener('click', LogOut);
setNavigation()

page('/', middleware, pageDashboard);
page('/login', middleware, pageLogin);
page('/register', middleware, pageRegister);
page('/dashboard', middleware, pageDashboard);
page('/mine', middleware, pageMine);
page('/create', middleware, pageCreate);
page('/edit/:id', middleware, pageEdit);
page('/details/:id', middleware, pageDetails);

page.start();

function middleware(ctx, next) {
    ctx.render = (content) => render(content, mainContainer);
    ctx.setNavigation = setNavigation;
    ctx.user = getUser();
    next();
}

function setNavigation() {
    let user = getUser();
    if (user) {
        document.getElementById('user').style.display = '';
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').firstElementChild.textContent = `Welcome, ${user.email}`;
    }
    else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}

function LogOut(){
    logout();
    setNavigation()
    page.redirect('/');
}