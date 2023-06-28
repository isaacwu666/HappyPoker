using BestHTTP.Extensions;
using Model;
using Protocol.Code;
public class MatchHandler:HandlerBase
{
    public override void OnReceive(string msg)
    {
        int i = msg.IndexOf(":");
        var subType = msg.Substring(0, i).ToInt32();
        switch (subType)
        {
             case MatchCode.ENTER_SRES:
                 Dispatch(AreaCode.UI,UIEvent.MATCH_PANEL_ACTIVE,true);
                 break;
             case MatchCode.LEAVE_BRO:
                 Dispatch(AreaCode.UI,UIEvent.MATCH_PANEL_ACTIVE,false);
                 break;
                //开始游戏
             case MatchCode.START_BRO:
                 var subMsg = msg.Substring(i + 1);
                 GameRoom dto = LitJson.JsonMapper.ToObject<GameRoom>(subMsg);
                 if (GameCache.gameRoom==null||GameCache.gameRoom.roomId!=dto.roomId)
                 {
                     GameCache.gameRoom = dto;
                     //初始化数据
                     GameCache.initRoom();
                 }
                 Dispatch(AreaCode.UI,UIEvent.START_GAME,true); 
                 break;
                  //准备就绪  
             case FightCode.READY_BRO:
                 
                 break;
        }
        
    }
}