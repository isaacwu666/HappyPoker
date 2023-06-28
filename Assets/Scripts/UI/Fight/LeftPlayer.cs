public class LeftPlayer : BasePlayer
{
    public new void Start()
    {
        base.Start();
        Bind(UIEvent.LEFT_CHAT);
    }

    protected override int GetPlayerIdx()
    {
        return GameCache.gameRoom.leftIdx;
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.LEFT_CHAT:
                showChat((string)message);
                break;
            case UIEvent.LEFT_GET_CAR:
                //加
                break;
        }
    }
}