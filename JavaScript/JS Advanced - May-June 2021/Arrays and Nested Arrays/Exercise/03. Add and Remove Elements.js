function manipulateArr(commands) {
    let arr = [];
    let n = 1;
    for (let c of commands) {
        switch (c) {
            case 'add': arr.push(n); break;
            case 'remove': arr.pop(); break;
        }
        n++;
    }
    if (arr.length == 0) { console.log('Empty'); }
    else { for (let el of arr) { console.log(el); } }
}
manipulateArr(['add', 'add', 'add', 'add']);