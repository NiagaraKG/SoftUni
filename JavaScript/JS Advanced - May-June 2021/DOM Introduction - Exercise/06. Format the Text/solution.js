function solve() {
  let text = document.getElementById('input').value;
  let sentences = text.split('.').filter(x=>x!=='');
  for (let i = 0; i < sentences.length; i++) { sentences[i] += '.'; }
  let result = document.getElementById('output');
  for (let i = 0; i < sentences.length; i += 3) {
    let p = [];
    p.push(sentences[i]);
    if (i + 1 < sentences.length) { p.push(sentences[i + 1]); }
    if (i + 2 < sentences.length) { p.push(sentences[i + 2]); }
    result.innerHTML += `<p>${p.join('')}</p>`;
  }
}