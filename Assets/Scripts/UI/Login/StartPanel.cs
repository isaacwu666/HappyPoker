
using System.Collections.Generic;
using BestHTTP.JSON;
using Protocol.Code;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;
// 登录面板
public class StartPanel : UIBase
{
    private Button btnLogin;
    private Button btnClose;
    private InputField InputAccount;
    private InputField InputPWD;

    public void Awake()
    {
        Debug.Log("StartPanel 开始初始化Awake");
        Bind(UIEvent.START_PANEL_ACTIVE);
        Bind(UIEvent.PROMPT_MSG);
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode,message);switch (eventCode)
        {
            case UIEvent.START_PANEL_ACTIVE:
                base.setPanelActive((bool)message);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btnLogin=transform.Find("LoginBtn").GetComponent<Button>();
        btnClose=transform.Find("CloseStartPanel").GetComponent<Button>();
        InputAccount=transform.Find("AccountInput").GetComponent<InputField>();
        InputPWD=transform.Find("PwdInput").GetComponent<InputField>();
        
        btnLogin.onClick.AddListener(loginClick);
        btnClose.onClick.AddListener(closeClick);
        
        setPanelActive(false);
        //面板需要默认隐藏
        transform.localPosition=Vector3.zero;
       
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        btnLogin.onClick.RemoveAllListeners();
        btnClose.onClick.RemoveAllListeners();
    }

    private readonly SocketItem _socketItem = new SocketItem(Protocol.Code.OpCode.ACCOUNT,AccountCode.LOGIN);
    private readonly Dictionary<string,string> _dictionary = new Dictionary<string, string>();
 

    private void loginClick()
    {
        if (string.IsNullOrEmpty(InputAccount.text)||string.IsNullOrWhiteSpace(InputPWD.text))
        {
         
        }
        else
        {
            _dictionary["phone"] = InputAccount.text;
            _dictionary["pwd"] = InputPWD.text;
            _socketItem.Value=Json.Encode(_dictionary);
            Dispatch(AreaCode.NET,0,_socketItem);
            return; 
        }
    }

    private void closeClick()
    {
        base.setPanelActive(!gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

 
