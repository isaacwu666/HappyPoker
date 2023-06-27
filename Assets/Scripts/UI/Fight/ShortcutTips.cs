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
               var unityAction = new UnityAction(() =>
               {
                   ButtonClick(btns[i].GetComponent<Text>().text);
               });
               btns[i].onClick.AddListener(unityAction);
           }
       }
       
    }

    private SocketItem SocketItem = new SocketItem(OpCode.CHAT,ChatCode.CREQ);
    private void ButtonClick(string text)
    {
        SocketItem.Value = GameCache.gameRoom.roomId+":"+text.Trim();
        Dispatch(AreaCode.NET,0,SocketItem);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
