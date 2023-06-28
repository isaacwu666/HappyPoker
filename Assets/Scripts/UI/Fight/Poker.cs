using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poker : UIBase
{
    private Image Image;
    public void Awake()
    {
     
       Image= this.GetComponent<Image>();
       Image.sprite = GameCache.CardBack;

    }

    public Model.dto.PokerDTO PokerDto;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void init(Model.dto.PokerDTO PokerDto)
    {
        this.PokerDto = PokerDto;
       Image image= this.GetComponent<Image>();
       Resources.Load<Sprite>("Poker/ClubSeven");
       var sprite=Resources.Load<Sprite>("poker/" + this.PokerDto.name);

       image.sprite = sprite;
    }

    void OnTriggerStay(Collider collider)
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.localPosition+=(50*Vector3.up);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
