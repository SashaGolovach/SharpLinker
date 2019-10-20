
class ComunicationResolver{
    eventFunctions : ActionsMap = {};

    resolve(event : any){
        if(this.eventFunctions[event.action] == undefined){
            console.error('There is no method to resolve action: ' + event.action);
            return;
        }
        this.eventFunctions[event.action](event.data);
    }

    subscribe(action, func){
        this.eventFunctions[action] = func;
    }

    unsubscribe(action, func){
        this.eventFunctions[action] = null;
    }
} 

interface ActionsMap {
    [name: string]: Function;
}