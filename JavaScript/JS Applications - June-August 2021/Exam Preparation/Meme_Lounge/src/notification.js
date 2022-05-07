let errorBox = document.getElementById('errorBox');

export function Notify(message) {
    errorBox.innerHTML = `<span>${message}</span>`;
    errorBox.style.display = 'block';
    setTimeout(() => { errorBox.style.display = 'none'; }, 3000);
}