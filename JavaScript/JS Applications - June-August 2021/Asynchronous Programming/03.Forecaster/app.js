function attachEvents() {
    let buttonSubmit = document.getElementById('submit');
    buttonSubmit.addEventListener('click', GetWeather);
    let conditions = {
        Sunny: () => '☀',
        "Partly sunny": () => '⛅',
        Overcast: () => '☁',
        Rain: () => '☂'
    }
    let currentDiv = document.getElementById('current');
    let upcomingDiv = document.getElementById('upcoming');
    let errorDiv = document.createElement('div');
    let errorLabel = document.createElement('div');
    errorLabel.setAttribute('class', 'label');
    errorLabel.textContent = 'Error';
    errorDiv.appendChild(errorLabel);
    errorDiv.style.display = 'none';
    document.getElementById('forecast').appendChild(errorDiv);

    async function GetWeather() {
        let location = document.getElementById('location').value;
        document.getElementById('location').value = '';
        document.getElementById('forecast').style.display = 'block';
        let locationsURL = `http://localhost:3030/jsonstore/forecaster/locations`;
        try {
            let locationsResponse = await fetch(locationsURL);
            let locations = await locationsResponse.json();
            let code = '';
            for (let i = 0; i < locations.length; i++) {
                if (locations[i].name == location) { code = locations[i].code; break; }
            }
            if (code != '') {
                errorDiv.style.display = 'none';
                currentDiv.style.display = '';
                upcomingDiv.style.display = '';
                let todayURL = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
                let todayResponse = await fetch(todayURL);
                let todayForecast = await todayResponse.json();
                let upcomingURL = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
                let upcomingResponse = await fetch(upcomingURL);
                let upcomingForecast = await upcomingResponse.json();
                while (currentDiv.children.length > 1 && upcomingDiv.children.length > 1) {
                    currentDiv.removeChild(currentDiv.lastChild);
                    upcomingDiv.removeChild(upcomingDiv.lastChild);
                }
                currentDiv.appendChild(todayReport(todayForecast));


                let forecastInfoDiv = document.createElement('div');
                forecastInfoDiv.classList.add('forecast-info');
                upcomingDiv.appendChild(forecastInfoDiv);

                let day1 = upcomingReport(upcomingForecast.forecast[0]);
                let day2 = upcomingReport(upcomingForecast.forecast[1]);
                let day3 = upcomingReport(upcomingForecast.forecast[2]);

                forecastInfoDiv.appendChild(day1);
                forecastInfoDiv.appendChild(day2);
                forecastInfoDiv.appendChild(day3);

                function upcomingReport(forecast) {
                    let upcomingSpan = document.createElement('span');
                    upcomingSpan.classList.add('upcoming');
                    let symbolSpan = document.createElement('span');
                    symbolSpan.classList.add('symbol');
                    symbolSpan.textContent = conditions[forecast.condition]();
                    let tempSpan = document.createElement('span');
                    tempSpan.classList.add('forecast-data');
                    tempSpan.textContent = `${forecast.low}°/${forecast.high}°`;
                    let weatherSpan = document.createElement('span');
                    weatherSpan.classList.add('forecast-data');
                    weatherSpan.textContent = forecast.condition;
                    upcomingSpan.appendChild(symbolSpan);
                    upcomingSpan.appendChild(tempSpan);
                    upcomingSpan.appendChild(weatherSpan);
                    return upcomingSpan;
                }


                function todayReport(forecast) {
                    let todayDiv = document.createElement('div');
                    todayDiv.classList.add('forecasts');
                    let conditionSymbolSpan = document.createElement('span');
                    conditionSymbolSpan.classList.add('condition', 'symbol');
                    conditionSymbolSpan.textContent = conditions[forecast.forecast.condition]();
                    let conditionSpan = document.createElement('span');
                    conditionSpan.classList.add('condition');
                    let nameSpan = document.createElement('span');
                    nameSpan.classList.add('forecast-data');
                    nameSpan.textContent = forecast.name;
                    let tempSpan = document.createElement('span');
                    tempSpan.classList.add('forecast-data');
                    tempSpan.textContent = `${forecast.forecast.low}°/${forecast.forecast.high}°`;
                    let weatherSpan = document.createElement('span');
                    weatherSpan.classList.add('forecast-data');
                    weatherSpan.textContent = forecast.forecast.condition;
                    conditionSpan.appendChild(nameSpan);
                    conditionSpan.appendChild(tempSpan);
                    conditionSpan.appendChild(weatherSpan);
                    todayDiv.appendChild(conditionSymbolSpan);
                    todayDiv.appendChild(conditionSpan);
                    return todayDiv;
                }

            }
            else { throw new Error('Not Found'); }
        } catch (error) {
            currentDiv.style.display = 'none';
            upcomingDiv.style.display = 'none';
            errorDiv.style.display = '';            
        }


    }
}

attachEvents();