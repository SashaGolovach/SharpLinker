/// <reference path="services/comunicationResolver.ts" />
/// <reference path="services/comunicationService.ts" />

let comunicationService : ComunicationService;
let iframeSource = 'https://localhost:44340/';
var resolver;

onStartup();

function onStartup(){
    console.log('Extension started!');
    let iframe = createIframe(iframeSource);
    resolver = createComunicationResolverInstance();
    comunicationService = createComunicationServiceInstance(iframe, resolver);
}

function createComunicationServiceInstance(iframeElement, resolver) {
    let service = new ComunicationService(resolver, iframeElement);
    return service;
}

function createComunicationResolverInstance() {
    let resolver = new ComunicationResolver();
    resolver.subscribe(PageActions.OnLoaded, OnLoaded);
    return resolver;
}

function OnLoaded(msg) {
    
}

function createIframe(url : string) {
    let iframe = document.createElement('iframe');
    iframe.setAttribute('src', url);
    iframe.setAttribute('id', 'sharpLinkerIframe');
    iframe.style.width = 450 + 'px';
    iframe.style.height = 200 + 'px';
    document.body.appendChild(iframe);

    let iframeElement = document.getElementById('sharpLinkerIframe');
    return iframeElement;
}

function sendGetCodeEntities(){
    let data = {
        Token : "1231254",
        Url : ""
    }
    comunicationService.sendMessage({"action" : "getWelcomeText"});
}

function GetEntitiesResponse(msg:Message) {

}

function getWelcomeText(msg){
    alert(msg);
}