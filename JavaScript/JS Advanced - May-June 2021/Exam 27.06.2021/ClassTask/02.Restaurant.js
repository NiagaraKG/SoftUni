class Restaurant {
    constructor(budget) {
        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }
    loadProducts(products) {
        for (let i = 0; i < products.length; i++) {
            let [name, quantity, totalPrice] = products[i].split(' ');
            quantity = Number(quantity);
            totalPrice = Number(totalPrice);
            if (totalPrice <= this.budgetMoney) {
                this.budgetMoney -= totalPrice;
                if (!this.stockProducts[name]) { this.stockProducts[name] = 0; }
                this.stockProducts[name] += quantity;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            }
            else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }
        return this.history.join('\n');
    }
    addToMenu(meal, products, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = {
                products: products,
                price: price
            }
            if (Object.keys(this.menu).length == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal on the menu, other ideas?`;
            }
            else {
                return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals on the menu, other ideas?`;
            }
        }
        else { return `The ${meal} is already in the our menu, try something different.`; }
    }
    showTheMenu() {
        if (Object.keys(this.menu).length == 0) { return `Our menu is not ready yet, please come later...`; }
        else {
            let result = '';
            for (const meal in this.menu) {
                result += `${meal} - $ ${this.menu[meal].price}\n`;
            }
            return result.trimEnd();
        }
    }
    makeTheOrder(meal){
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        else{
            let products = this.menu[meal].products;
            let allEnough = true;
            for (let i = 0; i < products.length; i++) {
                let [name, quantity] = products[i].split(' ');
                if(!this.stockProducts[name] || this.stockProducts[name] < quantity) {
                    allEnough = false;
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                }
            }
            if(allEnough){
                for (let i = 0; i < products.length; i++) {
                    let [name, quantity] = products[i].split(' ');
                    this.stockProducts[name] -= quantity;
                }
                this.budgetMoney += this.menu[meal].price;
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
            }
        }
    }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));

