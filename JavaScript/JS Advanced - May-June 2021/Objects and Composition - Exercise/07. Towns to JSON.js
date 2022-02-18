function convert(input){
    let result = [];
    for (let i = 1; i < input.length; i++) {
        input[i] = input[i].substring(2,(input[i].length-2));
        let [town, lat, long] = input[i].split(' | ');
        lat = Number(Number(lat).toFixed(2));
        long = Number(Number(long).toFixed(2));
        let current = {
            'Town': town,
            'Latitude': lat,
            'Longitude': long
        }
        result.push(current);
    }
    console.log(JSON.stringify(result));
}
convert(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);