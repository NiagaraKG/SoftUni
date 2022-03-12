function solve() {
  let buttonGenerate = document.getElementsByTagName('button')[0];
  let buttonBuy = document.getElementsByTagName('button')[1];
  buttonGenerate.addEventListener('click', Generate);
  buttonBuy.addEventListener('click', Buy);

  function Generate() {
    let input = document.getElementsByTagName('textarea')[0].value;
    let arr = JSON.parse(input);
    let table = document.querySelector('.table tbody');
    for (let i = 0; i < arr.length; i++) {
      let tr = document.createElement('tr');
      let imageTd = document.createElement('td');
      let nameTd = document.createElement('td');
      let priceTd = document.createElement('td');
      let decorationFactorTd = document.createElement('td');
      let markTd = document.createElement('td');
      imageTd.innerHTML = '<img src="' + arr[i].img + '"/>';
      nameTd.textContent = `${arr[i].name}`;
      priceTd.textContent = `${arr[i].price}`;
      decorationFactorTd.textContent = `${arr[i].decFactor}`;;
      markTd.innerHTML = '<input type="checkbox" />';
      tr.appendChild(imageTd);
      tr.appendChild(nameTd);
      tr.appendChild(priceTd);
      tr.appendChild(decorationFactorTd);
      tr.appendChild(markTd);
      table.appendChild(tr);
    }
  }

  function Buy() {
    let totalPrice = 0;
    let avDecorationFactor = 0;
    let names = [];
    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]'));
    for (let i = 0; i < checkboxes.length; i++) {
      let cols = checkboxes[i].parentElement.parentElement.getElementsByTagName('td');
      if (checkboxes[i].checked === true) {
        names.push(cols[1].textContent);
        totalPrice += Number(cols[2].textContent);
        avDecorationFactor += Number(cols[3].textContent);
      }
    }
    avDecorationFactor /= names.length;
    let result = 'Bought furniture: ' + names.join(', ') + `\nTotal price: ${totalPrice.toFixed(2)}\n`;
    result += `Average decoration factor: ${avDecorationFactor}`;
    document.getElementsByTagName('textarea')[1].textContent = result;
  }

}