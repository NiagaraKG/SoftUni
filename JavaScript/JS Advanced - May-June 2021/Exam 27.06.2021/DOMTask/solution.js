window.addEventListener('load', solution);

function solution() {
  let submitButton = document.getElementById('submitBTN');
  submitButton.addEventListener('click', Submit)
  let name, email, phone, address, code;

  function Submit(e) {
     name = document.getElementById('fname').value;
     email = document.getElementById('email').value;
     phone = document.getElementById('phone').value;
     address = document.getElementById('address').value;
     code = document.getElementById('code').value;

    document.getElementById('fname').value = '';
    document.getElementById('email').value = '';
    document.getElementById('phone').value = '';
    document.getElementById('address').value = '';
    document.getElementById('code').value = '';

    if (name != '' && email != '') {
      let submitButton = document.getElementById('submitBTN');
      submitButton.disabled = true;

      let ul = document.getElementById('infoPreview');
      let nameLi = document.createElement('li');
      nameLi.textContent = `Full Name: ${name}`;
      let emailLi = document.createElement('li');
      emailLi.textContent = `Email: ${email}`;
      let phoneLi = document.createElement('li');
      phoneLi.textContent = `Phone Number: ${phone}`;
      let addressLi = document.createElement('li');
      addressLi.textContent = `Address: ${address}`;
      let codeLi = document.createElement('li');
      codeLi.textContent = `Postal Code: ${code}`;
      ul.appendChild(nameLi);
      ul.appendChild(emailLi);
      ul.appendChild(phoneLi);
      ul.appendChild(addressLi);
      ul.appendChild(codeLi);

      let editButton = document.getElementById('editBTN');
      editButton.disabled = false;
      let continueButton = document.getElementById('continueBTN');
      continueButton.disabled = false;
      editButton.addEventListener('click', Edit);
      continueButton.addEventListener('click', Continue);
    }
  }

  function Edit(e){
    let submitButton = document.getElementById('submitBTN');
      submitButton.disabled = false;
      let editButton = document.getElementById('editBTN');
      editButton.disabled = true;
      let continueButton = document.getElementById('continueBTN');
      continueButton.disabled = true;
      document.getElementById('fname').value = name;
     document.getElementById('email').value = email;
     document.getElementById('phone').value = phone;
     document.getElementById('address').value = address;
     document.getElementById('code').value = code;
     let ul = document.getElementById('infoPreview');
     ul.innerHTML = '';
  }

  function Continue(e){
    let block = document.getElementById('block');
    block.innerHTML = '';
    let h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';
    block.appendChild(h3);
  }
}
