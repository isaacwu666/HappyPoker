using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSense : UIBase
{
    private Button BtnSetting;
  

    // Start is called before the first frame update
    void Start()
    {
        BtnSetting = transform.Find("BtnSetting").GetComponent<Button>();
        BtnSetting.onClick.AddListener(BtnSettingClick);

     
    }
   
    private void BtnSettingClick()
    {
        Dispatch(AreaCode.UI,UIEvent.SETTING_PANEL_ACTIVE,true);
    }
}