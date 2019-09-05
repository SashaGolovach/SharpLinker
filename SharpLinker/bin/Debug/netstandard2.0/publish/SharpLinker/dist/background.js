chrome.runtime.onMessage.addListener(function (message, sender, senderResponse) {
    if (message.msg === "html") {
        fetch('http://10.10.10.131:8080/')
            .then(response => response.text())
            .then(data => {
                senderResponse({ data: data});
            })
            .catch(error => console.log("error", error))
        return true;  // Will respond asynchronously.
    }
});