function compare(input) {
    let products = {};
    for (const i of input) {
        let [town, product, price] = i.split(' | ');
        price = Number(price);
        products[product]? products[product][town] = price : products[product] = {[town]: price};
    }
    for (const p in products) {
        let sorted =Object.entries(products[p]).sort((a,b)=>a[1]-b[1]);
         console.log(`${p} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }
}
compare(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);