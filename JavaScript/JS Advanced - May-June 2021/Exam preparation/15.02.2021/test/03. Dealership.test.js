const assert = require('chai').assert;
const dealership = require('../03. Dealership');

it('newCarCost has old', () => {
    let actual = dealership.newCarCost('Audi A4 B8', 20000);
    assert.strictEqual(actual, 5000);
    actual = dealership.newCarCost('Audi A6 4K', 25000);
    assert.strictEqual(actual, 5000);
    actual = dealership.newCarCost('Audi A8 D5', 30000);
    assert.strictEqual(actual, 5000);
    actual = dealership.newCarCost('Audi TT 8J', 20000);
    assert.strictEqual(actual, 6000);
})
it('newCarCost new = 0', () => {
    let actual = dealership.newCarCost('Audi A6 4K', 20000);
    assert.strictEqual(actual, 0);
})
it('newCarCost wrong old', () => {
    let actual = dealership.newCarCost('Audi A5 B8', 20000);
    assert.strictEqual(actual, 20000);
    actual = dealership.newCarCost('Audi TT 8I', 15000);
    assert.strictEqual(actual, 15000);
})
it('carEquipment valid', () => {
    let firstArr = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
    let secondArr = [0, 2, 3];
    let actual = dealership.carEquipment(firstArr, secondArr);
    let expected = ['heated seats', 'sport rims', 'navigation'];
    assert.deepEqual(actual, expected);

    secondArr = [3];
    actual = dealership.carEquipment(firstArr, secondArr);
    expected = ['navigation'];
    assert.deepEqual(actual, expected);

    secondArr = [0, 1, 2, 3];
    actual = dealership.carEquipment(firstArr, secondArr);
    assert.deepEqual(actual, firstArr);
})
it('carEquipment empty second', () => {
    let firstArr = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
    let secondArr = [];
    let actual = dealership.carEquipment(firstArr, secondArr);
    let expected = [];
    assert.deepEqual(actual, expected);
})
it('carEquipment 2 empty', () => {
    let firstArr = [];
    let secondArr = [];
    let actual = dealership.carEquipment(firstArr, secondArr);
    assert.deepEqual(actual, firstArr);
})
it('euroCategory >4', () => {
    let actual = dealership.euroCategory(5);
    let expected = 'We have added 5% discount to the final price: 14250.';
    assert.strictEqual(actual, expected);
})
it('euroCategory 4', () => {
    let actual = dealership.euroCategory(4);
    let expected = 'We have added 5% discount to the final price: 14250.';
    assert.strictEqual(actual, expected);
})
it('euroCategory <4', () => {
    let actual = dealership.euroCategory(3);
    let expected = 'Your euro category is low, so there is no discount from the final price!';
    assert.strictEqual(actual, expected);
})