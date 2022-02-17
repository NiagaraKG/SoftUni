function assemble(order) {
    let car = new Object();
    car.model = order.model;
    car.engine = new Object();
    car.carriage = new Object();
    if (order.power <= 90)
   { car.engine.power = 90; car.engine.volume = 1800; }
    else if (order.power <= 120) 
    { car.engine.power = 120; car.engine.volume = 2400; }
    else { car.engine.power = 200; car.engine.volume = 3500; }
    car.carriage.type = order.carriage;
    car.carriage.color = order.color;
    let size = order.wheelsize
    if (order.wheelsize % 2 === 0) { size--; }
    car.wheels = [size, size, size, size];
    return car;
}
console.log(assemble({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));