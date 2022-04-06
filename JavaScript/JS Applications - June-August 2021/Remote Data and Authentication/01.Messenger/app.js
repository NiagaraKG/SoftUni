 function attachEvents() {
    let url = `http://localhost:3030/jsonstore/messenger`;
    let sendButton = document.getElementById('submit');
    sendButton.addEventListener('click', Submit);
    let refreshButton = document.getElementById('refresh');
    refreshButton.addEventListener('click', Refresh);

    async function Refresh() {
        let response = await fetch(url);
        let data = await response.json();        
        let textarea = document.getElementById('messages');
        textarea.textContent = '';
        for (const key in data) {
            textarea.textContent += `${data[key].author}: ${data[key].content}\n`;
        }
    }

    async function Submit() {
        let name = document.querySelector("input[name='author']").value;
        let text = document.querySelector("input[name='content']").value;
        document.querySelector("input[name='author']").value = '';
        document.querySelector("input[name='content']").value = '';
        let newMessage = {
            author: name,
            content: text
        };
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newMessage)
        });
        let data = await response.json();
    }

}

attachEvents();