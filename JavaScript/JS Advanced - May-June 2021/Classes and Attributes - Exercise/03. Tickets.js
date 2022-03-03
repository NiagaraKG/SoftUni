function sort(arr, criteria) {
    class Ticket {
        constructor(input) {
            let data = input.split('|');
            this.destination = data[0];
            this.price = Number(data[1]);
            this.status = data[2];
        }
    };
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        let curr = new Ticket(arr[i]);
        result[i] = curr;
    }
    if (criteria == 'destination') {
        result.sort((a, b) => a.destination.localeCompare(b.destination));
    }
    else if(criteria == 'status'){
        result.sort((a, b) => a.status.localeCompare(b.status));
    }
    else if(criteria == 'price'){
        result.sort((a, b) => a.price-b.price);
    }
    return result;
}

console.log(sort(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));