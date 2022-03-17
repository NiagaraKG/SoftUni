function solve() {
    let buttonAdd = document.getElementById('add');
    buttonAdd.addEventListener('click', Add);

    function Add(e) {
        e.preventDefault();
        let task = document.getElementById('task').value;
        let description = document.getElementById('description').value;
        let date = document.getElementById('date').value;
        document.getElementById('task').value = '';
        document.getElementById('description').value = '';
        document.getElementById('date').value = '';
        if (task != '' && description != '' && date != '') {            
            let articleDiv = document.getElementsByClassName('orange')[0].parentElement.nextElementSibling;
            let article = document.createElement('article');
            let h3 = document.createElement('h3');
            h3.textContent = task;
            let pDescription = document.createElement('p');
            pDescription.textContent = `Description: ${description}`;
            let pDate = document.createElement('p');
            pDate.textContent = `Due Date: ${date}`;
            let flexDiv = document.createElement('div');
            flexDiv.setAttribute('class', 'flex');
            let startButton = document.createElement('button');
            startButton.setAttribute('class', 'green');
            startButton.textContent = 'Start';
            let deleteButton = document.createElement('button');
            deleteButton.setAttribute('class', 'red');
            deleteButton.textContent = 'Delete';
            flexDiv.appendChild(startButton);
            flexDiv.appendChild(deleteButton);
            article.appendChild(h3);
            article.appendChild(pDescription);
            article.appendChild(pDate);
            article.appendChild(flexDiv);
            articleDiv.appendChild(article);
            startButton.addEventListener('click', Start);
            deleteButton.addEventListener('click', Delete);            
        }
    }
    function Start(e){
        let articleDiv = document.getElementsByClassName('yellow')[0].parentElement.nextElementSibling;
        let article = e.currentTarget.parentElement.parentElement;        
        article.parentElement.removeChild(article);               
        let flexDiv = article.lastElementChild;        
        e.currentTarget.parentElement.removeChild(e.currentTarget);       
        let finishButton = document.createElement('button');
        finishButton.setAttribute('class', 'orange');
        finishButton.textContent = 'Finish';
        flexDiv.appendChild(finishButton);  
        articleDiv.appendChild(article);  
        finishButton.addEventListener('click', Finish);    
    }
    function Delete(e){
        let article = e.currentTarget.parentElement.parentElement;        
        article.parentElement.removeChild(article);
    }
    function Finish(e){
        let articleDiv = document.getElementsByClassName('green')[0].parentElement.nextElementSibling;
        let article = e.currentTarget.parentElement.parentElement;        
        article.parentElement.removeChild(article);               
        article.removeChild(article.lastElementChild);               
        articleDiv.appendChild(article);  
    }
}