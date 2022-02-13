function calculateTime(steps, stepLength, speed) {
    let speedInMPerS = speed * 5 / 18;
    let meters = steps * stepLength;
    let breakSeconds = Math.floor(meters / 500) * 60;
    let sec = breakSeconds + meters / speedInMPerS;
    let h = Math.floor(sec / 3600);
    sec %= 3600;
    let min = Math.floor(sec / 60);
    sec = Math.round(sec % 60);
    console.log(`${h.toString().padStart(2, '0')}:${min.toString().padStart(2, '0')}:${sec.toString().padStart(2, '0')}`);
}
calculateTime(2564, 0.70, 5.5);