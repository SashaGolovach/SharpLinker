var iframeSource = 'http://0.0.0.0:8000/';

var iframe = document.createElement('iframe');
iframe.setAttribute('src', iframeSource);
iframe.setAttribute('id', 'sharpLinkerIframe');
iframe.style.width = 450 + 'px';
iframe.style.height = 200 + 'px';
document.body.appendChild(iframe);

// Send a message to the child iframe
var iframeElement = document.getElementById('sharpLinkerIframe');

// Send a message to the child iframe
var sendMessage = function (msg) {
    // Make sure you are sending a string, and to stringify JSON
    iframeElement.contentWindow.postMessage(msg, '*');
};

var documentUrl = document.location;
sendMessage(documentUrl);