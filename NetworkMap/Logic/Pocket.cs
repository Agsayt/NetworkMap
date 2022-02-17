using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMap.Logic
{
    class Pocket
    {

        int TTL = 64;
        string message;

        public Pocket(int _ttl, string _message)
        {
            TTL = _ttl;
            message = _message;
        }
    }
}
