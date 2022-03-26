let topicID = localStorage.getItem('topicID');
OpenTopic();
let home = document.querySelector('li');
home.addEventListener('click', GoHome);

async function OpenTopic() {
    let mainDiv = document.querySelector('.comment');
    let topicTitle = document.querySelector('h2');
    let topicURL = `http://localhost:3030/jsonstore/collections/myboard/posts/${topicID}`;
    let topicResponse = await fetch(topicURL);
    let topicData = await topicResponse.json();
    topicTitle.textContent = topicData.title;
    let headerDiv = document.createElement('div');
    headerDiv.setAttribute('class', 'header');
    let img = document.createElement('img');
    img.src = './static/profile.png';
    img.alt = 'avatar';
    let p1 = document.createElement('p');
    p1.innerHTML = `<span>${topicData.author} posted on <time>${topicData.date}</time>`;
    let p2 = document.createElement('p');
    p2.setAttribute('class', 'post-content');
    p2.textContent = topicData.content;
    let commentDiv = document.createElement('div');
    commentDiv.setAttribute('id', 'user-comment');

    headerDiv.appendChild(img);
    headerDiv.appendChild(p1);
    headerDiv.appendChild(p2);
    mainDiv.appendChild(headerDiv);
    mainDiv.appendChild(commentDiv);

    let buttonPost = document.querySelector('button');
    buttonPost.addEventListener('click', CommentTopic);
    LoadComments();
}

async function CommentTopic() {
    let username = document.getElementById('username').value;
    let comment = document.getElementById('comment').value;
    if (username == '' || comment == '') { alert('All fields are required!'); }
    else {
        document.getElementById('username').value = '';
        document.getElementById('comment').value = '';
        let url = `http://localhost:3030/jsonstore/collections/myboard/comments`;
        let commentObj = {
            topicID: topicID,
            author: username,
            content: comment,
            date: new Date().toLocaleString()
        };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(commentObj)
        });
        LoadComments();
    }
}

async function LoadComments() {
    let url = `http://localhost:3030/jsonstore/collections/myboard/comments`;
    let response = await fetch(url);
    let data = await response.json();
    let commentDiv = document.getElementById('user-comment');
    for (const key in data) {
        if (data[key].topicID == topicID) { commentDiv.appendChild(createCommentElement(data[key])); }
    }
}

function createCommentElement(comment) {
    let wrapper = document.createElement('div');
    wrapper.setAttribute('class', 'topic-name-wrapper');
    let title = document.createElement('div');
    title.setAttribute('class', 'topic-name');
    let p1 = document.createElement('p');
    p1.innerHTML = `<strong>${comment.author}</strong> commented on <time>${comment.date}</time>`;
    let content = document.createElement('div');
    content.setAttribute('class', 'post-content');
    let p2 = document.createElement('p');
    p2.textContent = comment.content;
    content.appendChild(p2);
    title.appendChild(p1);
    title.appendChild(content);
    wrapper.appendChild(title);
    return wrapper;
}

function GoHome() { location.assign('index.html'); };