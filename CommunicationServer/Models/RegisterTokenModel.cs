using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServer
{
    public class RegisterTokenModel
    {
        public string Secret { get; set; }
        public string ClientId { get; set; }
        public string Code { get; set; }

    }
}
