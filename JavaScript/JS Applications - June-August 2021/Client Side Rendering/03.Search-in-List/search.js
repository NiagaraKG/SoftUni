import { html, render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";

let main = document.body;

let townsTemplate = (towns, match) => html`
<article>
   <div id="towns">
      <ul>
         ${towns.map(t => townTemplate(t, match))}
      </ul>
   </div>
   <input type="text" id="searchText" />
   <button @click=${search}>Search</button>
   <div id="result">${Count(towns, match)}</div>
</article>`;

let townTemplate = (name, match) => html
   `<li class=${(match && name.toLowerCase().includes(match.toLowerCase())) ? 'active'  : ''}>${name}</li>`;

Update();

function Update(match = '') {
   let result = townsTemplate(towns, match);
   render(result, main);
}

function Count(towns, match){
   let count = towns.filter(t=>match && t.toLowerCase().includes(match.toLowerCase())).length;
   if(count == 1){ return '1 match found'; }
   else if(count > 1) {return `${count} matches found`;}
   else {return '';}
}

function search() {
   let match = document.getElementById('searchText').value;
   Update(match);

}
