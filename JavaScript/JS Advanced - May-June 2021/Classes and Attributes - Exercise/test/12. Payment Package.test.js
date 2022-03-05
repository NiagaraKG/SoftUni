const assert = require('chai').assert;
const PaymentPackage = require('../12. Payment Package');


it('instantiate valid package', () => {
    let instance = new PaymentPackage('Pack', 10);
    assert.strictEqual(instance.name, 'Pack');
    assert.strictEqual(instance.value, 10);
    assert.strictEqual(instance.VAT, 20);
    assert.strictEqual(instance.active, true);
});

it('instantiate valid package with float', () => {
    let instance = new PaymentPackage('Pack', 10.5);
    assert.strictEqual(instance.name, 'Pack');
    assert.strictEqual(instance.value, 10.5);
    assert.strictEqual(instance.VAT, 20);
    assert.strictEqual(instance.active, true);
});

it('toString active pack', () => {
    let instance = new PaymentPackage('P', 1);
    let str = `Package: P\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2`;
    assert.strictEqual(instance.toString(), str);
});

it('toString pack with changed VAT', () => {
    let instance = new PaymentPackage('P', 1);
    instance.VAT = 10;
    let str = `Package: P\n- Value (excl. VAT): 1\n- Value (VAT 10%): 1.1`;
    assert.strictEqual(instance.toString(), str);
});

it('toString inactive pack', () => {
    let instance = new PaymentPackage('P', 1);
    instance.active = false;
    let str = `Package: P (inactive)\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2`;
    assert.strictEqual(instance.toString(), str);
});

it('toString inactive pack with changed VAT', () => {
    let instance = new PaymentPackage('P', 1);
    instance.active = false;
    instance.VAT = 10;
    let str = `Package: P (inactive)\n- Value (excl. VAT): 1\n- Value (VAT 10%): 1.1`;
    assert.strictEqual(instance.toString(), str);
});

it('try to create package with invalid string', () => {
    assert.throws(function () { new PaymentPackage('', 10); }, 'Name must be a non-empty string');
    assert.throws(function () { new PaymentPackage(undefined, 10); }, 'Name must be a non-empty string');
    assert.throws(function () { new PaymentPackage(null, 10); }, 'Name must be a non-empty string');

});

it('try to create package with 1 parameter - string', () => {
    assert.throws(function () { new PaymentPackage('P'); }, Error);
});

it('try to create package with 1 parameter - num', () => {
    assert.throws(function () { new PaymentPackage(5); }, Error);
});

it('try to create package with switched parameters', () => {
    assert.throws(function () { new PaymentPackage(5, 'P'); }, Error);
});

it('try to create package with extra num', () => {
    assert.doesNotThrow(function () { new PaymentPackage('P', 5, 5); }, Error);
});

it('try to create package with extra string', () => {
    assert.doesNotThrow(function () { new PaymentPackage('P', 5, '5'); }, Error);
});

it('try to create package with num instead of string', () => {
    assert.throws(function () { new PaymentPackage(5, 10); }, 'Name must be a non-empty string');
});

it('try to create package with negative num', () => {
    assert.throws(function () { new PaymentPackage('P', -1); }, 'Value must be a non-negative number');
});

it('try to create package with non-number', () => {
    assert.throws(function () { new PaymentPackage('P', '2'); }, 'Value must be a non-negative number');
    assert.throws(function () { new PaymentPackage('P', undefined); }, 'Value must be a non-negative number');
    assert.throws(function () { new PaymentPackage('P', null); }, 'Value must be a non-negative number');
    assert.throws(function () { new PaymentPackage('P', {}); }, 'Value must be a non-negative number');
    assert.doesNotThrow(function () { new PaymentPackage('P', NaN); }, Error);
    assert.throws(function () { new PaymentPackage('P', ''); }, 'Value must be a non-negative number');
});

it('try to set VAT with negative num', () => {
    let instance = new PaymentPackage('P', 1);
    assert.throws(function () { instance.VAT = -10; }, 'VAT must be a non-negative number');
});

it('try to set VAT with non-number', () => {
    let instance = new PaymentPackage('P', 1);
    assert.throws(function () { instance.VAT = '2'; }, 'VAT must be a non-negative number');
    assert.throws(function () { instance.VAT = undefined; }, 'VAT must be a non-negative number');
    assert.throws(function () { instance.VAT = null; }, 'VAT must be a non-negative number');
    assert.throws(function () { instance.VAT = ''; }, 'VAT must be a non-negative number');
    assert.throws(function () { instance.VAT = {}; }, 'VAT must be a non-negative number');
    assert.doesNotThrow(function () { instance.VAT = NaN; }, Error);
});

it('try to set status with non-bool', () => {
    let instance = new PaymentPackage('P', 1);
    assert.throws(function () { instance.active = 'true'; }, 'Active status must be a boolean');
    assert.throws(function () { instance.active = 3.5; }, 'Active status must be a boolean');
    assert.throws(function () { instance.active = null; }, 'Active status must be a boolean');
    assert.throws(function () { instance.active = undefined; }, 'Active status must be a boolean');
    assert.throws(function () { instance.active = NaN; }, 'Active status must be a boolean');
});

it('check if set status to false works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.active = false;
    assert.strictEqual(instance.active, false);
});

it('check if set status back to true works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.active = false;
    instance.active = true;
    assert.strictEqual(instance.active, true);
});

it('check if set name works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.name = 'Pack';
    assert.strictEqual(instance.name, 'Pack');
});

it('check if set value works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.value = 10;
    assert.strictEqual(instance.value, 10);
});

it('check if set value with float works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.value = 10.5;
    assert.strictEqual(instance.value, 10.5);
});

it('check if set value does not work with 0', () => {      
    let instance = new PaymentPackage('P', 1);    
    instance.value = 0; 
    assert.strictEqual(instance.value, 0);
});

it('check if set VAT works', () => {
    let instance = new PaymentPackage('P', 1);
    instance.VAT = 10;
    assert.strictEqual(instance.VAT, 10);
});

it('check if set VAT works with float', () => {
    let instance = new PaymentPackage('P', 1);
    instance.VAT = 10.5;
    assert.strictEqual(instance.VAT, 10.5);
});

it('check if set VAT works with 0', () => {
    let instance = new PaymentPackage('P', 1);
    instance.VAT = 0;
    assert.strictEqual(instance.VAT, 0);
});
