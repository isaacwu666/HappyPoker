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
        switch (eventCode)
        {
            case SceneEvent.LOAD_SCENE:
                if (IndexSen != null || IndexSen != message)
                {
                    IndexSen = (string)message;
                    SceneManager.LoadScene(IndexSen);
                }

                break;
        }
    }
}