function produce(input){
    let brands = {};
    for (let i = 0; i < input.length; i++) {
        let [brand, model, count] = input[i].split(' | ');
        count = Number(count);
        if(!brands[brand]) {brands[brand] = {};}
        if(!brands[brand][model]) {brands[brand][model] = 0;}
        brands[brand][model] += count;
    }
    for (const b in brands) {
        console.log(b);
        for (const m in brands[b]) {
            console.log(`###${m} -> ${brands[b][m]}`);
        }
    }
}

produce(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);