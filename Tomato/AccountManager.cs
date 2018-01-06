﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Net;
using Tomato.Protocol;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Tomato
{
    public class UserManager
    {
        public static UserManager Instance { get; } = new UserManager();
        public void Initialize()
        {
            //注册委托
            MessageHandle.Instance.RegisterHandle<LoginRequest>(LoginRequestHandle);
            MessageHandle.Instance.RegisterHandle<RegisterRequest>(RegisterRequestHandel);
        }
        public void Uninitialize()
        {
            MessageHandle.Instance.UnloadHandle<LoginRequest>();
            MessageHandle.Instance.UnloadHandle<RegisterRequest>();
        }
        private void RegisterRequestHandel(Context context, RegisterRequest body)
        {
            var db = context.DbContext;
            var user = db.UserDB.FirstOrDefault(i => i.UserName == body.UserName);
            if (user == null)
            {
                user = new Model.UserInfo()
                {
                    Email = body.Email,
                    Gender = body.Gender,
                    NickName = body.NickName,
                    Password = body.Password,
                    UserName = body.UserName,
                };
                var session = new Model.Session()
                {
                    ExpirationTime = DateTime.Now.AddHours(1),
                    User = user,
                    Verified = true,
                    VerifiedTime = DateTime.Now
                };
                db.UserDB.Add(user);
                db.SaveChanges();
                Console.WriteLine(user.GUID);

                Console.WriteLine($"Register :  UserName : {user.UserName}  NickName : {user.NickName} PassWrod : {user.Password}");
                context.Response(new RegisterResponse()
                {
                    Message = "注册成功!",
                    Success = true,
                    Session = session.GUID
                });
            }
            else
            {
                context.Response(new RegisterResponse()
                {
                    Message = "账号已存在!",
                    Success = false,
                });
            }
        }

        private void LoginRequestHandle(Context context, LoginRequest Body)
        {
            var db = context.DbContext;
            var user = db.UserDB.FirstOrDefault(i => i.UserName == Body.UserName && i.Password == Body.PassWord);
            if (user != null)
            {
                var session = new Model.Session()
                {
                    ExpirationTime = DateTime.Now.AddHours(1),
                    User = user,
                    Verified = true,
                    VerifiedTime = DateTime.Now
                };
                db.SessionDB.Add(session);
                db.SaveChanges();
                context.Response(new LoginResponse()
                {
                    Message = "登陆成功!",
                    Success = true,
                    Session = session.GUID
                });
                Console.WriteLine($"Login :  UserName : {user.UserName}  NickName : {user.NickName} PassWrod : {user.Password}");
            }
            else
            {
                context.Response(new LoginResponse()
                {
                    Message = "账号或密码错误!",
                    Success = false,
                });
            }
        }
    }
}
