function sort(arr, method) {
    if (method == 'asc') { arr.sort((a, b) => a - b); }
    else { arr.sort((a, b) => b - a); }
    return arr;
}
console.log(sort([14, 7, 17, 6, 8], 'asc'));