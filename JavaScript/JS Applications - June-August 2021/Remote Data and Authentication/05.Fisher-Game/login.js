let registerForm = document.getElementById('register-form');
registerForm.addEventListener('submit', Register);
let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit', Login);
let buttonLogin = document.querySelector('#guest [href="login.html"]');
buttonLogin.disabled = true;

async function Register(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let password = formData.get('password');
    let repeatPass = formData.get('rePass');
    let email = formData.get('email');
    if (email == '' || password == '') { return alert('All fields are required!'); }
    if (password !== repeatPass) { return alert("Passwords don't match"); }
    let user = {
        email: email,
        password: password
    }
    let response = await fetch('http://localhost:3030/users/register',
        {
            method: 'Post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        return;
    }
    let data = await response.json();
    sessionStorage.setItem('userToken', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    location.assign('./index.html');
}

async function Login(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let password = formData.get('password');
    let email = formData.get('email');
    if (email == '' || password == '') { return alert('All fields are required!'); }
    let user = {
        email: email,
        password: password
    }
    let response = await fetch('http://localhost:3030/users/login',
        {
            method: 'Post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }
    let data = await response.json();
    sessionStorage.setItem('userToken', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    location.assign('./index.html');
}