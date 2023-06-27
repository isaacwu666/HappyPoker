public class MePlayer : BasePlayer
{
    public void Start()
    {
        base.Start();
        Bind(UIEvent.ME_CHAT);
    }


    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.ME_CHAT:
                showChat((string)message);
                break;
        }
    }
}