export let settings = { host: '' };

async function request(url, options) {
    try {
        let response = await fetch(url, options);
        if (!response.ok) {
            let err = await response.json();
            throw new Error(err.message);
        }
        try {
            let data = await response.json();
            return data;
        }
        catch (error) { return response; }
    }
    catch (error) { alert(error.message); throw error; }
}

function getOptions(method = 'get', body) {
    let options = {
        method,
        headers: {}
    };
    let token = sessionStorage.getItem('authToken');
    if (token != null) { options.headers['X-Authorization'] = token; }
    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }
    return options;
}

export async function Get(url) { return await request(url, getOptions()); }

export async function Post(url, data) { return await request(url, getOptions('post', data)); }

export async function Put(url, data) { return await request(url, getOptions('put', data)); }

export async function Delete(url) { return await request(url, getOptions('delete')); }

export async function login(email, password) {
    let result = await Post(`${settings.host}/users/login`, { email, password });
    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    return result;
}

export async function register(email, password) {
    let result = await Post(`${settings.host}/users/register`, { email, password });
    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    return result;
}

export async function Logout() {
    let result = await Get(`${settings.host}/users/logout`);
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    return result;
}