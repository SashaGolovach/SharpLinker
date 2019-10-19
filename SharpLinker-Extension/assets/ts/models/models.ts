class Message {
    Data: any;
    Status: MessageStatuses;
    Action: PageActions;

    constructor(data, action, status){
        this.Data = data;
        this.Action = action;
        this.Status = status;
    }
}

enum MessageStatuses{
    Success,
    Error
}

enum PageActions{
    OnLoaded,
    CodeEntities
 }

 enum FrameActions{
    GetCodeEntities
 }