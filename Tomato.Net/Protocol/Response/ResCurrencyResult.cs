﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Net;
using Tomato.Protocol;

namespace Tomato.Protocol.Response
{

    /// <summary>
    /// 通用返回类型
    /// </summary>
    public class ResCurrencyResult : IProtocol
    {
        public ProtoEnum MessageType => throw new NotImplementedException();
    }
}
