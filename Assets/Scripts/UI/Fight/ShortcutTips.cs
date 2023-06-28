using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Protocol.Code;

public class ShortcutTips : UIBase
{
  
    // Start is called before the first frame update
    void Start()
    {
       Button[] btns= this.transform.GetComponentsInChildren<Button>();
       if (btns!=null)
       {
           for (var i = 0; i < btns.Length; i++)
           {
               var msg = btns[i].transform.GetComponentInChildren<Text>().text;
               var unityAction = new UnityAction(() =>
               {
                   ButtonClick(msg);
               });
               btns[i].onClick.AddListener(unityAction);
           }
       }
       Bind(UIEvent.SHORT_CUT_TIPS_ACTIVE);
       this.transform.localPosition=Vector3.zero;
       this.gameObject.SetActive(false);
       
       
    }

    private SocketItem SocketItem = new SocketItem(OpCode.CHAT,ChatCode.CREQ);
    private void ButtonClick(string text)
    {
        this.gameObject.SetActive(false);
        SocketItem.Value = GameCache.gameRoom.roomId+":"+text.Trim();
        Dispatch(AreaCode.NET,0,SocketItem);
        
    }
 
    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode, message);
        switch (eventCode)
        {
            case UIEvent.SHORT_CUT_TIPS_ACTIVE:
                setPanelActive(!this.gameObject.activeSelf);
                
                break;
        }
    }
}
