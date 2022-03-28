import { showHome } from "./home.js";
let main;
let section;

export function setupCreate(mainTarget, sectionTarget){
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
    let url = `http://localhost:3030/data/movies`;
    let response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify(movie)
    });
    if(response.ok){
        let movie = await response.json();
        showHome();
    }
    else{
        let error = await response.json();
        alert(error.message);
    }
}

export async function showCreate(){
    main.innerHTML = '';
    main.appendChild(section);
}