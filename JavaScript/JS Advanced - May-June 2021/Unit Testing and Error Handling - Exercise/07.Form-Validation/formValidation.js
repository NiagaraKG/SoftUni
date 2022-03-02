function validate() {
    document.querySelector("#submit").type = "button";
    let submitButton = document.getElementById('submit');
    let companyCheckbox = document.getElementById("company");
    submitButton.addEventListener('click', onFormSubmission);
    companyCheckbox.addEventListener('change', onCheckboxChange);
    isValid = true;

    function onFormSubmission(event) {
        let username = document.getElementById('username').value;
        let password = document.getElementById('password').value;
        let confirmPass = document.getElementById('confirm-password').value;
        let email = document.getElementById('email').value;
        let companyNum = document.getElementById('companyNumber').value;

        isValid = true;
        validateUsername(username);
        validatePasswords(password, confirmPass);
        validateEmail(email);
        validateCompany(Number(companyNum));

        if (isValid == true) {
            document.getElementById('valid').style.display = 'block';
        }
        else {
            document.getElementById('valid').style.display = 'none';
        }
    }

    function validateCompany(value) {
        if (companyCheckbox.checked == true) {
            if (Number.isInteger(value) && value >= 1000 && value <= 9999) {
                document.getElementById('companyNumber').style.borderColor = '';
            }
            else {
                document.getElementById('companyNumber').style.borderColor = "red";
                isValid = false;
            }
        }
    }

    function onCheckboxChange(e) {
        if (e.target.checked == true) {
            document.getElementById('companyInfo').style.display = 'block';
        }
        else {
            document.getElementById('companyInfo').style.display = 'none';
        }
    }

    function validateEmail(value) {
        let pattern = new RegExp(/^[^@.]+@[^@]*\.[^@]*$/);
        if (!pattern.test(value)) {
            document.getElementById('email').style.borderColor = "red";
            isValid = false;
        }
        else { document.getElementById('email').style.borderColor = ''; }
    }

    function validatePasswords(pass, confirmation) {
        let pattern = new RegExp('^[0-9a-zA-Z_]{5,15}$');
        if (!pattern.test(pass)) {
            document.getElementById('password').style.borderColor = "red";
            isValid = false;
        }
        else {
            document.getElementById('password').style.borderColor = '';
        }
        if (!pattern.test(confirmation)) {
            document.getElementById('confirm-password').style.borderColor = "red";
            isValid = false;
        }
        else {
            document.getElementById('confirm-password').style.borderColor = '';
        }
        if (pass != confirmation) {
            document.getElementById('password').style.borderColor = "red";
            document.getElementById('confirm-password').style.borderColor = "red";
            isValid = false;
        }

    }

    function validateUsername(value) {
        let pattern = new RegExp('^[0-9a-zA-Z]{3,20}$');
        if (!pattern.test(value)) {
            document.getElementById('username').style.borderColor = "red";
            isValid = false;
        }
        else { document.getElementById('username').style.borderColor = ''; }
    }
}
