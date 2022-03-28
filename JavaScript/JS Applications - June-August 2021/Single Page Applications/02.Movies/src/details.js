import {showHome} from './home.js';
import { showEdit } from "./edit.js";
let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showDetails(id) {
    section.innerHTML = '';
    main.innerHTML = '';
    main.appendChild(section);
    let [movie, likes, ownLike] = await Promise.all([
        getMovieById(id),
        getLikesByMovieId(id),
        getOwnLikesByMovieId(id)
    ]);
    let card = createMovieCard(movie, likes, ownLike);
    section.appendChild(card);
}

async function getMovieById(id) {
    let url = `http://localhost:3030/data/movies/${id}`;
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

function createMovieCard(movie, likes, ownLike) {
    let userId = sessionStorage.getItem('userId');

    let movieDiv = document.createElement('div');
    movieDiv.setAttribute('class', 'container');
    let rowDiv = document.createElement('div');
    rowDiv.setAttribute('class', 'row bg-light text-dark');
    let h1 = document.createElement('h1');
    h1.textContent = `Movie title: ${movie.title}`;
    let col8Div = document.createElement('div');
    col8Div.setAttribute('class', 'col-md-8');
    let img = document.createElement('img');
    img.setAttribute('class', 'img-thumbnail');
    img.src = `${movie.img}`;
    let col4Div = document.createElement('div');
    col4Div.setAttribute('class', 'col-md-4 text-center');
    let h3 = document.createElement('h3');
    h3.setAttribute('class', 'my-3 ');
    h3.textContent = 'Movie Description';
    let p = document.createElement('p');
    p.textContent = `${movie.description}`;
    let aDelete = document.createElement('a');
    aDelete.setAttribute('class', 'btn btn-danger');
    aDelete.href = '#';
    aDelete.textContent = 'Delete';
    let aEdit = document.createElement('a');
    aEdit.setAttribute('class', 'btn btn-warning');
    aEdit.href = '#';
    aEdit.textContent = 'Edit';
    let aLike = document.createElement('a');
    aLike.setAttribute('class', 'btn btn-primary');
    aLike.href = '#';
    aLike.textContent = 'Like';
    let span = document.createElement('span');
    span.setAttribute('class', 'enrolled-span');
    span.textContent = `Like`;
    if (ownLike.length > 0) { span.textContent += 'd' }
    span.textContent += ` ${likes}`;
    aLike.addEventListener('click', Like);
    aDelete.addEventListener('click', (e)=>Delete(e, movie._id));
    aEdit.addEventListener('click', (e)=>showEdit(movie));

    col4Div.appendChild(h3);
    col4Div.appendChild(p);
    if (userId != null) {
        if (userId == movie._ownerId) {
            col4Div.appendChild(aDelete);
            col4Div.appendChild(aEdit);
        }
        else if (ownLike.length == 0) { col4Div.appendChild(aLike); }
    }
    col4Div.appendChild(span);
    col8Div.appendChild(img);
    rowDiv.appendChild(h1);
    rowDiv.appendChild(col8Div);
    rowDiv.appendChild(col4Div);
    movieDiv.appendChild(rowDiv);
    return movieDiv;

    async function Like(event) {
        let url = `http://localhost:3030/data/likes`;
        let response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': sessionStorage.getItem('authToken')
            },
            body: JSON.stringify({ movieId: movie._id })
        });
        if (response.ok) {
            event.target.remove();
            likes++;
            span.textContent = `Like`;
            span.textContent += 'd';
            span.textContent += ` ${likes}`;
        }
    }
}

async function getLikesByMovieId(id) {
    let url = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`;
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

async function getOwnLikesByMovieId(id) {
    let userId = sessionStorage.getItem('userId');
    let url = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`;
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

async function Delete(event, id) {
    event.preventDefault();
    let confirmed = confirm('Are you sure you want to delete this movie?');
    if (confirmed) {
        let url = `http://localhost:3030/data/movies/${id}`;
        let response = await fetch(url, {
            method: 'delete',
            headers: { 'X-Authorization': sessionStorage.getItem('authToken') }
        });
        if(response.ok){
            alert('Movie deleted');
            showHome();
        }
        else{
            let error = await response.json();
            alert(error.message);
        }
    }
}