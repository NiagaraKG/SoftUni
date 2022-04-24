async function solution() {
    let main = document.getElementById('main');
    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let response = await fetch(url);
    let data = await response.json();

    for (let i = 0; i < data.length; i++) {
        let id = data[i]._id;
        let title = data[i].title;
        let contentURL = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        let contentResponse = await fetch(contentURL);
        let contentObj = await contentResponse.json();
        let text = contentObj.content;

        let accordionDiv = document.createElement('div');
        accordionDiv.setAttribute('class', 'accordion');         
        let headDiv = document.createElement('div');
        headDiv.setAttribute('class', 'head');
        let titleSpan = document.createElement('span');
        titleSpan.textContent = title;
        let buttonMore = document.createElement('button');
        buttonMore.setAttribute('class', 'button');
        buttonMore.setAttribute('id', id);
        buttonMore.textContent = 'More';
        let extraDiv = document.createElement('div');
        extraDiv.setAttribute('class', 'extra');
        extraDiv.style.display = 'none';
        let p = document.createElement('p');
        p.textContent = text;

        extraDiv.appendChild(p);
        headDiv.appendChild(titleSpan);
        headDiv.appendChild(buttonMore);
        accordionDiv.appendChild(headDiv);
        accordionDiv.appendChild(extraDiv);
        main.appendChild(accordionDiv);

        buttonMore.addEventListener('click', onClick);
    }

    function onClick(e){
        let button = e.currentTarget;
        let text = button.parentElement.nextElementSibling;
        if (button.textContent === 'More') {
            button.textContent = 'Less';
            text.style.display = 'block';
        }
        else {
            button.textContent = 'More';
            text.style.display = 'none';
        }
    }  
}

solution();