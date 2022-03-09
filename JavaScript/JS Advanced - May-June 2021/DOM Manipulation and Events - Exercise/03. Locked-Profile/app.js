function lockedProfile() {
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