using System;
using System.Collections;
using System.Collections.Generic;
using Model.dto;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MePokerPanel : UIBase
{
    public void Start()
    {
        Bind(UIEvent.ME_GET_CAR);
    }

    public override  void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.ME_GET_CAR:
                AddPoker((Model.dto.PokerDTO)message);
                break;
        }
    }

    public List<Poker> pokerList = new List<Poker>();

    private Vector3 dif = new Vector3(41F, 0, 0F);

    public void AddPokerDev()
    {
        var str = "{\"id\":11,\"name\":\"ClubOne\",\"color\":1,\"weight\":14}";
        Model.dto.PokerDTO dto = LitJson.JsonMapper.ToObject<PokerDTO>(str);
        AddPoker(dto);
    }
    

    void AddPoker(Model.dto.PokerDTO message)
    {
        GameCache.mePokers().Add(message);
        GameObject v = Instantiate(GameCache.mePoker, Vector3.zero, Quaternion.identity).gameObject;
        v.transform.SetParent(this.transform);
        v.transform.localPosition = dif * pokerList.Count;
        Poker poker = v.GetComponent<Poker>();
        poker.init(message);
        pokerList.Add(poker);
        if (pokerList.Count>16)
        {
            Dispatch(AreaCode.UI,UIEvent.TOP_PANEL_ACTIVE,true);
        }
    }
}