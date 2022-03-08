function attachEventsListeners() {
    let daysButton = document.getElementById('daysBtn');
    let hoursButton = document.getElementById('hoursBtn');
    let minutesButton = document.getElementById('minutesBtn');
    let secondsButton = document.getElementById('secondsBtn');

    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    daysButton.addEventListener('click', convertdays);
    hoursButton.addEventListener('click', converthours);
    minutesButton.addEventListener('click', convertminutes);
    secondsButton.addEventListener('click', convertseconds);

    function convertdays(){
        hoursInput.value = Number(daysInput.value) * 24;
        minutesInput.value = Number(hoursInput.value) * 60;
        secondsInput.value = Number(minutesInput.value) * 60;
    }

    function converthours(){
        daysInput.value = Number(hoursInput.value) / 24;
        minutesInput.value = Number(hoursInput.value) * 60;
        secondsInput.value = Number(minutesInput.value) * 60;
    }

    function convertminutes(){
        hoursInput.value = Number(minutesInput.value) / 60;
        daysInput.value = Number(hoursInput.value) / 24;
        secondsInput.value = Number(minutesInput.value) * 60;
    }

    function convertseconds(){
        minutesInput.value = Number(secondsInput.value) / 60;
        hoursInput.value = Number(minutesInput.value) / 60;
        daysInput.value = Number(hoursInput.value) / 24;
    }
}