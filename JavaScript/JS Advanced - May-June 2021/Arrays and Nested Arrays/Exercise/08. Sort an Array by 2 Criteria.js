function sort(arr) {
    arr.sort(
        function (a, b) {
            if (a.length == b.length) { return a.localeCompare(b); }
            else { return a.length - b.length; }
        }
    );
    for (let s of arr) { console.log(s); }
}
sort(['alpha', 'beta', 'gamma']);