// using Protocol.Code;
using System;
using System.Collections.Generic;
using BestHTTP.Extensions;
using BestHTTP.JSON;
using Model;
using Protocol.Code;
using UnityEngine;
 

public class AccoutHandler : HandlerBase
{
    public override void OnReceive(string msg)
    {
        int i = msg.IndexOf(":");
        int subType = msg.Substring(0, i).ToInt32();
        string json;
        Player player;
        switch (subType)
        {
            case AccountCode.LOGIN:
                json = msg.Substring(i + 1);
                player = LitJson.JsonMapper.ToObject<Model.Player>(json);
                GameCache.player = player;
                promptMsg.Change("登录成功", Color.red);
                Dispatch(AreaCode.UI, UIEvent.LOGIN_SUCCESS, promptMsg);
                break;
            
            case AccountCode.LOGIN_FAIL:
                
                promptMsg.Change("账号或者密码错误", Color.red);
                Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                break;
        
            case AccountCode.REGIST_SRES:
                var value = msg.Substring(i + 1);
                registResponse(value);
                break;
            
            case AccountCode.NICK_NAME_SRES:
                json = msg.Substring(i + 1);

                if (json=="-1")
                {
                    promptMsg.Change("修改失败", Color.red);
                    Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                    break;
                }
                else
                {
                    player = LitJson.JsonMapper.ToObject<Model.Player>(json);
                    GameCache.player = player;
                    promptMsg.Change("修改成功", Color.red);
                    Dispatch(AreaCode.UI, UIEvent.INFO_PANEL_UPDATE,true);
                    Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                    Dispatch(AreaCode.UI, UIEvent.CREATE_PANEL_ACTIVE,false);
                  
                }

                break;
            default:
                break;
        }
    }

    private PromptMsg promptMsg = new PromptMsg();
    
    /// <summary>
    /// 注册响应
    /// </summary>
    private void registResponse(String result)
    {
        switch (result)
        {
            default:
              
                var player= LitJson.JsonMapper.ToObject<Model.Player>(result);
                GameCache.player = player;
                promptMsg.Change("注册成功", Color.red);
                Dispatch(AreaCode.UI, UIEvent.REGISTER_SUCCESS, promptMsg);
                Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                break;
            case "-1":
                promptMsg.Change("账号已经存在", Color.red);
                Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                break;
            case "-2":
                promptMsg.Change("账号输入不合法", Color.red);
                Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                break;
            case "-3":
                promptMsg.Change("密码不合法", Color.red);
                Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
                break;
 
        }
    }
}
