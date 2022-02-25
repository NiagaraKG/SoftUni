function getArticleGenerator(articles) {
    let div = document.getElementById('content');
    let index = 0;
    return function showNext(){
        if(index<articles.length)
        {
            let newArticle = document.createElement('article');
            newArticle.textContent = articles[index];
            div.appendChild(newArticle);
            index ++;
        }
    }   
}
