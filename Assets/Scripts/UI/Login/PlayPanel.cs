using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//登录、注册按钮
public class PlayPanel : UIBase
{
    private Button LoginBtn; 
    private Button ReginBtn; 
  
    // Start is called before the first frame update
    void Start()
    {
        LoginBtn=transform.Find("LoginBtn").GetComponent<Button>();
        ReginBtn=transform.Find("ReginBtn").GetComponent<Button>();
        LoginBtn.onClick.AddListener(startClick);
        ReginBtn.onClick.AddListener(reginClick);
        Bind(UIEvent.LOGIN_SUCCESS);
        Bind(UIEvent.PROMPT_MSG);
    }
    
    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode,message);base.Execute(eventCode,message);switch (eventCode)
        {
            case UIEvent.LOGIN_SUCCESS:
                //todo 消息提醒
                Dispatch(AreaCode.SCENE,SceneEvent.LOAD_SCENE,"Scenes/MainScene");
                break;
        }

      
    }

    private void startClick()
    {
        Dispatch(AreaCode.UI,UIEvent.START_PANEL_ACTIVE,true);
    }
    
    private void reginClick()
    {
        Dispatch(AreaCode.UI,UIEvent.REGIST_PANEL_ACTIVE,true);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        LoginBtn.onClick.RemoveAllListeners();
        ReginBtn.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
