using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 为什么写着脚本？
///     我们想扩展 MonoBehaviour
/// </summary>
public class MonoBase : MonoBehaviour
{
    /// <summary>
    /// 定义一个虚方法
    /// </summary>
    public virtual void Execute(int eventCode, object message)
    {
        if (eventCode == UIEvent.PROMPT_MSG)
        {
            showToas((PromptMsg)message);
        }
    }


    protected virtual void showToas(PromptMsg promptMsg)
    {
        if (promptMsg == null)
        {
            return;
        }

        if (tips==null)
        {
            createToas(promptMsg);
        }
        else
        {
            var text = tips.transform.Find("TipsText").GetComponent<Text>();
            text.text = promptMsg.Text;
            text.color = promptMsg.Color;
            tips.gameObject.SetActive(true);
            
        }
        Invoke("closeToas",2F);
        
    }

    private GameObject tips;

    protected void closeToas()
    {
        if (tips!=null)
        {
            tips.GameObject().SetActive(false);
        }
    }

    protected void createToas(PromptMsg promptMsg)
    {
        var tips = Resources.Load("Prefabs/Tips");
        var g = Instantiate(tips, Vector3.zero, Quaternion.identity).GameObject();
        this.tips = g;
        
        g.name = "Tips";
        var text = g.transform.Find("TipsText").GetComponent<Text>();
        text.text = promptMsg.Text;
        text.color = promptMsg.Color;
        
        var c= GameObject.Find("Canvas").GetComponent<Canvas>();
        g.transform.parent = c.transform;
        g.transform.localScale=Vector3.one;
        g.transform.localPosition=Vector3.zero;
        
    }
}