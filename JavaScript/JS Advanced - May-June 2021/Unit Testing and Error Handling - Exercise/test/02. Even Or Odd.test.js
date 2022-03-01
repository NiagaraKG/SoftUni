const assert = require('chai').assert;
const isOddOrEven = require('../02. Even Or Odd');

it('return undefined if not string', ()=>{
    let actual = isOddOrEven(5);
    assert.isUndefined(actual);
});

it('return even if even length', ()=>{
    let actual = isOddOrEven('even');
    assert.strictEqual(actual, 'even');
});

it('return odd if odd length', ()=>{
    let actual = isOddOrEven('odd');
    assert.strictEqual(actual, 'odd');
});