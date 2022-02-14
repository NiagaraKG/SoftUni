function upper(input){    
    let matches = input.match(/[\w]+/g);
    for (let i = 0; i < matches.length; i++) {
        matches[i] = matches[i].toUpperCase();
    }
    console.log(matches.join(', '));
}
upper('Hi, how are you?');