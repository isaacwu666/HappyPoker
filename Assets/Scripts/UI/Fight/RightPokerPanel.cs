using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RightPokerPanel : UIBase
{
    // Start is called before the first frame update
    void Start()
    {
        Bind(UIEvent.RIGHT_GET_CAR);
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.RIGHT_GET_CAR:
                //加
                AddPoker();
                break;
        }
    }

    private List<Image> pokerList = new List<Image>();
    private Quaternion _quaternion = Quaternion.Euler(0F, 0F, 137.764F);
    private Vector3 dif = new Vector3(-13F, 13, 0F);


    public void AddPoker()
    {
        var g = Instantiate(GameCache.otherPocker, dif * pokerList.Count, _quaternion).gameObject;
        g.transform.SetParent(this.transform);
        g.transform.localPosition = dif * pokerList.Count;
        g.transform.rotation = _quaternion;
        var v = g.GetComponent<Image>();
        pokerList.Add(v);
    }
}