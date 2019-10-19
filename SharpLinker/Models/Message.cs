using SharpLinker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLinker.Models
{
    public class Message
    {
        public PageActions Action { get; set; }
        public object Data {get; set;}
        public int Status { get; set; }
    }
}
