﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol.Code
{
    public class AccountCode
    {
        //注册的操作码
        public const int REGIST_CREQ = 0;//client request //参数 accountDto
        public const int REGIST_SRES = 1;//server response

        //登录的操作码
        public const int LOGIN = 2;//参数 accountDto 账号密码
        public const int LOGIN_FAIL = 3;//参数 accountDto 账号密码
        public const int NICK_NAME_CREQ = 4;//修改昵称
        
        public const int NICK_NAME_SRES = 5;//修改昵称
        
    }
}
