using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Protocol.Code;

public abstract class BasePlayer : UIBase
{
    public Text chatText;
    public Text TextReady;

    public void Start()
    {
        chatText = transform.Find("ChatText").GetComponent<Text>();
        chatText.gameObject.SetActive(false);
        TextReady = transform.Find("TextReady").GetComponent<Text>();
        updateReadyText();
        Bind(UIEvent.READY_UPDATE);
    }

    protected abstract int GetPlayerIdx();


    public void updateReadyText()
    {
        if (GameCache.gameRoom != null)
        {
            TextReady.gameObject.SetActive(GameCache.gameRoom.ready[GetPlayerIdx()]);
            bool res = true;
            for (var i = 0; i < GameCache.gameRoom.ready.Length; i++)
            {
                res = res && GameCache.gameRoom.ready[i];
                
            }

            if (res)
            {
                //全部准备后3s关闭
                Invoke("closeReady",3F);
            }
            
        }
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.READY_TEXT_ACTIVE:
                if ((bool)message)
                {
                    closeReady();
                    break;
                }
                else
                {
                    updateReadyText();
                    return;
                }
                break;
            case UIEvent.READY_UPDATE:
                updateReadyText();
                break;
        }
    }

    protected void closeReady()
    {
        TextReady.gameObject.SetActive(false);
    }

    public void showChat(string msg)
    {
        Debug.Log("显示聊天信息" + msg);
        chatText.text = msg;
        chatText.gameObject.SetActive(true);
        tipsShow = 0F;
    }

    public float tipsTime = 3F;
    public float tipsShow = 0F;

    public void Update()
    {
        if (chatText.gameObject.activeSelf)
        {
            tipsShow += Time.deltaTime;
            if (tipsShow >= tipsTime)
            {
                tipsShow = 0;
                closeTips();
            }
        }
    }

    public void closeTips()
    {
        if (chatText.gameObject.activeSelf)
        {
            chatText.gameObject.SetActive(false);
        }
    }
}