function extract(arr) {
    let result = [];
    let max = arr[0];
    for (let num of arr)
    { if (num >= max) { result.push(num); max = num } }
    return result;
}
console.log(extract([1, 3, 8, 4, 10, 12, 3, 2, 24]));