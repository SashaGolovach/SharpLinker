/// <reference path="../models/models.ts" />

class ComunicationService{
    resolver: ComunicationResolver;
    iframeSource; 

    constructor(resolver: ComunicationResolver, iframeSource){
        console.log(resolver);
        this.resolver = resolver;
        this.iframeSource = iframeSource;
        window.addEventListener("message", this.recieveMessage, false);
    }

    sendMessage(data) {
        console.log('sendMessage data: ');
        console.log(data);
        this.iframeSource.contentWindow.postMessage(data, '*');
    }

    recieveMessage(event){
        let msg : Message = event.data;
        console.log('recieveMessage data: ');
        console.log(msg);
        if(msg.Status == MessageStatuses.Error)
            throw new Error('Error response: ' + event.data);
        console.log(this.resolver);
        this.resolver.resolve(msg);
    }
}