using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP.JSON;
using Protocol.Code;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : UIBase
{
    private Button RegisterBtn;
    private Button CloseRgisterBtn;
    private InputField AccountInput;
    private InputField PwdInput;
    
    // Start is called before the first frame update
    void Start()
    {
        RegisterBtn = transform.Find("RegisterBtn").GetComponent<Button>();
        CloseRgisterBtn = transform.Find("CloseRgisterBtn").GetComponent<Button>();
        CloseRgisterBtn.onClick.AddListener(closeClick);
        RegisterBtn.onClick.AddListener(registerClick);

        AccountInput = transform.Find("AccountInput").GetComponent<InputField>();
        PwdInput = transform.Find("PwdInput").GetComponent<InputField>();
        setPanelActive(false);
        transform.localPosition = Vector3.zero;
        Bind(UIEvent.REGIST_PANEL_ACTIVE,UIEvent.PROMPT_MSG);
    }

    private void closeClick()
    {
        setPanelActive(!gameObject.activeSelf);
    }

    private Dictionary<string, string> account = new Dictionary<string, string>(2);
    private readonly SocketItem _socketItem = new SocketItem(Protocol.Code.OpCode.ACCOUNT,AccountCode.REGIST_CREQ);
    
    private void registerClick()
    {
        account["phone"]=AccountInput.text.Trim();
        account["pwd"]=PwdInput.text.Trim();
        _socketItem.Value=Json.Encode(account);
        Dispatch(AreaCode.NET,0,_socketItem);
    }
    
    public override void Execute(int eventCode, object message)
    {
        
        base.Execute(eventCode,message);switch (eventCode)
        {
            case UIEvent.REGIST_PANEL_ACTIVE:
                base.setPanelActive((bool)message);
                break;
           case UIEvent.PROMPT_MSG:
               break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}