function calculator() {
    let obj1, obj2, resultObj;
    return {
        init: (selector1, selector2, resultSelector) => {
            obj1 = document.querySelector(selector1);
            obj2 = document.querySelector(selector2);
            resultObj = document.querySelector(resultSelector);
        },
        add: () => {
            resultObj.value = Number(obj1.value) + Number(obj2.value);
        },
        subtract: () => {
            resultObj.value = Number(obj1.value) - Number(obj2.value);
        }
    };
}
const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 




