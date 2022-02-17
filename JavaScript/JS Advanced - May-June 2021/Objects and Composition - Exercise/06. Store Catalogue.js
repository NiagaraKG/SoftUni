function sort(input) {
    let catalogue = {};
    for (let i = 0; i < input.length; i++) {
        let [name, price] = input[i].split(' : ');
        price = Number(price);
        let letter = name[0].toUpperCase();
        if (catalogue[letter] === undefined) { catalogue[letter] = {}; }
        catalogue[letter][name] = [price];
    }
    let sortedInitials = Object.keys(catalogue)
        .sort((a, b) => a.localeCompare(b));
    for (const l of sortedInitials) {
        console.log(l);
        let products = [];
        for (const p of Object.entries(catalogue)) {
            if (p[0] == l) {
                for (const key of Object.entries(p[1])) 
                { products.push(key); }
            }
        }
        products = products.sort((a,b)=>a[0].localeCompare(b[0]));
        for (let i = 0; i < products.length; i++) {
            console.log(`${products[i][0]}: ${products[i][1][0]}`);            
        }
    }
}
sort(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);