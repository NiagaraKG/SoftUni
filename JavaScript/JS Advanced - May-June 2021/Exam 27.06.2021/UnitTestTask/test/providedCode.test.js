const assert = require('chai').assert;
const testNumbers = require('../providedCode');

it('sumNumbers valid positive ints',()=>{
    let actual = testNumbers.sumNumbers(5, 5);
    assert.strictEqual(actual, 10.00.toFixed(2));
})
it('sumNumbers valid negative ints',()=>{
    let actual = testNumbers.sumNumbers(-5, -5);
    assert.strictEqual(actual, (-10.00).toFixed(2));
})
it('sumNumbers valid 1 negative ints',()=>{
    let actual = testNumbers.sumNumbers(5, -5);
    assert.strictEqual(actual, 0.00.toFixed(2));
})
it('sumNumbers valid positive floats',()=>{
    let actual = testNumbers.sumNumbers(5.5, 4.5);
    assert.strictEqual(actual, 10.00.toFixed(2));
})
it('sumNumbers valid negative floats',()=>{
    let actual = testNumbers.sumNumbers(-5.5, -4.5);
    assert.strictEqual(actual, (-10.00).toFixed(2));
})
it('sumNumbers valid 1 negative floats',()=>{
    let actual = testNumbers.sumNumbers(5.5, -4.5);
    assert.strictEqual(actual, 1.00.toFixed(2));
})
it('sumNumbers valid 1 float and 1 int',()=>{
    let actual = testNumbers.sumNumbers(5, -4.5);
    assert.strictEqual(actual, 0.50.toFixed(2));
})
it('sumNumbers invalid 1 not num',()=>{
    assert.isUndefined(testNumbers.sumNumbers(5));
    assert.isUndefined(testNumbers.sumNumbers(5, '5'));
    assert.isUndefined(testNumbers.sumNumbers(5, 'text'));
    assert.isUndefined(testNumbers.sumNumbers(5, true));
    assert.isUndefined(testNumbers.sumNumbers(5, undefined));
    assert.isUndefined(testNumbers.sumNumbers(5, {}));
    assert.isUndefined(testNumbers.sumNumbers(5, []));

    assert.isUndefined(testNumbers.sumNumbers('5', 5));
    assert.isUndefined(testNumbers.sumNumbers('text', 5));
    assert.isUndefined(testNumbers.sumNumbers(true, 5));
    assert.isUndefined(testNumbers.sumNumbers(undefined, 5));
    assert.isUndefined(testNumbers.sumNumbers({}, 5));
    assert.isUndefined(testNumbers.sumNumbers([], 5));
})
it('numberChecker valid even', ()=>{
    assert.strictEqual(testNumbers.numberChecker(10), 'The number is even!');
    assert.strictEqual(testNumbers.numberChecker(4), 'The number is even!');
})
it('numberChecker valid odd', ()=>{
    assert.strictEqual(testNumbers.numberChecker(13), 'The number is odd!');
    assert.strictEqual(testNumbers.numberChecker(7), 'The number is odd!');
})
it('numberChecker invalid', ()=>{
    assert.throws(()=>testNumbers.numberChecker(NaN), 'The input is not a number!');
    assert.throws(()=>testNumbers.numberChecker('string'), 'The input is not a number!');
})
it('averageSumArray empty arr', ()=>{
    assert.isNaN(testNumbers.averageSumArray([]));
})
it('averageSumArray 1 element arr', ()=>{
    assert.strictEqual(testNumbers.averageSumArray([5]), 5);
    assert.strictEqual(testNumbers.averageSumArray([11]), 11);
})
it('averageSumArray even count elements arr', ()=>{
    assert.strictEqual(testNumbers.averageSumArray([5, 6]), 5.5);
    assert.strictEqual(testNumbers.averageSumArray([1, 2, 5, 9]), 4.25);
})
it('averageSumArray odd count elements arr', ()=>{
    assert.strictEqual(testNumbers.averageSumArray([5, 6, 7]), 6);
    assert.strictEqual(testNumbers.averageSumArray([1, 2, 5, 9, 17]), 6.8);
})