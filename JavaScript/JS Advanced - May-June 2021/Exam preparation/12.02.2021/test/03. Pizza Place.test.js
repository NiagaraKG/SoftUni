const assert = require('chai').assert;
const pizzUni = require('../03. Pizza Place');

it('makeAnOrder valid', ()=>{
    let actual = pizzUni.makeAnOrder({orderedPizza: 'Sea world', orderedDrink: 'Pepsi'});
    assert.strictEqual(actual, 'You just ordered Sea world and Pepsi.');
})
it('makeAnOrder without drink', ()=>{
    let actual = pizzUni.makeAnOrder({orderedPizza: 'Sea world'});
    assert.strictEqual(actual, 'You just ordered Sea world');
})
it('makeAnOrder invalid', ()=>{
    assert.throws(()=>{pizzUni.makeAnOrder({});},'You must order at least 1 Pizza to finish the order.');
})
it('getRemainingWork empty arr', ()=>{
    let actual = pizzUni.getRemainingWork([]);
    assert.strictEqual(actual, 'All orders are complete!');
})
it('getRemainingWork arr with all ready', ()=>{
    let actual = pizzUni.getRemainingWork([{pizzaName: 'Ham', status: 'ready'},{pizzaName: 'Ham', status: 'ready'}]);
    assert.strictEqual(actual, 'All orders are complete!');
})
it('orderType Carry Out int', ()=>{
    let actual = pizzUni.orderType(10, 'Carry Out');
    assert.strictEqual(actual, 9);
})
it('orderType Carry Out float', ()=>{
    let actual = pizzUni.orderType(10.5, 'Carry Out');
    assert.strictEqual(actual, 9.45);
})
it('orderType Delivery int', ()=>{
    let actual = pizzUni.orderType(10, 'Delivery');
    assert.strictEqual(actual, 10);
})
it('orderType Delivery float', ()=>{
    let actual = pizzUni.orderType(10.5, 'Delivery');
    assert.strictEqual(actual, 10.5);
})