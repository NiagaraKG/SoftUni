function summarise(...input){
    let types = {};
    for (let i = 0; i < input.length; i++) {
        let type = typeof(input[i]);
        console.log(`${type}: ${input[i]}`); 
        if(types[type] === undefined) {types[type] = 1;}
        else {types[type]++;}
    }
    let typesArr = Object.keys(types);
    typesArr.sort((a,b)=>types[b]-types[a]);
    for (let i = 0; i < typesArr.length; i++) {
        console.log(`${typesArr[i]} = ${types[typesArr[i]]}`);
        
    }
}
//summarise('cat', 42, function () { console.log('Hello world!'); });
summarise({ name: 'bob'}, 3.333, 9.999);