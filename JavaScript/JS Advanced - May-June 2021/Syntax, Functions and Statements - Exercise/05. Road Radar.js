function radar(speed, area) {
    let limit = 0;
    switch (area) {
        case 'motorway': limit = 130; break;
        case 'interstate': limit = 90; break;
        case 'city': limit = 50; break;
        case 'residential': limit = 20; break;
    }
    let isInLimit = limit >= speed;
    if (isInLimit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
    else {
        let diff = speed - limit;
        if (diff <= 20) {
            console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - speeding`);
        }
        else if (diff <= 40) {
            console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - excessive speeding`);
        }
        else {
            console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - reckless driving`);
        }
    }
}
radar(200, 'motorway');