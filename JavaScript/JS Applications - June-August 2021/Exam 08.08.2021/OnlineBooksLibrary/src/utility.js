export function getUser() {
    let user = sessionStorage.getItem('user');
    if (user) { return JSON.parse(user); }
    else { return undefined; }
}

export function setUser(user) {
    sessionStorage.setItem('user', JSON.stringify(user));
}

export function clearUser() { sessionStorage.removeItem('user'); }