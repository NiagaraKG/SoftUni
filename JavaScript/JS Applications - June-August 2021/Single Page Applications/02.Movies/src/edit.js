import { showDetails } from "./details.js";
let main;
let section;
let movieId;

export function setupEdit(mainTarget, sectionTarget){
    main = mainTarget;
    section = sectionTarget;
    let form = section.querySelector('form');
    form.addEventListener('submit', Submit);
}

async function Submit(event){
    event.preventDefault();
    let formData = new FormData(event.target);
    let movie = {
        title: formData.get('title'),
        description: formData.get('description'),
        img: formData.get('imageUrl'),
    };
    if(movie.title == '' || movie.description == '' || movie.img == ''){
        return alert('All fields are required!');
    }
    let url = `http://localhost:3030/data/movies/${movieId}`;
    let response = await fetch(url, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify(movie)
    });
    if(response.ok){
        let movie = await response.json();
        showDetails(movie._id);
    }
    else{
        let error = await response.json();
        alert(error.message);
    }
}

export async function showEdit(movie){
    main.innerHTML = '';
    main.appendChild(section);
    document.querySelector('input[name="title"]').value = movie.title;
    document.querySelector('textarea[name="description"]').value = movie.description;
    document.querySelector('input[name="imageUrl"]').value = movie.img;
    movieId = movie._id;

}