function solve() {
   let createButton = document.getElementsByClassName('btn create')[0];
   createButton.addEventListener('click', Create);

   function Create(e) {
      e.preventDefault();
      let author = document.getElementById('creator').value;
      let title = document.getElementById('title').value;
      let category = document.getElementById('category').value;
      let content = document.getElementById('content').value;
      let article = document.createElement('article');
      let titleElement = document.createElement('h1');
      titleElement.textContent = title;
      let categoryParagraph = document.createElement('p');
      categoryParagraph.innerHTML = `Category: <strong>${category}</strong>`;
      let creatorParagraph = document.createElement('p');
      creatorParagraph.innerHTML = `Creator: <strong>${author}</strong>`;
      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = content;
      let div = document.createElement('div');
      div.setAttribute('class', 'buttons');
      let deleteButton = document.createElement('button');
      deleteButton.setAttribute('class', 'btn delete');
      deleteButton.textContent = 'Delete';
      let archiveButton = document.createElement('button');
      archiveButton.setAttribute('class', 'btn archive');
      archiveButton.textContent = 'Archive';
      div.appendChild(deleteButton);
      div.appendChild(archiveButton);
      article.appendChild(titleElement);
      article.appendChild(categoryParagraph);
      article.appendChild(creatorParagraph);
      article.appendChild(contentParagraph);
      article.appendChild(div);
      let mainEl = document.querySelector('main>section');
      mainEl.appendChild(article);      
      deleteButton.addEventListener('click', Delete);
      archiveButton.addEventListener('click', Archive);
      document.getElementById('creator').value = '';
      document.getElementById('title').value = '';
      document.getElementById('category').value = '';
      document.getElementById('content').value = '';
   }
   function Archive(e) {
      let article = e.currentTarget.parentElement.parentElement;
      article.parentElement.removeChild(article);
      let title = article.children[0].textContent;
      let ol = document.getElementsByTagName('ol')[0];
      let li = document.createElement('li');
      li.textContent = title;
      ol.appendChild(li);
      Array.from(ol.querySelectorAll('li')).sort((a, b) =>
         a.textContent.localeCompare(b.textContent)).forEach(
            li => ol.appendChild(li));
   }
   function Delete(e){
      let article = e.currentTarget.parentElement.parentElement;
      article.parentElement.removeChild(article);
   }
}
