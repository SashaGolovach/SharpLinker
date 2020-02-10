using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using SharpLinker.Enums;
using SharpLinker.Models;
using SharpLinker.Services.Interfaces;

namespace SharpLinker.Pages
{
    public class IndexClass : BlazorComponent
    {
        [Inject]
        IComunicationResolver comunicationResolver { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var data = new Message
            {
                Action = PageActions.OnLoaded,
            };

            await JSRuntime.InvokeAsync<object>("sendMessage", data);
        }

        private void SubscribeForActions()
        {
            //_comunicationResolver.Subscribe(PageActions.GetAuthorizationUrl, )
        }

        //private Message

        [JSInvokable]
        public static object OnMessage(Message data)
        {
            comunicationResolver.Resolve(data);
            var response = new Message
            {
                Action = PageActions.GetWelcomeTextResponse,
                Data = "Hello world from C#"
            };
            return response;
        }
    }
}
