class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }
    addCar(model, number) {
        if (this.vehicles.length == this.capacity) { throw new Error('Not enough parking space.'); }
        let car = {
            carModel: model,
            carNumber: number,
            payed: false
        };
        this.vehicles.push(car);
        return `The ${model}, with a registration number ${number}, parked.`;
    }
    removeCar(number) {
        let notFound = true;
        for (let i = 0; i < this.vehicles.length; i++) {
            if (this.vehicles[i].carNumber == number) {
                notFound = false;
                if (!this.vehicles[i].payed) { throw new Error(`${number} needs to pay before leaving the parking lot.`); }
                else {
                    this.vehicles.splice(i, 1);
                    return `${number} left the parking lot.`;
                }
            }
        }
        if (notFound) { throw new Error("The car, you're looking for, is not found."); }
    }
    pay(number) {
        let notFound = true;
        for (let i = 0; i < this.vehicles.length; i++) {
            if (this.vehicles[i].carNumber == number) {
                notFound = false;
                if (this.vehicles[i].payed) { throw new Error(`${number}'s driver has already payed his ticket.`); }
                else {
                    this.vehicles[i].payed = true;
                    return `${number}'s driver successfully payed for his stay.`;
                }
            }
        }
        if (notFound) { throw new Error(`${number} is not in the parking lot.`); }
    }
    getStatistics(number) {
        if (number == undefined) {
            let result = '';
            result += `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;
            this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));
            for (let i = 0; i < this.vehicles.length; i++) {
                let payedText = 'Not payed';
                if (this.vehicles[i].payed) { payedText = 'Has payed'; }
                result += `${this.vehicles[i].carModel} == ${this.vehicles[i].carNumber} - ${payedText}\n`;
            }
            return result.trimEnd();
        }
        else {
            for (let i = 0; i < this.vehicles.length; i++) {
                if (this.vehicles[i].carNumber == number) {                   
                    let payedText = 'Not payed';
                    if (this.vehicles[i].payed) { payedText = 'Has payed'; }
                    return `${this.vehicles[i].carModel} == ${this.vehicles[i].carNumber} - ${payedText}`;
                }
            }
        }
    }
}

const parking = new Parking(12);
console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics("TX3691CA"));
console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
