class Stringer {
    constructor(text, lenght) {
        this.innerString = text;
        this.innerLength = lenght;
    }

    increase(lenght) { this.innerLength += lenght; }

    decrease(lenght) {
        this.innerLength -= lenght;
        if (this.innerLength < 0) { this.innerLength = 0; }
    }
    toString() {
        if (this.innerLength == 0) { return '...'; }
        else if(this.innerLength >= this.innerString.length)
        {return this.innerString;}
        else{
            let result = '';
            for (let i = 0; i < this.innerLength; i++) {
                result += this.innerString[i];
            }
            result += '...';
            return result;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
