using System;
using BestHTTP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BestHTTP.JSON;
using BestHTTP.WebSocket;
using UnityEngine;


public class WebSocketManager : ManagerBase
{
    public static WebSocketManager Instance;
    public string url = "ws://127.0.0.1:3014/hp_ws";

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Connenet();
    }

    public void Update()
    {
        //读取websocket，发送mq
        // ReadMessage();
    }

    public override void Execute(int eventCode, object message)
    {
       // base.Execute(eventCode, message);
        switch (eventCode)
        {
            case 0:
                var d = message as SocketItem;
                Send(d.OpCode.ToString(), d.SubCode.ToString(), d.Value);
                break;
        }
    }

    public void Connenet()
    {
        WebSocket webSocket = new WebSocket(new Uri(url));

        webSocket.OnMessage += AddMessage;
        webSocket.OnClosed += OnClosed;
        webSocket.OnError += onError;

        webSocket.OnOpen += (ws) => { Debug.Log("开启ws连接"); };
        if (GameCache.player != null)
        {
            webSocket.setHeader("x-token", GameCache.player.token);
        }

        webSocket.Open();
        this.webSocket = webSocket;
        sendBeat();
        reCount = 0;
    }

    private int reCount = 0;
    private void onError(WebSocket ws,Exception err)
    {
        webSocket = null;
        Debug.Log("连接错误");
        if (reCount<3)
        {
            reCount++;
            Debug.Log("开启重连");
            Connenet();
        }
    }

    private void sendBeat()
    {
        if (webSocket == null)
        {
            return;
        }

        var msg = Protocol.Code.OpCode.Beat + ":";
        var bytes = Encoding.UTF8.GetBytes(msg);
        webSocket.Send(bytes);
        //3秒后执行
        Invoke("sendBeat", 3);
    }

    public void Send(string op, string subOp, object message)
    {
        if (webSocket == null)
        {
            Connenet();
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(op);
        stringBuilder.Append(":");
        if (subOp != null)
        {
            stringBuilder.Append(subOp);
            stringBuilder.Append(":");
        }

        if (message != null)
        {
            if (message.GetType() == typeof(String))
            {
                stringBuilder.Append(message);
            }
            else
            {
                stringBuilder.Append(Json.Encode(message));
            }
        }

        Debug.Log("发送消息：" + stringBuilder.ToString());
        var bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
        webSocket.Send(bytes);
    }


    private WebSocket webSocket;
    private volatile Queue<string> msgQueue = new Queue<string>();

    private void OnClosed(WebSocket ws, ushort uUshort, string err)
    {
        this.webSocket = null;
        Debug.Log("OnClosed关闭消息" + err);
    }

    private void AddMessage(WebSocket ws, string message)
    {
        Debug.Log("收到服务端消息：" + message);
        // msgQueue.Enqueue(message);
        doReadMessage(message);
    }

    private void ReadMessage()
    {
        if (msgQueue.Count < 1)
        {
            return;
        }

        String msg = msgQueue.Dequeue();
        doReadMessage(msg);
    }

    private void doReadMessage(String msg)
    {
        
        var i = msg.IndexOf(":");
        var opType = int.Parse(msg.Substring(0, i));
        //处理消息信息
        switch (opType)
        {
            case Protocol.Code.OpCode.ACCOUNT:
                _accoutHandler.OnReceive(msg.Substring(i + 1));
                break;
            case Protocol.Code.OpCode.CHAT:
                _chatHandler.OnReceive(msg.Substring(i + 1));
                break;
            case Protocol.Code.OpCode.MATCH:
                _matchHandler.OnReceive(msg.Substring(i + 1));
                break;
            case Protocol.Code.OpCode.FIGHT:
                _fightHandler.OnReceive(msg.Substring(i + 1));
                break;
        }
    }

    private AccoutHandler _accoutHandler = new AccoutHandler();
    private MatchHandler _matchHandler = new MatchHandler();
    protected FightHandler _fightHandler = new FightHandler();
    protected ChatHandler _chatHandler = new ChatHandler();
}