using Protocol.Code;
using UnityEngine;
using UnityEngine.UI;

public class CreatePanel : UIBase
{
    private Button BtnSubmit;
    private Button BtnClose;

    private InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        BtnSubmit = transform.Find("BtnSubmit").GetComponent<Button>();
        BtnClose = transform.Find("BtnClose").GetComponent<Button>();
        NameInput = transform.Find("NameInput").GetComponent<InputField>();
        if (GameCache.player!=null)
        {
            NameInput.text = GameCache.player.nickName;
        }
        BtnSubmit.onClick.AddListener(BtnSubmitClick);
        BtnClose.onClick.AddListener(BtnCloseClick);
        Bind(UIEvent.CREATE_PANEL_ACTIVE,UIEvent.PROMPT_MSG);

        transform.localPosition = Vector3.zero;
        this.gameObject.SetActive(false);
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.CREATE_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
        }
    }

    private SocketItem _socketItem = new SocketItem(OpCode.ACCOUNT, AccountCode.NICK_NAME_CREQ);

    private void BtnSubmitClick()
    {
        if (!string.IsNullOrWhiteSpace(NameInput.text))
        {
            _socketItem.Value = NameInput.text.Trim();
            Dispatch(AreaCode.NET, 0, _socketItem);
        }
    }

    private void BtnCloseClick()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}