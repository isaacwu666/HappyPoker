using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : UIBase
{

    private Button BtnMusic;
    private Button BtnExit;
    private Button BtnClose;
    private Image ImageChoose;

    private Slider SliderMusic;
    // Start is called before the first frame update
    void Start()
    {
        BtnMusic = transform.Find("BtnMusic").GetComponent<Button>();
        BtnExit = transform.Find("BtnExit").GetComponent<Button>();
        BtnClose = transform.Find("BtnClose").GetComponent<Button>();
        
        ImageChoose = BtnMusic.transform.Find("ImageChoose").GetComponent<Image>();
        ImageChoose.gameObject.SetActive(Camera.main.GetComponent<AudioSource>().isPlaying);
        SliderMusic = transform.Find("SliderMusic").GetComponent<Slider>();
        
        
        BtnMusic.onClick.AddListener(BtnMusicClick);
        BtnExit.onClick.AddListener(BtnExitClick);
        BtnClose.onClick.AddListener(BtnCloseClick);
        
        
        Bind(UIEvent.SETTING_PANEL_ACTIVE,UIEvent.PROMPT_MSG);
        this.gameObject.SetActive(false);
        this.transform.localPosition = Vector3.zero;
        

    }

    public override void Execute(int eventCode, object message)
    {
        base.Execute(eventCode,message);switch (eventCode)
        {
            case UIEvent.SETTING_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
        }   
    }

    private void BtnExitClick()
    {
        Application.Quit();
    }
    void BtnCloseClick()
    {
        setPanelActive(!this.gameObject.activeSelf);
        
    }

    private void BtnMusicClick()
    {
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
        this.ImageChoose.gameObject.SetActive(!ImageChoose.gameObject.activeSelf);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
