class Company {
    constructor() { this.departments = {}; }
    addEmployee(name, salary, position, department) {
        if (name === '' || salary === '' || position === '' || department === '' ||
            name === undefined || salary === undefined || position === undefined
            || department === undefined || name === null || salary === null ||
            position === null || department === null || salary < 0) 
            { throw new Error('Invalid input!'); }
        else {
            let employee = { name, salary, position, department };
            if (this.departments[department] === undefined) { this.departments[department] = []; }
            this.departments[department].push(employee);
            return (`New employee is hired. Name: ${name}. Position: ${position}`);
        }
    }
    bestDepartment() {
        let maxAvSalary = 0;
        let maxDepartment = '';
        for (const d in this.departments) {
            let av = 0;
            for (let i = 0; i < this.departments[d].length; i++) {
                av += this.departments[d][i].salary;
            }
            av /= this.departments[d].length;
            av = av.toFixed(2);
            if (av > maxAvSalary) { maxAvSalary = av; maxDepartment = d; }
        }
        let result = `Best Department is: ${maxDepartment}\n`;
        result += `Average salary: ${maxAvSalary}\n`;
        let employees = this.departments[maxDepartment].sort((a, b) => {
            if (a.salary != b.salary) return b.salary - a.salary;
            else return a.name.localeCompare(b.name);
        });
        for (let i = 0; i < employees.length; i++) {
            result += `${employees[i].name} ${employees[i].salary} ${employees[i].position}\n`;
        }
        result = result.trim();
        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
