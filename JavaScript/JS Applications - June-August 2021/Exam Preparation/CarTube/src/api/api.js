import { getUser, setUser, clearUser } from '../utility.js';

export let settings = {
    host: ''
};

async function Request(URl, options) {
    try {
        let response = await fetch(URl, options);
        if (!response.ok) {
            let error = await response.json();
            throw new Error(error.message);
        }
        try { let data = await response.json(); return data; }
        catch (err) { return response; }
    }
    catch (err) { alert(err.message); throw err; }
}

function createOptions(method = 'get', body) {
    let options = { method, headers: {} };
    let user = getUser();
    if (user) { options.headers['X-Authorization'] = user.accessToken; }
    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }
    return options;
}

export async function Get(URL) { return await Request(URL, createOptions()); }
export async function Post(URL, data) { return await Request(URL, createOptions('post', data)); }
export async function Put(URL, data) { return await Request(URL, createOptions('put', data)); }
export async function Delete(URL) { return await Request(URL, createOptions('delete')); }

export async function login(username, password) { 
    let result = await Post(`${settings.host}/users/login`, {username, password}); 
    setUser(result);
    return result;
}

export async function register(username, password) { 
    let result = await Post(`${settings.host}/users/register`, {username, password}); 
    setUser(result);
    return result;
}

export function logout() { 
    let result = Get(`${settings.host}/users/logout`); 
    clearUser();
    return result;
}