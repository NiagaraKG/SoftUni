function solution() {
    let [protein, carbohydrate, fat, flavour] = [0, 0, 0, 0];
    return function (input) {
        let [action, element, quantity] = input.split(' ');
        quantity = Number(quantity);        
        if (action == 'restock') {
            switch (element) {
                case 'protein': protein += quantity; break;
                case 'carbohydrate': carbohydrate += quantity; break;
                case 'fat': fat += quantity; break;
                case 'flavour': flavour += quantity; break;
            }
            return 'Success';
        }
        else if (action == 'report') {
            return `protein=${protein} carbohydrate=${carbohydrate} fat=${fat} flavour=${flavour}`;
        }
        else {
            let hasError = false;
            let errorIngredient = '';
            if (element == 'apple') {
                if (carbohydrate < quantity*1) { hasError = true; errorIngredient = 'carbohydrate'; }
                else if (flavour < quantity*2) { hasError = true; errorIngredient = 'flavour' }
                else { carbohydrate -= quantity*1; flavour -= quantity*2; }
            }
            else if (element == 'lemonade') {
                if (carbohydrate < quantity*10) { hasError = true; errorIngredient = 'carbohydrate'; }
                else if (flavour < quantity*20) { hasError = true; errorIngredient = 'flavour' }
                else { carbohydrate -= quantity*10; flavour -= quantity*20; }
            }
            else if (element == 'burger') {
                if (carbohydrate < quantity*5) { hasError = true; errorIngredient = 'carbohydrate'; }
                else if (fat < quantity*7) { hasError = true; errorIngredient = 'fat' }
                else if (flavour < quantity*3) { hasError = true; errorIngredient = 'flavour' }
                else { carbohydrate -= quantity*5; fat -= quantity*7; flavour -= quantity*3; }
            }
            else if (element == 'eggs') {
                if (protein < quantity*5) { hasError = true; errorIngredient = 'protein'; }
                else if (fat < quantity*1) { hasError = true; errorIngredient = 'fat' }
                else if (flavour < quantity*1) { hasError = true; errorIngredient = 'flavour' }
                else { protein -= quantity*5; fat -= quantity*1; flavour -= quantity*1; }
            }
            else if (element == 'turkey') {
                if (protein < quantity*10) { hasError = true; errorIngredient = 'protein'; }
                else if (carbohydrate < quantity*10) { hasError = true; errorIngredient = 'carbohydrate' }
                else if (fat < quantity*10) { hasError = true; errorIngredient = 'fat' }
                else if (flavour < quantity*10) { hasError = true; errorIngredient = 'flavour' }
                else { 
                    protein -= quantity*10; carbohydrate -= quantity*10;
                     fat -= quantity*10; flavour -= quantity*10; 
                    }
            }
            if (hasError) { return `Error: not enough ${errorIngredient} in stock`; }
            else { return 'Success'; }
        }
    };
}

let manager = solution();
/*console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock */
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));
/*
'restock carbohydrate 10', 'Success'],
    ['restock flavour 10', 'Success'],
    ['prepare apple 1', 'Success'],
    ['restock fat 10', 'Success'],
    ['prepare burger 1', 'Success'],
    ['report', 'protein=0 carbohydrate=4 fat=3 flavour=5'
*/