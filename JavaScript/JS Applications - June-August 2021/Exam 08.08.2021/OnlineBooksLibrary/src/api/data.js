import * as api from './api.js';

let host = 'http://localhost:3030';
api.settings.host = host;

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAll() {
    return await api.Get(`${host}/data/books?sortBy=_createdOn%20desc`);
}

export async function getMine(userId) {
    return await api.Get(`${host}/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getById(id) {
    return await api.Get(`${host}/data/books/${id}`);
}

export async function Create(item) {
    return await api.Post(`${host}/data/books`, item);
}

export async function Edit(id, item) {
    return await api.Put(`${host}/data/books/${id}`, item);
}

export async function DeleteById(id) {
    return await api.Delete(`${host}/data/books/${id}`);
}

export async function getLikesByBookId(bookId) {
    return await api.Get(`${host}/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}

export async function getOwnLikesByBookId(bookId, userId) {
    return await api.Get(`${host}/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

export async function likeBook(item) {
    return await api.Post(`${host}/data/likes/`, item);
}