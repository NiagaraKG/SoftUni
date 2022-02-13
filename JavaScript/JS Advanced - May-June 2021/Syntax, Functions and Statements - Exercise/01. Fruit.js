function fruit(type, weight, price) {
    weight /= 1000;
    let total = price * weight;
    console.log(`I need \$${total.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${type}.`);
}
fruit('orange', 2500, 1.80);