function attachEvents() {
    let buttonLoadPosts = document.getElementById('btnLoadPosts');
    buttonLoadPosts.addEventListener('click', getPosts);
    let buttonViewPost = document.getElementById('btnViewPost');
    buttonViewPost.addEventListener('click', displayPost);
}

attachEvents();

async function getPosts() {
    let url = 'http://localhost:3030/jsonstore/blog/posts';
    let response = await fetch(url);
    let returnedData = await response.json();    
    let select = document.getElementById('posts');
    select.innerHTML = '';
    Object.values(returnedData).map(createOptions).forEach(o => select.appendChild(o));
}

function createOptions(post){
    let option = document.createElement('option');
    option.value = post.id;
    option.textContent = post.title;
    return option;
}

function displayPost(){
    let postID = document.getElementById('posts').value;
    getComments(postID);
}

async function getComments(ID) {
    document.getElementById('post-comments').innerHTML='';
    let postURL = `http://localhost:3030/jsonstore/blog/posts/${ID}`;
    let postResponse = await fetch(postURL);
    let postData = await postResponse.json();
    let title = document.getElementById('post-title');
    title.textContent = postData.title;
    let body = document.getElementById('post-body');
    body.textContent = postData.body;
    let commentsURL = 'http://localhost:3030/jsonstore/blog/comments';
    let commentsResponse = await fetch(commentsURL);
    let commentsData = await commentsResponse.json();
    let comments = Object.values(commentsData).filter(c=> c.postId == ID);    
    let commentsUL = document.getElementById('post-comments');
    comments.map(createComment).forEach(c=> commentsUL.appendChild(c));
}

function createComment(comment){
    let li = document.createElement('li');
    li.textContent = comment.text;
    li.id = comment.id;
    return li;
}