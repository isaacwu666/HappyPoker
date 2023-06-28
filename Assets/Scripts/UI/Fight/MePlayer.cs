using System;
using Protocol.Code;
using UnityEngine.UI;

public class MePlayer : BasePlayer
{
    private Button BtnReady;
    private Button BtnNoPlayingCards;
    private Button BtnPlayingCards;
    
    private Button BtnNotLandowner;
    private Button BtnLandowner;

    public new void Start()
    {
        base.Start();
        Bind(UIEvent.ME_CHAT, UIEvent.READY_TEXT_ACTIVE,UIEvent.ME_GET_CAR);
        BtnReady = transform.Find("BtnReady").GetComponent<Button>();
        BtnReady.onClick.AddListener(BtnReadyClick);
        updateBtnReady();

        BtnNoPlayingCards = transform.Find("BtnNoPlayingCards").GetComponent<Button>();
        BtnPlayingCards = transform.Find("BtnPlayingCards").GetComponent<Button>();
        BtnNoPlayingCards.onClick.AddListener(BtnNoPlayingCardsClick);
        BtnPlayingCards.onClick.AddListener(BtnPlayingCardsClick);

        //不叫地主，叫地主
        BtnNotLandowner = transform.Find("BtnNotLandowner").GetComponent<Button>();
        if (BtnNotLandowner!=null)
        {
            BtnNotLandowner.onClick.AddListener(BtnNotLandownerClick);   
        }
        BtnLandowner = transform.Find("BtnLandowner").GetComponent<Button>();
        if (BtnLandowner!=null)
        {
            BtnLandowner.onClick.AddListener(BtnLandownerClick);
        }
        hidenBtnLandowner(); //隐藏叫地主按钮
        hidenBtnPlayingCards(); //隐藏发牌按钮
    }
 


    public void OnDisable()
    {
        base.OnDestroy();
        // BtnNoPlayingCards.onClick.RemoveAllListeners();
        // BtnPlayingCards.onClick.RemoveAllListeners();
        // BtnReady.onClick.RemoveAllListeners();
        // BtnLandowner.onClick.RemoveAllListeners();
        // BtnNotLandowner.onClick.RemoveAllListeners();
    }

    public void showBtnPlayingCards()
    {
        BtnNoPlayingCards.gameObject.SetActive(true);
        BtnPlayingCards.gameObject.SetActive(true);
    }

    public void hidenBtnPlayingCards()
    {
        BtnNoPlayingCards.gameObject.SetActive(false);
        BtnPlayingCards.gameObject.SetActive(false);
    }

    //显示叫地主按钮
    public void showBtnLandowner()
    {
        BtnNotLandowner.gameObject.SetActive(true);
        BtnLandowner.gameObject.SetActive(true);
    }

    void hidenBtnLandowner()
    {
        BtnNotLandowner.gameObject.SetActive(false);
        BtnLandowner.gameObject.SetActive(false);
    }

    //不叫地主
    private void BtnNotLandownerClick()
    {
    }

    //叫地主
    void BtnLandownerClick()
    {
    }

    //不出牌
    public void BtnNoPlayingCardsClick()
    {
    }

    //出牌
    public void BtnPlayingCardsClick()
    {
    }

    protected override int GetPlayerIdx()
    {
        return GameCache.gameRoom.meIdx;
    }

    public void updateBtnReady()
    {
        if (GameCache.gameRoom != null)
        {
            BtnReady.gameObject.SetActive(!GameCache.gameRoom.ready[GameCache.gameRoom.meIdx]);
        }
    }

    private SocketItem readSocket = new SocketItem(OpCode.FIGHT, FightCode.READY_CREQ);

    private void BtnReadyClick()
    {
        readSocket.Value = "";
        Dispatch(AreaCode.NET, 0, readSocket);
    }


    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.ME_CHAT:
                showChat((string)message);
                break;
             
        }
    }
}