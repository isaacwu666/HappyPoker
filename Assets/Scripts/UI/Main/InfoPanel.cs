using System;
using System.Collections;
using System.Collections.Generic;
using Protocol.Code;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : UIBase
{
    private Text NameText;
    private Text LevelText;
    private Text TextExp;
    private Slider SliderExp;
 

    public void Start()
    {
        NameText=transform.Find("NameText").GetComponent<Text>();

        if (GameCache.player!=null)
        {
            NameText.text = GameCache.player.nickName;    
        }
        var nameBtn=transform.Find("NameText").GetComponent<Button>();
        LevelText=transform.Find("LevelText").GetComponent<Text>();
        TextExp=transform.Find("TextExp").GetComponent<Text>();
        SliderExp=transform.Find("SliderExp").GetComponent<Slider>();
        
        nameBtn.onClick.AddListener(BtnNameClick);
        Bind(UIEvent.INFO_PANEL_UPDATE,UIEvent.PROMPT_MSG);
        Dispatch(AreaCode.UI,UIEvent.CREATE_PANEL_ACTIVE,false);
    }

    public void Update()
    {
        if (GameCache.player!=null&& NameText.text!=GameCache.player.nickName)
        {
            NameText.text = GameCache.player.nickName;    
        }
        
    }

    public  void Execute(int eventCode, object message)
    {
        base.Execute(eventCode,message);
        switch (eventCode)
        {
            case UIEvent.INFO_PANEL_UPDATE:
                if (GameCache.player!=null)
                {
                    NameText.text = GameCache.player.nickName;    
                }
                break;
        }
    }
     
    private void BtnNameClick()
    {
        Dispatch(AreaCode.UI,UIEvent.CREATE_PANEL_ACTIVE,true);
       
    }
}