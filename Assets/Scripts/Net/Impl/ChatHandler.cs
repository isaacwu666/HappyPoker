// using Protocol.Code;

using System;
using System.Collections.Generic;
using BestHTTP.Extensions;
using BestHTTP.JSON;
using Model;
using Protocol.Code;
using UnityEngine;


public class ChatHandler : HandlerBase
{
    public override void OnReceive(string arrayStr)
    {
        int i = arrayStr.IndexOf(":");
        var subType = arrayStr.Substring(0, i).ToInt32();
        var msg = arrayStr.Substring(i + 1);
        switch (subType)
        {
            //服务端发消息
            case ChatCode.SRES:
                handlerFightChat(msg);
                break;
        }
    }
    //处理房间内聊天消息
    private void handlerFightChat(string arrayStr)
    {
        var i = arrayStr.IndexOf(":");
        var playerId = arrayStr.Substring(0, i).ToString();
        var msg = arrayStr.Substring(i + 1);
        
        if (GameCache.gameRoom==null)
        {
            return;
        }
       
        if (GameCache.gameRoom.meId==playerId)
        {
            Dispatch(AreaCode.UI,UIEvent.ME_CHAT,msg);
            return;
        }
        
        if (GameCache.gameRoom.rightId==playerId)
        {
            Dispatch(AreaCode.UI,UIEvent.RIGHT_CHAT,msg);
            return;
        }
        if (GameCache.gameRoom.leftId==playerId)
        {
            Dispatch(AreaCode.UI,UIEvent.LEFT_CHAT,msg);
            return;
        }
    }
}