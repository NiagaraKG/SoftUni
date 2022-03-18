class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }
    set budget(budget) {
        if (budget < 0) { throw new Error('The budget cannot be a negative number'); }
        else { this._budget = budget; }
    }
    get budget() { return this._budget; }
    shopping(product) {
        let type = product[0];
        let price = Number(product[1]);
        if (price > this.budget) { throw new Error('Not enough money to buy this product'); }
        else {
            this.products.push(type);
            this.budget -= price;
            return `You have successfully bought ${type}!`;
        }
    }
    recipes(recipe) {
        let recipeName = recipe.recipeName;
        let productsList = recipe.productsList;
        for (let i = 0; i < productsList.length; i++) {
            if (!this.products.includes(productsList[i])) { throw new Error('We do not have this product'); }
        }
        this.dishes.push({ recipeName, productsList });
        return `${recipeName} has been successfully cooked!`;
    }
    inviteGuests(name, dish) {
        let dishFound = false;
        for (let i = 0; i < this.dishes.length; i++) {
            if (this.dishes[i].recipeName == dish) { dishFound = true; break; }
        }
        if (!dishFound) { throw new Error('We do not have this dish'); }
        for (const key in this.guests) {
            if (key == name) { throw new Error('This guest has already been invited'); }
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }
    showAttendance() {
        let result = '';
        for (const g in this.guests) {
            result += `${g} will eat ${this.guests[g]}, which consists of `;
            for (let i = 0; i < this.dishes.length; i++) {
                if (this.dishes[i].recipeName == this.guests[g]) {
                    result += this.dishes[i].productsList.join(', ');
                    result += '\n'; break;
                }
            }
        }
        return result.trimEnd();
    }
}


let dinner = new ChristmasDinner(300);
dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);
dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});
dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');
console.log(dinner.showAttendance());