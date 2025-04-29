import {chat} from './Chat.js';

let ch = new chat();
ch.loadChat();

function sendMessage() {
    const userName = "Me";

    let ob = document.getElementById("txtInput");   
    let userInput = ob.value;   
    let userOutput = "";
    
    ob.value = "";
    ch.send(userInput);

    let ob_header = document.getElementsByClassName("App-header")[0];

    let child = document.createElement("label");
    child.className = "label-user"
    child.innerHTML = `<strong>${userName}</strong>: ${userInput}`;
    ob_header.appendChild(child);

    child = document.createElement("label");
    child.className = "label-ai"
    child.innerHTML = userOutput;
    ob_header.appendChild(child);

    if (typeof(ob_header.scrollTop) != 'undefined') {
        ob_header.scrollTop = ob_header.scrollHeight;
    }
}

function keyPress(e) {
    if (e.key === 'Enter') {
        sendMessage();
    }
}

function TextBox() {   
    return (
        <div class="input-area">
            <input type="text" id="txtInput" size="20" onKeyDown={(e)=>{keyPress(e)}}/>           
        </div>
    );
}

export default TextBox;