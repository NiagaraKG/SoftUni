const assert = require('chai').assert;
const lookupChar = require('../03. Char Lookup');

it('return undefined if invalid 1st parameter', () =>{
    let actual = lookupChar(1,2);
    assert.isUndefined(actual);
});
it('return undefined if 2nd parameteris float', () =>{
    let actual = lookupChar('1st',0.5);
    assert.isUndefined(actual);
});
it('return undefined if 2nd parameter is string', () =>{
    let actual = lookupChar('1st','2nd');
    assert.isUndefined(actual);
});
it('too big index', ()=>{
    let actual = lookupChar('string', 6);
    assert.strictEqual(actual, 'Incorrect index');
});
it('negative index', ()=>{
    let actual = lookupChar('string', -1);
    assert.strictEqual(actual, 'Incorrect index');
});
it('valid', ()=>{
    let actual = lookupChar('correct', 0);
    assert.strictEqual(actual, 'c');
    actual = lookupChar('correct', 1);
    assert.strictEqual(actual, 'o');
    actual = lookupChar('correct', 6);
    assert.strictEqual(actual, 't');
});