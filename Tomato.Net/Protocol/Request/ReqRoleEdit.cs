﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Net.Protocol.Request
{
    /// <summary>
    /// 角色
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class ReqRoleEdit : IProtocol
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public string Name { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public string Describe { get; set; }

        public ProtoEnum MessageType => throw new NotImplementedException();
    }
}
