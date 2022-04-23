async function lockedProfile() {
    let main = document.getElementById('main');
    let url = `http://localhost:3030/jsonstore/advanced/profiles`;
    let response = await fetch(url);
    let data = await response.json();
    for (const key in data) {
        let id = key;
        let name = data[key].username;
        let email = data[key].email;
        let age = data[key].age;

        let profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');

        let image = document.createElement('img');
        image.setAttribute('src', `./iconProfile2.png`);
        image.classList.add('userIcon');
        
        let lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';
        let radioLock = document.createElement('input');
        radioLock.setAttribute('type', 'radio');
        radioLock.setAttribute('name', `user${id}Locked`);
        radioLock.setAttribute('value', 'lock');
        radioLock.setAttribute('checked', 'true');

        let unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';
        let radioUnlock = document.createElement('input');
        radioUnlock.setAttribute('type', 'radio');
        radioUnlock.setAttribute('name', `user${id}Locked`);
        radioUnlock.setAttribute('value', 'lock');
        
        let br = document.createElement('br');
        let hr1 = document.createElement('hr');

        let usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';
        let usernameInput = document.createElement('input');
        usernameInput.setAttribute('type', 'text');
        usernameInput.setAttribute('name', `user${id}Username`);
        usernameInput.setAttribute('value', name);
        usernameInput.setAttribute('disabled', 'true');
        usernameInput.setAttribute('readonly', 'true');

        let hiddenDiv = document.createElement('div');
        hiddenDiv.setAttribute('id', `user${id}HiddenFields`);
        hiddenDiv.style.display = 'none';

        let hr2 = document.createElement('hr');

        let emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';
        let emailInput = document.createElement('input');
        emailInput.setAttribute('type', 'email');
        emailInput.setAttribute('name', `user${id}Email`);
        emailInput.setAttribute('value', email);
        emailInput.setAttribute('disabled', 'true');
        emailInput.setAttribute('readonly', 'true');

        let ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';
        let ageInput = document.createElement('input');
        ageInput.setAttribute('type', 'email');
        ageInput.setAttribute('name', `user${id}Age`);
        ageInput.setAttribute('value', age);
        ageInput.setAttribute('disabled', 'true');
        ageInput.setAttribute('readonly', 'true');

        let button = document.createElement('button');
        button.textContent = 'Show more';

        hiddenDiv.appendChild(hr2);
        hiddenDiv.appendChild(emailLabel);
        hiddenDiv.appendChild(emailInput);
        hiddenDiv.appendChild(ageLabel);
        hiddenDiv.appendChild(ageInput);

        profileDiv.appendChild(image);
        profileDiv.appendChild(lockLabel);
        profileDiv.appendChild(radioLock);
        profileDiv.appendChild(unlockLabel);
        profileDiv.appendChild(radioUnlock);
        profileDiv.appendChild(br);
        profileDiv.appendChild(hr1);
        profileDiv.appendChild(usernameLabel);
        profileDiv.appendChild(usernameInput);
        profileDiv.appendChild(hiddenDiv);
        profileDiv.appendChild(button);

        main.appendChild(profileDiv);
    }
    

    
    let buttons = document.querySelectorAll('button');
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', onClick);
    }
    function onClick(e) {        
        if (e.currentTarget.textContent == 'Show more') {            
            if (!e.currentTarget.parentElement.children[2].checked) {
                e.currentTarget.textContent = 'Hide it';
                e.currentTarget.previousElementSibling.style.display = 'block';
            }
        }
        else {
            if (!e.currentTarget.parentElement.children[2].checked) {
                e.currentTarget.textContent = 'Show more';
                e.currentTarget.previousElementSibling.style.display = 'none';
            }
        }
    }
    
}