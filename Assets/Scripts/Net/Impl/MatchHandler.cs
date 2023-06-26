using BestHTTP.Extensions;
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
        }
        
    }
}