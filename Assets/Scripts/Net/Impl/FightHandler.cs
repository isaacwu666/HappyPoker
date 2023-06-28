using System.Collections.Generic;
using BestHTTP.Extensions;
using LitJson;
using Model;
using Protocol.Code;
using Protocol.Code;


public class FightHandler : HandlerBase
{
    public override void OnReceive(string arrayStr)
    {
        int i = arrayStr.IndexOf(":");
        var subType = arrayStr.Substring(0, i).ToInt32();
        var msg = arrayStr.Substring(i + 1);
        switch (subType)
        {
            //准备
            case FightCode.READY_BRO:
                var l = LitJson.JsonMapper.ToObject<List<bool>>(msg);
                GameCache.gameRoom.ready = l.ToArray();
                Dispatch(AreaCode.UI, UIEvent.READY_UPDATE, true);
                // Dispatch(AreaCode.UI,UIEvent.READY_TEXT_ACTIVE,true);
                break;
            case FightCode.STATUS_BRO:
                updateFightStatus(msg);
                break;
            //其他玩家发牌
            case FightCode.GET_CARD_OTHER_SRES:
                otherGetCar(msg);
                break;
            //系统给自己发牌
            case FightCode.GET_CARD_SRES:
                var poker = LitJson.JsonMapper.ToObject<Model.dto.PokerDTO>(msg);
                Dispatch(AreaCode.UI,UIEvent.ME_GET_CAR,poker);
                break;
        }
    }

    void otherGetCar(string msg)
    {
        int idx = msg.ToInt32();
        if (idx==GameCache.gameRoom.meIdx)
        {
            //自己的信号，直接忽略
            return;
        }

        if (idx==GameCache.gameRoom.leftIdx)
        {
            Dispatch(AreaCode.UI,UIEvent.LEFT_GET_CAR,true);
            return;
        }

        if (idx==GameCache.gameRoom.rightIdx)
        {
            //自己的信号，
            Dispatch(AreaCode.UI,UIEvent.RIGHT_GET_CAR,true);
            return;
        }
    }

    void updateFightStatus(string msg)
    {
        GameRoom gameRoom = LitJson.JsonMapper.ToObject<GameRoom>(msg);
        if (GameCache.gameRoom == null)
        {
            return;
        }

        //开始抢地主了
        if (GameRoom.FightStatus.FightStatusWait == GameCache.gameRoom.status &&
            gameRoom.status == GameRoom.FightStatus.FightStatusLandowner)
        {
            GameCache.gameRoom.status = gameRoom.status;
            //
            GameCache.gameRoom.cmdPIdx = gameRoom.cmdPIdx;
            //当前的步数，用于保证时序
            GameCache.gameRoom.idxStep = gameRoom.idxStep;
            //
            //显示 抢地主按钮
        }
    }
}