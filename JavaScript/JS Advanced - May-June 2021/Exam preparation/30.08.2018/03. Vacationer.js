class Vacationer {
    constructor(arr, obj) {
        this.fullName = arr;
        this.creditCard = obj;        
        this.wishList = [];
        this._idNumber = this.generateIDNumber();
    }
    get creditCard() {return this._creditCard;}

    set creditCard(obj){
        if (!obj) {
            this._creditCard = {
                cardNumber: 1111,
                expirationDate: '',
                securityNumber: 111
            }            
        }
        else {
            if (obj.length != 3) { throw new Error('Missing credit card information') }
            let [num, date, sec] = obj;
            if ((typeof num != 'number') || (typeof sec != 'number')) { throw new Error('Invalid credit card details'); }
            this._creditCard = {
                cardNumber: num,
                expirationDate: date,
                securityNumber: sec
            };
        }
    }
    set fullName(arr) {
        if (arr.length != 3) { throw new Error('Name must include first name, middle name and last name'); }
        let pattern = new RegExp('^[A-Z]{1}[a-z]{1,30}$');
        for (let i = 0; i < arr.length; i++) {
            if (!pattern.test(arr[i])) { throw new Error('Invalid full name'); }
        }
        this._fullName = {
            firstName: arr[0],
            middleName: arr[1],
            lastName: arr[2]
        };
    }
    get fullName() { return this._fullName; }
    get idNumber(){return this._idNumber;}
    set idNumber(value) {this._idNumber = this.generateIDNumber();}
    generateIDNumber() {
        let ID = 231 * this.fullName.firstName.charCodeAt(0) + 139 * this.fullName.middleName.length;
        const vowels = ['u', 'e', 'o', 'a', 'i'];
        const lastChar = this.fullName.lastName.charAt(this.fullName.lastName.length - 1);
        ID += vowels.includes(lastChar) ? '8' : '7';
        return ID;
    }
    addCreditCardInfo(arr) {
        if (arr.length < 3) { throw new Error('Missing credit card information') }
        if (typeof arr[0] != 'number' || typeof arr[2] != 'number') { throw new Error('Invalid credit card details'); }
        this._creditCard = {
            cardNumber: arr[0],
            expirationDate: arr[1],
            securityNumber: arr[2]
        };
    }
    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) { throw new Error('Destination already exists in wishlist'); }
        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);        
    }
    getVacationerInfo(){
        let result = `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\n`;
        result += `ID Number: ${this.idNumber}\nWishlist:\n`;
        if(this.wishList.length == 0) {result += 'empty';}
        else{result += this.wishList.join(', ');}
        result += `\nCredit Card:\nCard Number: ${this.creditCard.cardNumber}\n`;
        result += `Expiration Date: ${this.creditCard.expirationDate}\nSecurity Number: ${this.creditCard.securityNumber}`;
        return result;
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"],
    [123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

