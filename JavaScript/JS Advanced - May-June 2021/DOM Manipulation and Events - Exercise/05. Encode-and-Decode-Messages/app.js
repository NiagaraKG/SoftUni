function encodeAndDecodeMessages() {
    let encodeButton = document.getElementsByTagName('button')[0];
    let decodeButton = document.getElementsByTagName('button')[1];
    encodeButton.addEventListener('click', Encode);
    decodeButton.addEventListener('click', Decode);

    function Encode() {
        let text = document.getElementsByTagName('textarea')[0].value;
        let result = '';
        for (let i = 0; i < text.length; i++) {
            result += String.fromCharCode(text.charCodeAt(i) + 1);
        }
        document.getElementsByTagName('textarea')[0].value = '';
        document.getElementsByTagName('textarea')[1].value = result;
    }

    function Decode() {
        let text = document.getElementsByTagName('textarea')[1].value;
        let result = '';
        for (let i = 0; i < text.length; i++) {
            result += String.fromCharCode(text.charCodeAt(i) - 1);
        }
        document.getElementsByTagName('textarea')[1].value = result;
    }
}