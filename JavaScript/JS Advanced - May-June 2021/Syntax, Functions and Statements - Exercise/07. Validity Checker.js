function check(x1, y1, x2, y2) {
    let distance1 = Math.sqrt(Math.pow(x1 - 0, 2) + (Math.pow(y1 - 0, 2)));
    let distance2 = Math.sqrt(Math.pow(x2 - 0, 2) + (Math.pow(y2 - 0, 2)));
    let distance3 = Math.sqrt(Math.pow(x2 - x1, 2) + (Math.pow(y2 - y1, 2)));
    if (distance1 % 1 == 0) { console.log(`{${x1}, ${y1}} to {0, 0} is valid`); }
    else { console.log(`{${x1}, ${y1}} to {0, 0} is invalid`); }
    if (distance2 % 1 == 0) { console.log(`{${x2}, ${y2}} to {0, 0} is valid`); }
    else { console.log(`{${x2}, ${y2}} to {0, 0} is invalid`); }
    if (distance3 % 1 == 0) { console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`); }
    else { console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`); }
}
check(2, 1, 1, 1);