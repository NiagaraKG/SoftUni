import { showHome } from './home.js';
let main;
let section;

async function Submit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');
    let repass = formData.get('repeatPassword');
    if(email == '' || password == '' || repass == '') {return alert('All fields are required!');}
    else if(password.length < 6) {return alert('Password must be at least 6 characters long!');}
    else if(password != repass) {return alert("Passwords don't match!");}
    let url = `http://localhost:3030/users/register`;
    let response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });
    if (response.ok) {
        event.target.reset();
        let data = await response.json();
        sessionStorage.setItem('authToken', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('email', data.email);
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;
        [...document.querySelectorAll('.user')].forEach(l => l.style.display = 'block');
        [...document.querySelectorAll('.guest')].forEach(l => l.style.display = 'none');
        showHome();
    }
    else {
        let error = await response.json();
        alert(error.message);
    }
}

export function setupRegister(mainTarget, sectionTarget){
    main = mainTarget;
    section = sectionTarget;
    let form = section.querySelector('form');
    form.addEventListener('submit', Submit);
}

export async function showRegister(){
    main.innerHTML = '';
    main.appendChild(section);
}