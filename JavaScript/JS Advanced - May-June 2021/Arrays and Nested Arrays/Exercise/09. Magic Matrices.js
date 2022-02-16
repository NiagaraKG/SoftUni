function check(matrix) {
    let result = true;
    let sum = 0;
    for (let el of matrix[0]) { sum += el; }
    for (let r = 1; r < matrix.length; r++) {
        let curr = 0;
        for (let el of matrix[r]) { curr += el; }
        if (curr != sum) { result = false; break; }
    }
    for (let c = 0; c < matrix.length; c++) {
        let curr = 0;
        for (let r = 0; r < matrix.length; r++) { curr += matrix[r][c]; }
        if (curr != sum) { result = false; break; }
    }
    return result;
}
console.log(check([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));