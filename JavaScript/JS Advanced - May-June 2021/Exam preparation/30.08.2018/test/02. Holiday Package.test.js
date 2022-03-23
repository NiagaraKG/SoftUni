class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}

const assert = require('chai').assert;
//const HolidayPackage = require('../02. Holiday Package');

it('create valid package',()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.deepEqual(actual.vacationers, []);
    assert.strictEqual(actual.destination, 'Varna');
    assert.strictEqual(actual.season, 'Summer');
    assert.strictEqual(actual.insuranceIncluded, false);
})
it('showVacationers with 0', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.strictEqual(actual.showVacationers(), 'No vacationers are added yet');
})
it('showVacationers with 2', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    actual.addVacationer('Maria Petrova');
    actual.addVacationer('Marina Petkova');
    assert.strictEqual(actual.showVacationers(), 'Vacationers:\nMaria Petrova\nMarina Petkova');
})
it('addVacationer valid', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.strictEqual(actual.vacationers.length, 0);
    actual.addVacationer('Maria Petrova');
    assert.strictEqual(actual.vacationers.length, 1);
    assert.strictEqual(actual.vacationers[0], 'Maria Petrova');
})
it('addVacationer not valid string', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.throws(()=>actual.addVacationer(''), Error);
    assert.throws(()=>actual.addVacationer(' '), Error);
    assert.throws(()=>actual.addVacationer(2), Error);
})
it('addVacationer 1 and 3 names', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.throws(()=>actual.addVacationer('Marina'), Error);
    assert.throws(()=>actual.addVacationer('Marina Petrova Petkova'), Error);
})
it('setInsurance valid', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.strictEqual(actual.insuranceIncluded, false);
    actual.insuranceIncluded = true;
    assert.strictEqual(actual.insuranceIncluded, true);
    actual.insuranceIncluded = false;
    assert.strictEqual(actual.insuranceIncluded, false);
})
it('setInsurance not bool', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    assert.throws(()=> actual.insuranceIncluded = 'false', Error);
    assert.throws(()=> actual.insuranceIncluded = 'true', Error);
    assert.throws(()=> actual.insuranceIncluded = 2, Error);    
})
it('generateHolidayPackage valid Summer no insurance', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Varna\nVacationers:\nMaria Petrova\nPrice: 600';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Winter no insurance', ()=>{
    let actual = new HolidayPackage('Bansko', 'Winter');
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Bansko\nVacationers:\nMaria Petrova\nPrice: 600';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Autmn no insurance', ()=>{
    let actual = new HolidayPackage('Apriltsi', 'Autmn');
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Apriltsi\nVacationers:\nMaria Petrova\nPrice: 400';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Spring no insurance', ()=>{
    let actual = new HolidayPackage('Apriltsi', 'Spring');
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Apriltsi\nVacationers:\nMaria Petrova\nPrice: 400';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Summer with insurance', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');
    actual.insuranceIncluded = true;
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Varna\nVacationers:\nMaria Petrova\nPrice: 700';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Winter with insurance', ()=>{
    let actual = new HolidayPackage('Bansko', 'Winter');
    actual.insuranceIncluded = true;
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Bansko\nVacationers:\nMaria Petrova\nPrice: 700';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Autmn with insurance', ()=>{
    let actual = new HolidayPackage('Apriltsi', 'Autmn');
    actual.insuranceIncluded = true;
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Apriltsi\nVacationers:\nMaria Petrova\nPrice: 500';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage valid Spring with insurance', ()=>{
    let actual = new HolidayPackage('Apriltsi', 'Spring');
    actual.insuranceIncluded = true;
    actual.addVacationer('Maria Petrova');
    let expected = 'Holiday Package Generated\nDestination: Apriltsi\nVacationers:\nMaria Petrova\nPrice: 500';
    assert.strictEqual(actual.generateHolidayPackage(), expected);
})
it('generateHolidayPackage invalid no vacationers', ()=>{
    let actual = new HolidayPackage('Varna', 'Summer');    
    assert.throws(()=> actual.generateHolidayPackage(), Error);    
})