const assert = require('chai').assert;
const mathEnforcer = require('../04. Math Enforcer');

describe('addFive', ()=>{
    it('return undefined if parameter is not number', ()=>{
        let actual = mathEnforcer.addFive('invalid');
        assert.isUndefined(actual);
    })
    it('valid with negative', ()=>{
        let actual = mathEnforcer.addFive(-5);
        assert.strictEqual(actual, 0);
    })
    it('valid with int', ()=>{
        let actual = mathEnforcer.addFive(5);
        assert.strictEqual(actual, 10);
    })
    it('valid with float', ()=>{
        let actual = mathEnforcer.addFive(5.5);
        assert.closeTo(actual, 10.5, 0.01);
    })
});

describe('subtractTen', ()=>{
    it('return undefined if parameter is not number', ()=>{
        let actual = mathEnforcer.subtractTen('invalid');
        assert.isUndefined(actual);
    })
    it('valid with negative', ()=>{
        let actual = mathEnforcer.subtractTen(-5);
        assert.strictEqual(actual, -15);
    })
    it('valid with int', ()=>{
        let actual = mathEnforcer.subtractTen(15);
        assert.strictEqual(actual, 5);
    })
    it('valid with float', ()=>{
        let actual = mathEnforcer.subtractTen(15.5);
        assert.closeTo(actual, 5.5, 0.01);
    })
});

describe('sum', ()=>{
    it('return undefined if 1st parameter is not number', ()=>{
        let actual = mathEnforcer.sum('invalid',5);
        assert.isUndefined(actual);
    })
    it('return undefined if 2nd parameter is not number', ()=>{
        let actual = mathEnforcer.sum(5, 'invalid');
        assert.isUndefined(actual);
    })
    it('valid with negatives', ()=>{
        let actual = mathEnforcer.sum(-10, -5);
        assert.strictEqual(actual, -15);
    })
    it('valid with ints', ()=>{
        let actual = mathEnforcer.sum(10, 5);
        assert.strictEqual(actual, 15);
    })
    it('valid with floats', ()=>{
        let actual = mathEnforcer.sum(10.5, 5.5);
        assert.closeTo(actual, 16.0, 0.01);
    })
    it('valid with int and float', ()=>{
        let actual = mathEnforcer.sum(10, 5.5);
        assert.closeTo(actual, 15.5, 0.01);
    })
});
