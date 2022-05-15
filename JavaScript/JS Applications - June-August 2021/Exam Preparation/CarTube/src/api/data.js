import * as api from './api.js';

let host = 'http://localhost:3030';
api.settings.host = host;

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAll(){
    return await api.Get(`${host}/data/cars?sortBy=_createdOn%20desc`);
}

export async function getMine(userId){
    return await api.Get(`${host}/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getById(id){
    return await api.Get(`${host}/data/cars/${id}`);
}

export async function Create(item){
    return await api.Post(`${host}/data/cars`, item);
}

export async function Edit(id, item){
    return await api.Put(`${host}/data/cars/${id}`, item);
}

export async function DeleteById(id){
    return await api.Delete(`${host}/data/cars/${id}`);
}

export async function Search(query){
    return await api.Get(`${host}/data/cars?where=year%3D${query}`);
}