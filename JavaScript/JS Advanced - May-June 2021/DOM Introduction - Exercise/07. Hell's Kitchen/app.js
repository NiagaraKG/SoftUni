function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let text = document.querySelector('#inputs textarea').value;
      let input = JSON.parse(text);
      let restaurants = {};
      for (let i = 0; i < input.length; i++) {
         let [name, workersStr] = input[i].split(' - ');
         let workersInput = workersStr.split(', ').map(x => {
            let [name, salary] = x.split(' ');
            return { name, salary: Number(salary) };
         });
         if (restaurants[name] === undefined) {
            restaurants[name] = {
               name: name,
               workers: [],
               getAverageSalary() {
                  return this.workers.reduce((acc, el) => acc + el.salary, 0) / this.workers.length;
               }
            }
         }
         restaurants[name].workers = restaurants[name].workers.concat(workersInput);
      }
      let sorted = Object.values(restaurants)
         .sort((a, b) => b.getAverageSalary() - a.getAverageSalary());
      let best = sorted[0];
      best.workers.sort((a, b) => b.salary - a.salary);
      let bestString = `Name: ${best.name} Average Salary: ${best.getAverageSalary().toFixed(2)} Best Salary: ${best.workers[0].salary.toFixed(2)}`;
      let workersString = best.workers.map(x => `Name: ${x.name} With Salary: ${x.salary}`).join(' ');
      let bestDiv = document.querySelector('#bestRestaurant p');
      let workersDiv = document.querySelector('#workers p');
      bestDiv.textContent = bestString;
      workersDiv.textContent = workersString;
   }
}