 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TopPanel : UIBase
{
    private Image[] _images;

    void Start()
    {
        GameCache.loadResource();
        Bind(UIEvent.LANSLOES_GET_CAR,UIEvent.TOP_PANEL_ACTIVE);
        Image[] ims = transform.GetComponentsInChildren<Image>();
        _images = new Image[3];
        for (var i = 1; i <ims.Length; i++)
        {
            var image = ims[i];
            image.sprite = GameCache.CardBack;
            image.gameObject.SetActive(false);
            _images[i - 1] = image;
        }
         
        this.gameObject.SetActive(false);
    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.LANSLOES_GET_CAR:
                var array = (Model.dto.PokerDTO[])message;
                for (int i = 0; i < array.Length; i++)
                {
                    _images[i].sprite=Resources.Load<Sprite>("Poker/"+array[i].name);
                }
                this.gameObject.SetActive(true);
                break;
            case UIEvent.TOP_PANEL_ACTIVE:
                ShowCar((bool)message);
                break;
        }
    }

    public void ShowCar(bool active)
    {
        this.gameObject.SetActive(active);
        if (_images==null)
        {
            return;
        }

        foreach (var image in _images)
        {
            image.gameObject.SetActive(active);
        }
    }
}