﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Net.Protocol;
using Tomato.Net;

namespace Tomato.Net.Protocol.Request
{
    /// <summary>
    /// 权限添加类型--如菜单,模块,功能,
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class ReqAuthorityEdit : IProtocol
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public int AuthorityId { get; set; }

        /// <summary>
        /// 该权限的描述
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public string AuthorityDescribe { get; set; }


        public ProtoEnum MessageType => throw new NotImplementedException();
    }
}
