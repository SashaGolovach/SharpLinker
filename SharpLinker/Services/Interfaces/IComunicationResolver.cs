using SharpLinker.Enums;
using SharpLinker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLinker.Services.Interfaces
{
    public interface IComunicationResolver
    {
        Task Resolve(Message data);
        void Subscribe(PageActions action, Func<Message, Task> func);
        void Unsubscribe(PageActions action);
    }
}
