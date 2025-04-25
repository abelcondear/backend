import {chat} from './Chat.js';
let ch = null;

function sendMessage() {
    let ob = document.getElementById("txtInput");   
    let userInput = ob.value;   
    let userOutput = "";
    
    const userName = "Me";

    ob.value = "";
    ch.loadChat(userInput);

    let ob_header = document.getElementsByClassName("App-header")[0];
    let child = null;

    child = document.createElement("label");
    child.className = "label-user"
    child.innerText = `${userName}: ${userInput}`;
    ob_header.appendChild(child);

    child = document.createElement("label");
    child.className = "label-ai"
    child.innerText = userOutput;
    ob_header.appendChild(child);

    if (typeof(ob_header.scrollTop) != 'undefined') {
        ob_header.scrollTop = ob_header.scrollHeight;
    }
}


function TextBox() {
    ch = new chat();

    return (
        <div class="input-area">
            <input type="text" id="txtInput" size="20"/>
            <button onClick={()=>{sendMessage()}}>Enviar</button>
            <br/>
            <div id="lblMessage"></div>
        </div>
    );
}

export default TextBox;

