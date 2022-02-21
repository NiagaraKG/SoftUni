function search() {
   let searchText = document.getElementById('searchText').value;
   let towns = Array.from(document.querySelectorAll('#towns li'));
   for (let i = 0; i < towns.length; i++) {
      towns[i].style.fontWeight = 'normal';
      towns[i].style.textDecoration = 'none';
   }   
   let found = towns.filter(x=>x.textContent.includes(searchText));
   for (let i = 0; i < found.length; i++) {
      found[i].style.fontWeight = 'bold';
      found[i].style.textDecoration = 'underline';
   }
   let result = document.getElementById('result');
   result.textContent = `${found.length} matches found`;
}
