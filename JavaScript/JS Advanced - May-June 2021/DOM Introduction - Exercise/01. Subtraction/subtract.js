function subtract() {
    let first = document.getElementById('firstNumber').value;
    let second = document.getElementById('secondNumber').value;
    let result = Number(first)-Number(second);
    let resultDiv = document.getElementById('result');
    resultDiv.textContent = result;
}