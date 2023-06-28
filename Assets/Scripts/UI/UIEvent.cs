using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 存储所有的UI事件码
/// </summary>
public class UIEvent
{
    public const int START_PANEL_ACTIVE = 0; //设置开始面板的显示
    public const int REGIST_PANEL_ACTIVE = 1; //设置注册面板的显示
    public const int SETTING_PANEL_ACTIVE = 2; //设置面板的显示
    public const int CREATE_PANEL_ACTIVE = 3; //创建昵称面板的显示


    public const int LOGIN_SUCCESS = 4;
    public const int MATCH_PANEL_ACTIVE = 5;
    public const int REGISTER_SUCCESS = 6;
    public const int INFO_PANEL_UPDATE = 7;
    public const int START_GAME = 8; //开启游戏


    public const int ME_CHAT = 9; //我的聊天窗口
    public const int LEFT_CHAT = 10; //左边的聊天窗口
    public const int RIGHT_CHAT = 11; //右边的聊天窗口
    public const int SHORT_CUT_TIPS_ACTIVE = 12; //聊天快捷面板
    public const int READY_TEXT_ACTIVE = 13; //显示已准备
    public const int READY_UPDATE = 14;
    
    public const int LEFT_GET_CAR= 15;//左边发牌
    public const int RIGHT_GET_CAR= 16;//右边发牌
    public const int ME_GET_CAR= 17;//右边发牌
    //推送地主牌
    public const int LANSLOES_GET_CAR= 18;//landlord
    public const int TOP_PANEL_ACTIVE= 19;//顶部扑克显示 
    
    public const int PROMPT_MSG = int.MaxValue;
}