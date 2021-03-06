﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Net;
using Tomato.Net.Protocol.Request;
using Tomato.Protocol;

namespace Tomato.ServiceAccount
{
    public class AccountManager : ServiceBase
    {
        public override string ServiceName => "员工管理模块";

        //注册委托
        public AccountManager()
        {
            //用户管理
            MessageHandle.RegisterHandle<ReqUserLogin>(Controller.UserController.Instance.ReqUserLoginHandle);
            MessageHandle.RegisterHandle<ReqUserRegister>(Controller.UserController.Instance.ReqUserRegisterHandle);

            //部门管理
            MessageHandle.RegisterHandle<ReqDepartmentEdit>(Controller.DepartmentController.Instance.ReqDepartmentEditHandle);


        }

        //员工管理 
        //部门管理
        //职位管理
        //角色管理
        //权限管理
    }
}
