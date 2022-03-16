class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer) {
        let notFound = true;
        for (let i = 0; i < this.allCustomers.length; i++) {
            if (this.allCustomers[i].personalId == customer.personalId) {
                notFound = false;
                throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
            }
        }
        if (notFound) { this.allCustomers.push(customer); return customer; }
    }
    depositMoney(personalId, amount) {
        let notFound = true;
        for (let i = 0; i < this.allCustomers.length; i++) {
            if (this.allCustomers[i].personalId == personalId) {
                if (!this.allCustomers[i].totalMoney) { this.allCustomers[i].totalMoney = 0; }
                this.allCustomers[i].totalMoney += amount;
                if (!this.allCustomers[i].transactions) { this.allCustomers[i].transactions = []; }
                this.allCustomers[i].transactions.push({ type: 'deposit', amount: amount });
                return `${this.allCustomers[i].totalMoney}$`;
            }
        }
        if (notFound) { throw new Error('We have no customer with this ID!'); }
    }
    withdrawMoney(personalId, amount) {
        let notFound = true;
        for (let i = 0; i < this.allCustomers.length; i++) {
            if (this.allCustomers[i].personalId == personalId) {
                if (!this.allCustomers[i].totalMoney) { this.allCustomers[i].totalMoney = 0; }
                if (this.allCustomers[i].totalMoney < amount) {
                    throw new Error(`${this.allCustomers[i].firstName} ${this.allCustomers[i].lastName} does not have enough money to withdraw that amount!`);
                }
                this.allCustomers[i].totalMoney -= amount;
                this.allCustomers[i].transactions.push({ type: 'withdraw', amount: amount });
                return `${this.allCustomers[i].totalMoney}$`;
            }
        }
        if (notFound) { throw new Error('We have no customer with this ID!'); }
    }
    customerInfo(personalId) {
        let notFound = true;
        let result = '';
        for (let i = 0; i < this.allCustomers.length; i++) {
            if (this.allCustomers[i].personalId == personalId) {
                notFound = false;
                let customer = this.allCustomers[i];
                result += `Bank name: ${this._bankName}\n`;
                result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
                result += `Customer ID: ${customer.personalId}\n`;
                result += `Total Money: ${customer.totalMoney}$\nTransactions:\n`;
                for (let i = customer.transactions.length - 1; i >= 0; i--) {
                    let t = customer.transactions[i];
                    if (t.type == 'deposit') {
                        result += `${i + 1}. ${customer.firstName} ${customer.lastName} made deposit of ${t.amount}$!\n`;
                    }
                    else {
                        result += `${i + 1}. ${customer.firstName} ${customer.lastName} withdrew ${t.amount}$!\n`;
                    }
                }
            }
        }
        if (notFound) { throw new Error('We have no customer with this ID!'); }
        return result.trimEnd();
    }
}


let bank = new Bank('SoftUni Bank');
console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));
bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);
console.log(bank.withdrawMoney(6233267, 125));
console.log(bank.customerInfo(6233267));