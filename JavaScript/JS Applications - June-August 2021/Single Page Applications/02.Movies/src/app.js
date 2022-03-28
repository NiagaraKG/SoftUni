import { setupHome, showHome } from './home.js';
import { setupDetails } from './details.js';
import { setupLogin, showLogin } from './login.js';
import { setupRegister, showRegister } from './register.js';
import { setupCreate, showCreate } from './create.js';
import { setupEdit } from './edit.js';

let main = document.querySelector('main');
let links = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister,
    'createLink': showCreate,
};

setupSection('home-page', setupHome);
setupSection('add-movie', setupCreate);
setupSection('movie-details', setupDetails);
setupSection('edit-movie', setupEdit);
setupSection('form-login', setupLogin);
setupSection('form-sign-up', setupRegister);
setupNavigation();

showHome();

function setupSection(sectionId, setup) {
    let section = document.getElementById(sectionId);
    setup(main, section);
}

function setupNavigation() {
    let email = sessionStorage.getItem('email');
    if (email != null) {
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;
        [...document.querySelectorAll('.user')].forEach(l => l.style.display = 'block');
        [...document.querySelectorAll('.guest')].forEach(l => l.style.display = 'none');
    }
    else {
        [...document.querySelectorAll('.user')].forEach(l => l.style.display = 'none');
        [...document.querySelectorAll('.guest')].forEach(l => l.style.display = 'block');
    }
    document.querySelector('nav').addEventListener('click', (event) => {
        let view = links[event.target.id];
        if (typeof view == 'function') { event.preventDefault(); view(); }
    });
    document.getElementById('createLink').addEventListener('click', (event) => {
        event.preventDefault(); showCreate();
    });
    document.getElementById('logoutBtn').addEventListener('click', Logout);
}

async function Logout() {
    let token = sessionStorage.getItem('authToken');
    let url = `http://localhost:3030/users/logout`;
    let response = await fetch(url, {
        method: 'get',
        headers: { 'X-Authorization': token }
    });
    if(response.ok){
        sessionStorage.removeItem('authToken');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('email');
        [...document.querySelectorAll('.user')].forEach(l => l.style.display = 'none');
        [...document.querySelectorAll('.guest')].forEach(l => l.style.display = 'block');
        showLogin();
    }
    else {
        let error = await response.json();
        alert(error.message);
    }
}