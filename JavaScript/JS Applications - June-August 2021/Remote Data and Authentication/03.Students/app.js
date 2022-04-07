function solve() {
    let url = `http://localhost:3030/jsonstore/collections/students`;
    LoadTable();
    let buttonSubmit = document.getElementById('submit');
    buttonSubmit.addEventListener('click', AddStudent);

    async function AddStudent() {
        let firstName = document.querySelector("input[name='firstName']").value;
        let lastName = document.querySelector("input[name='lastName']").value;
        let facultyNumber = document.querySelector("input[name='facultyNumber']").value;
        let grade = document.querySelector("input[name='grade']").value;
        if (firstName == '' || lastName == '' || facultyNumber == '' || grade == '') 
        { alert('All fields should be filled'); }
        else {
            document.querySelector("input[name='firstName']").value = '';
            document.querySelector("input[name='lastName']").value = '';
            document.querySelector("input[name='facultyNumber']").value = '';
            document.querySelector("input[name='grade']").value = '';
            let student = {
                firstName: firstName,
                lastName: lastName,
                facultyNumber: facultyNumber,
                grade: grade
            };
            let response = await fetch(url, {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(student)
            });
            LoadTable();
        }
    }

    async function LoadTable() {
        let response = await fetch(url);
        let data = await response.json();
        let table = document.querySelector('tbody');
        for (const key in data) {        
            let tr = document.createElement('tr');
            let firstNameTD = document.createElement('td');
            firstNameTD.textContent = data[key].firstName;
            let lastNameTD = document.createElement('td');
            lastNameTD.textContent = data[key].lastName;
            let facultyNumberTD = document.createElement('td');
            facultyNumberTD.textContent = data[key].facultyNumber;
            let gradeTD = document.createElement('td');
            gradeTD.textContent = data[key].grade;
            tr.appendChild(firstNameTD);
            tr.appendChild(lastNameTD);
            tr.appendChild(facultyNumberTD);
            tr.appendChild(gradeTD);
            table.appendChild(tr);
        }
    }
}
solve();