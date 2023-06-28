using System.Collections;
using System.Collections.Generic;
using System.Text;
using Protocol.Code;
using UnityEngine;
using UnityEngine.UI;

public class MatchPanel : UIBase
{
    private Button BtCancel;
    private Button BtStart;
    private Button BtMatch;

    private Text TextDesc;
    private bool waitMatch = false;

    // Start is called before the first frame update
    void Start()
    {
        BtCancel = transform.Find("BtCancel").GetComponent<Button>();
        BtStart = transform.Find("BtStart").GetComponent<Button>();
        BtMatch = transform.Find("BtMatch").GetComponent<Button>();
        TextDesc = transform.Find("TextDesc").GetComponent<Text>();

        BtCancel.onClick.AddListener(BtCancelClick);
        BtStart.onClick.AddListener(BtStartClick);
        BtMatch.onClick.AddListener(BtMatchClick);
        transform.localPosition = Vector3.zero;

        BtCancel.gameObject.SetActive(false);
        TextDesc.gameObject.SetActive(false);
        BtMatch.gameObject.SetActive(false);

        Bind(UIEvent.MATCH_PANEL_ACTIVE,UIEvent.START_GAME);
    }

    //Execute
    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.MATCH_PANEL_ACTIVE:
                BtCancel.gameObject.SetActive((bool)message);
                TextDesc.gameObject.SetActive((bool)message);
                this.waitMatch = (bool)message;
                // BtMatch.gameObject.SetActive((bool)message);
                if (!waitMatch)
                {
                    loadTime = 0;
                    last = 0;
                }

                break;
            case UIEvent.START_GAME:
                showToas(startGameTost);
                this.gameObject.SetActive(false);
                Dispatch(AreaCode.SCENE, SceneEvent.LOAD_SCENE, "Scenes/FightSene");
                break;
        }
    }

    private PromptMsg startGameTost = new PromptMsg("匹配成功进入房间", Color.black);
    
    private float loadTime = 0;
    private int last = 0;

    void Update()
    {
        if (!waitMatch)
        {
            return;
        }

        loadTime += Time.deltaTime;
        int count = (int)(loadTime / 0.5F);
        if (count < last)
        {
            return;
        }

        StringBuilder stringBuilder = new StringBuilder("正在寻找房间");
        last++;
        for (int i = 0; i < last; i++)
        {
            stringBuilder.Append(".");
        }

        if (last > 6)
        {
            last = 0;
            loadTime = 0;
        }

        TextDesc.text = stringBuilder.ToString();
    }

    private void BtCancelClick()
    {
        //发送离开队列消息
        Dispatch(AreaCode.NET, 0, cancelMathc);
    }

    private SocketItem cancelMathc = new SocketItem(OpCode.MATCH, MatchCode.LEAVE_CREQ, 1);
    private SocketItem match = new SocketItem(OpCode.MATCH, MatchCode.ENTER_CREQ, 1);

    private void BtStartClick()
    {
        //快速开始
        Dispatch(AreaCode.NET, 0, match);
    }

    private void BtMatchClick()
    {
    }

    // Update is called once per frame
}