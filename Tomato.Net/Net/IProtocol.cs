﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Protocol;

namespace Tomato.Net
{
    public interface IProtocol
    {
        ProtoEnum MessageType { get; }
    }
}