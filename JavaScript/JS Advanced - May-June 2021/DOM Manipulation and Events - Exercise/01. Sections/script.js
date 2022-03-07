function create(words) {
   function displayParagraph(event) {      
      event.currentTarget.firstElementChild.style.display = '';
   }

   for (let i = 0; i < words.length; i++) {
      let currDiv = document.createElement('div');
      let currParagraph = document.createElement('p');
      currParagraph.textContent = words[i];
      currParagraph.style.display = 'none';
      currDiv.appendChild(currParagraph);
      currDiv.addEventListener('click', displayParagraph)
      let contentElement = document.getElementById('content');
      contentElement.appendChild(currDiv);
   }
}