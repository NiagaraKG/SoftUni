function solve() {
    let addButton = document.querySelector('.admin-view .action button');
    let modules = {};

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        let InputNameEl = document.querySelector('input[name="lecture-name"]');
        let InputDateEl = document.querySelector('input[name="lecture-date"]');
        let InputModuleEl = document.querySelector('select[name="lecture-module"]');
        if (!InputNameEl.value || !InputDateEl.value || InputModuleEl.value == 'Select module') { return; }
        if (!modules[InputModuleEl.value]) { modules[InputModuleEl.value] = []; }
        let currLecture = { name: InputNameEl.value, date: formatDate(InputDateEl.value) }
        modules[InputModuleEl.value].push(currLecture);
        InputNameEl.value = '';
        InputDateEl.value = '';
        InputModuleEl.value = 'Select module'
        createTrainings(modules);
    });

    function createTrainings(modules) {
        let modulesEl = document.querySelector('.modules');
        modulesEl.innerHTML = '';
        for (const m in modules) {
            let moduleEl = createModule(m);
            let ul = document.createElement('ul');
            let lectures = modules[m];
            lectures.sort((a, b) => a.date.localeCompare(b.date)).forEach(({ name, date }) => {
                let lectureEl = createLecture(name, date, m);
                ul.appendChild(lectureEl);
                let deleteButton = lectureEl.querySelector('button')
                deleteButton.addEventListener('click', (e) => {
                    modules[m] = modules[m].filter(x => !(x.name == name && x.date == date))
                    if (modules[m].length == 0) {
                        delete modules[m];
                        e.currentTarget.parentNode.parentNode.parentNode.remove();
                    }
                    else { e.currentTarget.parentNode.remove(); }
                });
            });
            moduleEl.appendChild(ul);
            modulesEl.appendChild(moduleEl);
        }
    }

    function createModule(name) {
        let div = document.createElement('div');
        div.classList.add('module');
        let h3 = document.createElement('h3');
        h3.textContent = `${name.toUpperCase()}-MODULE`;
        div.appendChild(h3);
        return div;
    }

    function createLecture(name, date) {
        let li = document.createElement('li');
        li.classList.add('flex');
        let h4 = document.createElement('h4');
        h4.textContent = `${name} - ${date}`
        let deleteButton = document.createElement('button');
        deleteButton.classList.add('red');
        deleteButton.textContent = 'Del';
        li.appendChild(h4);
        li.appendChild(deleteButton);
        return li;
    }

    function formatDate(dateInput) {
        let [date, time] = dateInput.split('T');
        date = date.replace(/-/g, '/');
        return `${date} - ${time}`;
    }
};