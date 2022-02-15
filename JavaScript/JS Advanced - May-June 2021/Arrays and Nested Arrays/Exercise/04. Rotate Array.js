function rotate(arr, n) {
    n %= arr.length;
    for (let i = 0; i < n; i++) {
        let last = arr[arr.length - 1];
        for (let j = arr.length - 1; j > 0; j--) {
            arr[j] = arr[j - 1];
        }
        arr[0] = last;
    }
    console.log(arr.join(' '));
}
rotate(['1', '2', '3', '4'], 2);