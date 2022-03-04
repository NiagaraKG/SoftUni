function juice(input) {
    let juices = {};
    let bottles = {};
    for (let i = 0; i < input.length; i++) {
        let [fruit, quantity] = input[i].split(' => ');
        quantity = Number(quantity);
        if (!juices[fruit]) { juices[fruit] = 0; }
        juices[fruit] += quantity;
        let b = 0;
        while (juices[fruit] >= 1000) {
            b++;
            juices[fruit] -= 1000;
        }
        if (b > 0) {
            if (!bottles[fruit]) { bottles[fruit] = 0; }
            bottles[fruit] += b;
        }
    }
    for (const j in bottles) {
        console.log(`${j} => ${bottles[j]}`);
    }
}

juice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);