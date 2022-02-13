function repdigit(num) {
    let first = num % 10;
    let sum = 0;
    let isRepdigit = true;
    while (num != 0) {
        let curr = num % 10;
        sum += curr;
        if (curr != first) { isRepdigit = false; }
        num = Math.floor(num / 10);
    }
    console.log(isRepdigit);
    console.log(sum);
}
repdigit(2222222);