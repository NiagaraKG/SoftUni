import { showDetails } from './details.js';
let main;
let section;
let container;

export function setupHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    container = section.querySelector('.card-deck.d-flex.justify-content-center');
    container.addEventListener('click', event => {
        if (event.target.classList.contains('movieDetailsLink')) { showDetails(event.target.id); }
    });
}

export async function showHome() {
    container.innerHTML = '';
    main.innerHTML = '';
    main.appendChild(section);
    let buttonAddMovie = document.getElementById('createLink');
    if(document.querySelector('.user').style.display == 'none'){        
        buttonAddMovie.style.display = 'none';
    }
    else{buttonAddMovie.style.display = '';}
    let movies = await getMovies();
    let cards = movies.map(createMoviePreview);
    cards.forEach(c => container.appendChild(c));
}

async function getMovies() {
    let url = `http://localhost:3030/data/movies`;
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

function createMoviePreview(movie) {
    let movieDiv = document.createElement('div');
    movieDiv.setAttribute('class', 'card mb-4');
    let img = document.createElement('img');
    img.setAttribute('class', 'card-img-top');
    img.src = `${movie.img}`;
    img.alt = 'Card image cap';
    img.width = 400;
    let bodyDiv = document.createElement('div');
    bodyDiv.setAttribute('class', 'card-body');
    let h4 = document.createElement('h4');
    h4.setAttribute('class', 'card-title');
    h4.textContent = `${movie.title}`;
    let footerDiv = document.createElement('div');
    footerDiv.setAttribute('class', 'card-footer');
    footerDiv.innerHTML = `<button id="${movie._id}" type="button" class="btn-info movieDetailsLink">Details</button>`;
    bodyDiv.appendChild(h4);
    movieDiv.appendChild(img);
    movieDiv.appendChild(bodyDiv);
    movieDiv.appendChild(footerDiv);
    return movieDiv;
}