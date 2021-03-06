﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Entity.Model
{
    public interface IUser
    {
        Guid GUID { get; set; }
        string UserName { get; set; }
        string NickName { get; set; }
        string Password { get; set; }
        GenderEnum Gender { get; set; }
        bool Verified { get; set; }

        UserGrantEntity UserGrant { get; set; }
    }
    public class UserEntity : IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GUID { get; set; }

        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("昵称")]
        public string NickName { get; set; }

        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("邮箱")]
        public string Email { get; set; }

        [DisplayName("性别")]
        public GenderEnum Gender { get; set; }

        public bool Verified { get; set; }

        [DisplayName("授权表")]
        public UserGrantEntity UserGrant { get; set; }
    }
}
