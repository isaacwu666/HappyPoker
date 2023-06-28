using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RightPlayer : BasePlayer
{
    public new void Start()
    {
        base.Start();
        Bind(UIEvent.RIGHT_CHAT,UIEvent.RIGHT_GET_CAR);
    }

    protected override int GetPlayerIdx()
    {
        return GameCache.gameRoom.rightIdx;
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.RIGHT_CHAT:
                showChat((string)message);
                break;
            case UIEvent.RIGHT_GET_CAR:
                AddPoker();
                break;
        }
    }
    
    private List<Image> pokerList = new List<Image>();
    private Quaternion _quaternion = new Quaternion(0F, 0F, 137.76F, 0F);
    private Vector3 dif = new Vector3(13F, 13, 0F);
    


    void AddPoker()
    {
        var g = GameCache.otherPocker;
        var v = Instantiate(g, dif * pokerList.Count, _quaternion).GetComponent<Image>();
        v.sprite = GameCache.CardBack;
        pokerList.Add(v);
    }
}