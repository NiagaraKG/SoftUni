function validate() {
    let emailElement = document.getElementById('email');
    emailElement.addEventListener('change', onChange);
    function onChange(e) {
        let mailValue = e.target.value;
        let pattern = new RegExp('[a-z]+@[a-z]+\.[a-z]+');
        if (!pattern.test(mailValue)) {
            e.target.classList.add('error');
        }
        else {
            e.target.classList.remove('error');
        }
    }
}