const { assert, expect } = require("chai");
let { Repository } = require("../02. Repository.js");


it('valid initialisation', ()=> {
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    assert.deepEqual(repository.props, properties);
    assert.strictEqual(repository.nextId(), 0);
    assert.strictEqual(repository.count, 0);
    assert.deepEqual(repository.data, new Map());    
});
it('count works with empty data', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    assert.strictEqual(repository.count, 0);
});
it('count works with not empty data', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    assert.strictEqual(repository.count, 1);
    repository.add(entity);
    assert.strictEqual(repository.count, 2);
});
it('add valid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    assert.strictEqual(repository.add(entity),0);
});
it('add 2 valid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    assert.strictEqual(repository.add(entity),1);
});
it('add null', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = null
    assert.throws(()=>repository.add(entity),Error);
});
it('add invalid with not enough properties', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {age: 21};
    assert.throws(()=>repository.add(entity),'Property name is missing from the entity!');
});
it('add invalid with invalid type', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 'seven'};
    assert.throws(()=>repository.add(entity),'Property age is not of correct type!');
});
it('getId valid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    let actual = repository.getId(0);
    assert.deepEqual(actual, entity);
    repository.add(entity);
    actual = repository.getId(1);
    assert.deepEqual(actual, entity);
});
it('getId invalid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);     
    assert.throws(()=>repository.getId(0),Error);
});
it('update valid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    entity = {name: 'Maria', age: 22};
    repository.update(0, entity);
    assert.deepEqual(repository.getId(0), entity);
});
it('update invalid id', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    assert.throws(()=>repository.update(10, entity),Error);
});
it('update invalid newEntity', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    entity = {name: 'Maria', age: 'seven'};
    assert.throws(()=>repository.update(0, entity),Error);
    entity = {name: 'Maria'};
    assert.throws(()=>repository.update(0, entity),Error);
    entity = null;
    assert.throws(()=>repository.update(0, entity),Error);
});
it('del valid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    entity = {name: 'Marina', age: 22};
    repository.add(entity);
    assert.strictEqual(repository.count, 2);
    repository.del(0);
    assert.strictEqual(repository.count, 1);
    assert.deepEqual(repository.getId(1), entity);
    repository.del(1);
    assert.strictEqual(repository.count, 0);
});
it('del invalid', ()=>{
    let properties = { name: "string", age: "number" };
    let repository = new Repository(properties);
    let entity = {name: 'Maria', age: 21};
    repository.add(entity);
    assert.strictEqual(repository.count, 1);    
    assert.throws(()=>repository.del(1),Error);
    assert.throws(()=>repository.del(),Error);
    assert.throws(()=>repository.del('5'),Error);
});