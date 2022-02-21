function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searched = document.getElementById('searchField').value;
      let rows = Array.from(document.querySelectorAll('tbody tr'));
      for (let i = 0; i < rows.length; i++) {
         rows[i].className = '';
      }
      let filtered = rows.filter(x=>{
         let cells = Array.from(x.children);
         if(cells.some(x=>x.textContent.includes(searched)))
         {x.className = 'select';}
      });
      searched = '';
   }
}