import { render } from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'
import  {logout} from './api/data.js';
import { getUser } from './utility.js';
import { pageLogin, pageRegister } from './views/auth.js';
import { pageCreate } from './views/create.js';
import { pageDashboard } from './views/dashboard.js';
import { pageDetails } from './views/details.js';
import { pageEdit } from './views/edit.js';
import { pageHome } from './views/home.js';
import { pageMine } from './views/mine.js';
import { pageSearch } from './views/search.js';


let mainContainer = document.getElementById('site-content');
document.getElementById('profile').lastElementChild.addEventListener('click', LogOut);
setNavigation()

page('/', middleware, pageHome);
page('/login', middleware, pageLogin);
page('/register', middleware, pageRegister);
page('/dashboard', middleware, pageDashboard);
page('/mine', middleware, pageMine);
page('/create', middleware, pageCreate);
page('/search', middleware, pageSearch);
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
        document.getElementById('profile').style.display = '';
        document.getElementById('guest').style.display = 'none';
        document.getElementById('profile').firstElementChild.textContent = `Welcome ${user.username}`;
    }
    else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}

function LogOut(){
    logout();
    setNavigation()
    page.redirect('/');
}