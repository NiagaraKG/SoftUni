function generateReport() {
    let thElements = document.querySelectorAll('th');
    let trElements = document.querySelectorAll('tbody tr');
    let infoElements = [];
    let result = [];
    let thArr = Array.from(thElements);
    for (let i = 0; i < thArr.length; i++) {
       if(thArr[i].children[0].checked){
           infoElements.push(thArr[i].textContent.toLowerCase().trim());
       }  
       else{
           infoElements.push(false);
       }      
    }
    let trArr = Array.from(trElements);
    for (let i = 0; i < trArr.length; i++) {
        let row = {}; 
        let childrenArr = Array.from(trArr[i].children);
        childrenArr.forEach((el, k)=>{
            if(infoElements[k]){
                row[infoElements[k]] = el.textContent;
            }
        }) ;
        result.push(row);      
    }
    let output = document.getElementById('output');
    output.textContent = JSON.stringify(result);
}