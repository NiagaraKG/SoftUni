let buttonPost = document.getElementsByClassName('public')[0];
buttonPost.addEventListener('click', Post);
let buttonCancel = document.getElementsByClassName('cancel')[0];
buttonCancel.addEventListener('click', Cancel);
let main = document.querySelector('main');
LoadPosts();

function Cancel(e) {
    e.preventDefault();
    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';
}

async function Post(e) {
    e.preventDefault();
    let title = document.getElementById('topicName').value;
    let username = document.getElementById('username').value;
    let post = document.getElementById('postText').value;
    if (title == '' || username == '' || post == '') { alert('All fields are required!'); }
    else {
        document.getElementById('topicName').value = '';
        document.getElementById('username').value = '';
        document.getElementById('postText').value = '';
        let url = `http://localhost:3030/jsonstore/collections/myboard/posts`;
        let topic = {
            title: title,
            author: username,
            content: post,
            date: new Date().toLocaleString()
        };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(topic)
        });
        LoadPosts();
    }
}

async function LoadPosts() {
    let url = `http://localhost:3030/jsonstore/collections/myboard/posts`;
    let response = await fetch(url);
    let data = await response.json();
    main.querySelectorAll('.topic-name-wrapper').forEach(e=>e.remove());
    for (const key in data) { main.appendChild(createTopicElement(data[key])); }
}

function createTopicElement(topic) {
    let wrapper = document.createElement('div');
    wrapper.classList.add('topic-name-wrapper');
    wrapper.setAttribute('id', topic._id);
    let titleDiv = document.createElement('div');
    titleDiv.classList.add('topic-name');
    let h2 = document.createElement('h2');
    h2.textContent = topic.title;
    let contentDiv = document.createElement('div');

    let pDate = document.createElement('p');
    pDate.textContent = 'Date: ';
    let timeElement = document.createElement('time');
    timeElement.textContent = topic.date;
    pDate.appendChild(timeElement);
    let pUsername = document.createElement('p');
    pUsername.textContent = `Username: `;
    let span = document.createElement('span');
    span.textContent = topic.author;

    pUsername.appendChild(span);
    contentDiv.appendChild(pDate);
    contentDiv.appendChild(pUsername);
    titleDiv.appendChild(h2);
    titleDiv.appendChild(contentDiv);
    wrapper.appendChild(titleDiv);

    wrapper.addEventListener('click', OpenTopic);

    return wrapper;
}

function OpenTopic(e) {
    let id = e.currentTarget.id;
    localStorage.setItem('topicID', id);
    location.assign('theme-content.html');
}