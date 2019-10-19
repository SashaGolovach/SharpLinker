var ComunicationResolver = /** @class */ (function () {
    function ComunicationResolver() {
        this.eventFunctions = {};
    }
    ComunicationResolver.prototype.resolve = function (event) {
        this.eventFunctions[event.action](event.data);
    };
    ComunicationResolver.prototype.subscribe = function (action, func) {
        if (this.eventFunctions[action] == undefined)
            this.eventFunctions[action] = [];
        this.eventFunctions[action].append(func);
    };
    ComunicationResolver.prototype.unsubscribe = function (action, func) {
        this.eventFunctions[action] = null;
    };
    return ComunicationResolver;
}());
var Message = /** @class */ (function () {
    function Message() {
    }
    return Message;
}());
var MessageStatuses;
(function (MessageStatuses) {
    MessageStatuses[MessageStatuses["Success"] = 0] = "Success";
    MessageStatuses[MessageStatuses["Error"] = 1] = "Error";
})(MessageStatuses || (MessageStatuses = {}));
var PageActions;
(function (PageActions) {
    PageActions[PageActions["OnLoaded"] = 0] = "OnLoaded";
    PageActions[PageActions["GetWelcomeTextResponse"] = 1] = "GetWelcomeTextResponse";
})(PageActions || (PageActions = {}));
/// <reference path="../models/models.ts" />
var ComunicationService = /** @class */ (function () {
    function ComunicationService(resolver, iframeSource) {
        console.log(resolver);
        this.resolver = resolver;
        this.iframeSource = iframeSource;
        window.addEventListener("message", this.recieveMessage, false);
    }
    ComunicationService.prototype.sendMessage = function (data) {
        console.log('sendMessage data: ');
        console.log(data);
        this.iframeSource.contentWindow.postMessage(data, '*');
    };
    ComunicationService.prototype.recieveMessage = function (event) {
        var msg = event.data;
        console.log('recieveMessage data: ');
        console.log(msg);
        if (msg.status == MessageStatuses.Error)
            throw new Error('Error response: ' + event.data);
        console.log(this.resolver);
        this.resolver.resolve(msg);
    };
    return ComunicationService;
}());
/// <reference path="services/comunicationResolver.ts" />
/// <reference path="services/comunicationService.ts" />
var comunicationService;
var iframeSource = 'https://localhost:44340/';
var resolver;
onStartup();
function onStartup() {
    console.log('Extension started!');
    var iframe = createIframe(iframeSource);
    resolver = createComunicationResolverInstance();
    comunicationService = createComunicationServiceInstance(iframe, resolver);
}
function createComunicationServiceInstance(iframeElement, resolver) {
    var service = new ComunicationService(resolver, iframeElement);
    return service;
}
function createComunicationResolverInstance() {
    var resolver = new ComunicationResolver();
    resolver.subscribe(PageActions.OnLoaded, sendGetWelcomeText);
    resolver.subscribe(PageActions.GetWelcomeTextResponse, getWelcomeText);
    return resolver;
}
function createIframe(url) {
    var iframe = document.createElement('iframe');
    iframe.setAttribute('src', url);
    iframe.setAttribute('id', 'sharpLinkerIframe');
    iframe.style.width = 450 + 'px';
    iframe.style.height = 200 + 'px';
    document.body.appendChild(iframe);
    var iframeElement = document.getElementById('sharpLinkerIframe');
    return iframeElement;
}
function sendGetWelcomeText() {
    comunicationService.sendMessage({ "action": "getWelcomeText" });
}
function getWelcomeText(msg) {
    alert(msg);
}
