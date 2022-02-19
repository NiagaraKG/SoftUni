function solve() {
  let text = document.getElementById("text").value;
  let Case = document.getElementById("naming-convention").value;
  text = text.toLowerCase();
  Case = Case.toLowerCase();
  let result = '';
  if (Case != 'camel case' && Case != 'pascal case') { result = 'Error!'; }
  else {
    let words = text.split(' ');
    for (let i = 0; i < words.length; i++) {
      words[i] = words[i][0].toUpperCase() + words[i].slice(1);
    }
    if (Case === 'camel case') {  words[0] = words[0][0].toLowerCase() + words[0].slice(1); }
    result = words.join('');
  }
  document.getElementById('result').textContent = result;
}