const assert = require('chai').assert;
const numberOperations = require('../03. Number Operations');

    it('valid pow', ()=>{
        let actual = numberOperations.powNumber(2);
        assert.strictEqual(actual, 4);
    })

    it('valid numCheck <100', ()=>{
        let actual = numberOperations.numberChecker(2);
        assert.strictEqual(actual, 'The number is lower than 100!');
    })

    it('valid numCheck 100', ()=>{
        let actual = numberOperations.numberChecker(100);
        assert.strictEqual(actual, 'The number is greater or equal to 100!');
    })

    it('valid numCheck >100', ()=>{
        let actual = numberOperations.numberChecker(102);
        assert.strictEqual(actual, 'The number is greater or equal to 100!');
    })

    it('invalid numCheck', ()=>{
        assert.throws(()=>numberOperations.numberChecker(NaN), Error);        
        assert.throws(()=>numberOperations.numberChecker(undefined), Error);
        assert.throws(()=>numberOperations.numberChecker('invalid'), Error);
        assert.doesNotThrow(()=>numberOperations.numberChecker('2'), Error);
    })

    it('valid sumArrays equal length', ()=>{
        let first = [1, 2, 3];
        let second = [3, 2, 1];
        let actual = numberOperations.sumArrays(first, second);
        assert.deepEqual(actual, [4, 4, 4]);
    })

    it('valid sumArrays 1st longer', ()=>{
        let first = [1, 2, 3, 4, 4];
        let second = [3, 2, 1];
        let actual = numberOperations.sumArrays(first, second);
        assert.deepEqual(actual, [4, 4, 4, 4, 4]);
    })

    it('valid sumArrays 2nd longer', ()=>{
        let first = [1, 2, 3];
        let second = [3, 2, 1, 4, 4];
        let actual = numberOperations.sumArrays(first, second);
        assert.deepEqual(actual, [4, 4, 4, 4, 4]);
    })