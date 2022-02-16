function sort(input) {
    let ascending = input.sort((a, b) => a - b).slice();
    let descending = input.sort((a, b) => b - a).slice();
    let result = [];
    let a = 0, d = 0;
    for (let i = 0; i < ascending.length; i++) {
        if (Number(i) % 2 == 0) { result[i] = ascending[a]; a++; }
        else { result[i] = descending[d]; d++; }
    }
    return result;
}
console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));