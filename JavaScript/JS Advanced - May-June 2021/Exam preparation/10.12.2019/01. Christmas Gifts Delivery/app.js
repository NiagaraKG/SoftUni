function solution() {
    let addButton = document.getElementsByTagName('input')[0].nextElementSibling;
    addButton.addEventListener('click', Add);

    function Add(){
        let giftName = document.getElementsByTagName('input')[0].value;
        document.getElementsByTagName('input')[0].value = '';
        let ul = document.getElementsByTagName('ul')[0];
        let li = document.createElement('li');
        li.setAttribute('class', 'gift');
        li.textContent = giftName;
        sendButton = document.createElement('button');
        sendButton.setAttribute('id', 'sendButton');
        sendButton.textContent = 'Send';
        discardButton = document.createElement('button');
        discardButton.setAttribute('id', 'discardButton');
        discardButton.textContent = 'Discard';
        li.appendChild(sendButton);
        li.appendChild(discardButton);
        ul.appendChild(li);
        Array.from(ul.children).sort((a,b)=>a.textContent.localeCompare(b.textContent))
        .forEach(item=>ul.appendChild(item));
        sendButton.addEventListener('click', Send);
        discardButton.addEventListener('click', Discard);
    }
    function Send(e)
    {
        let li = e.currentTarget.parentElement;
        li.parentElement.removeChild(li);        
        li.removeChild(li.lastElementChild);
        li.removeChild(li.lastElementChild);
        let ul = document.getElementsByTagName('ul')[1];
        ul.appendChild(li);        
    }
    function Discard(e)
    {
        let li = e.currentTarget.parentElement;
        li.parentElement.removeChild(li);        
        li.removeChild(li.lastElementChild);
        li.removeChild(li.lastElementChild);
        let ul = document.getElementsByTagName('ul')[2];
        ul.appendChild(li);       
    }
}