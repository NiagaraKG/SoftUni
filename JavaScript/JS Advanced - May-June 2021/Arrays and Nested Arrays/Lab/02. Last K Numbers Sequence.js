function calculate(n, k) {
    let result = [];
    result[0] = 1;
    for (let i = 1; i < n; i++) {
        let sum = 0;
        if (result.length < k) {
            for (let c = 0; c < result.length; c++) 
            { sum += result[c]; }
        }
        else {
            for (let c = 0; c < k; c++) 
            { sum += result[i - 1 - c]; }
        }
        result[i] = sum;
    }
    return result;
}
console.log(calculate(6, 3));