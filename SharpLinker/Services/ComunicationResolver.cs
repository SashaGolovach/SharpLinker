using SharpLinker.Enums;
using SharpLinker.Models;
using SharpLinker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLinker.Services
{
    public class ComunicationResolver : IComunicationResolver
    {
        Dictionary<PageActions, Func<Message, Task> > eventHandlers;

        public ComunicationResolver()
        {
            eventHandlers = new Dictionary<PageActions, Func<Message, Task>>();
        }

        public async Task Resolve(Message data)
        {
            await eventHandlers[data.Action](data);
        }

        public void Subscribe(PageActions action, Func<Message, Task> func)
        {
            eventHandlers[action] = func;
        }

        public void Unsubscribe(PageActions action)
        {
            eventHandlers[action] = null; 
        }
    }
}
