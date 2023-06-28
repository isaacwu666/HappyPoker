using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEvent
{
    public const int LOAD_SCENE = 0;
}

public class SceneMgr : ManagerBase
{
    public static SceneMgr Instance;

    private void Awake()
    {
        Instance = this;
    }

    private string IndexSen;

    public override void Execute(int eventCode, object message)
    {
        Debug.Log("消息执行");
        base.Execute(eventCode, message);
        if (eventCode == SceneEvent.LOAD_SCENE)
        {
            switch (message)
            {
                case "Scenes/FightSene":
                    GameObject.Find("Canvas").SetActive(false);
                    if (IndexSen != null || IndexSen != (string)message)
                    {
                        IndexSen = (string)message;
                        SceneManager.LoadScene(IndexSen);
                    }

                    break;
                default:
                    if (IndexSen != null || IndexSen != (string)message)
                    {
                        IndexSen = (string)message;
                        SceneManager.LoadScene(IndexSen);
                    }

                    break;
            }
        }
    }
}