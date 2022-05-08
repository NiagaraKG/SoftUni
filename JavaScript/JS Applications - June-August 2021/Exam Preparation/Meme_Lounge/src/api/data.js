import * as api from './api.js';

let host = 'http://localhost:3030';
api.settings.host = host;

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAll() {
    return await api.Get(`${host}/data/memes?sortBy=_createdOn%20desc`);
}

export async function getById(id) {
    return await api.Get(`${host}/data/memes/${id}`);
}

export async function getMine() {
    let userId = sessionStorage.getItem('userId');
    return await api.Get(`${host}/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function Create(item) {
    return await api.Post(`${host}/data/memes`, item);
}

export async function Edit(id, item) {
    return await api.Put(`${host}/data/memes/${id}`, item);
}

export async function DeleteById(id) {
    return await api.Delete(`${host}/data/memes/${id}`);
}