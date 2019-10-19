var iframeSource = 'https://localhost:44340/';

var iframe = document.createElement('iframe');
iframe.setAttribute('src', iframeSource);
iframe.setAttribute('id', 'sharpLinkerIframe');
iframe.style.width = 450 + 'px';
iframe.style.height = 200 + 'px';
document.body.appendChild(iframe);

var button = document.createElement('button');
button.innerHTML = 'Click me';
button.setAttribute('id', 'myButton');
document.body.appendChild(button);

var iframeElement = document.getElementById('sharpLinkerIframe');
var buttonEl = document.getElementById('myButton');

buttonEl.onclick = getText;
function getText() {
    sendMessage({"action" : "getWelcomeText"});
};
window.addEventListener("message", receiveMessage, false);

var iframeLoaded = false;

// Send a message to the child iframe
function sendMessage (msg) {
    if(iframeLoaded === true)
    {
        console.log("Sending msg to blazor ");
        console.log(msg);
        iframeElement.contentWindow.postMessage(msg, '*');
    }
    else
        alert('IFrame has not been loaded;'); 
};

function receiveMessage(event) {
    var data = event.data;
    console.log(data);
    if(data.action == undefined)
        return;
    else{
        switch(data.action){
            case 0:
                iframeLoaded = true;
                getText();
                break;
            case 1:
               alert(data.data);
               break; 
        }
    }
}