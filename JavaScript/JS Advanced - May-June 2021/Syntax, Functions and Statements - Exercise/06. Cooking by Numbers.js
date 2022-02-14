function cook(num, ...operations) {
    let n = Number(num);
    for (let op of operations) {
        switch (op) {
            case 'chop': n /= 2; break;
            case 'dice': n = Math.sqrt(n); break;
            case 'spice': n += 1; break;
            case 'bake': n *= 3; break;
            case 'fillet': n *= 0.8; break;
        }
        console.log(n);
    }
}
cook('32', 'chop', 'chop', 'chop', 'chop', 'chop');