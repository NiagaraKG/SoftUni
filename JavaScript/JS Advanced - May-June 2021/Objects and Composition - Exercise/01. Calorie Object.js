function compose(arr) {
    let calorie = new Object();
    for (let i = 0; i < arr.length; i += 2) {
        calorie[arr[i]] = Number(arr[i + 1]);
    }
    console.log(calorie);
}
compose(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);