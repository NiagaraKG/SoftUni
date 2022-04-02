import * as api from './api.js';

let host = 'http://localhost:3030';
api.settings.host = host;

export let login = api.login;
export let register = api.register;
export let logout = api.Logout;

export async function getFurniture() { return await api.Get(`${host}/data/catalog`); }

export async function getItem(id) { return await api.Get(`${host}/data/catalog/${id}`); }

export async function getMyFurniture() {
    let userId = sessionStorage.getItem('userId');
    return await api.Get(`${host}/data/catalog?where=_ownerId%3D%22${userId}%22`);
}

export async function Create(data) { return await api.Post(`${host}/data/catalog`, data); }

export async function Edit(id, data) { return await api.Put(`${host}/data/catalog/${id}`, data); }

export async function DeleteById(id) { return await api.Delete(`${host}/data/catalog/${id}`); }