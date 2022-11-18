using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_RPG.Models
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public int Succes { get; set; } = 1;
        public string Message { get; set; } = null;
    }
}
