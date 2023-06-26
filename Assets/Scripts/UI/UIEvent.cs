using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 存储所有的UI事件码
/// </summary>
public class UIEvent
{
    public const int START_PANEL_ACTIVE = 0;//设置开始面板的显示
    public const int REGIST_PANEL_ACTIVE = 1;//设置注册面板的显示
    public const int SETTING_PANEL_ACTIVE = 2;//设置面板的显示
    public const int CREATE_PANEL_ACTIVE = 3;//创建昵称面板的显示


    public const int LOGIN_SUCCESS = 4;
    public const int MATCH_PANEL_ACTIVE = 5;
    public const int REGISTER_SUCCESS = 6;
    public const int INFO_PANEL_UPDATE = 7;

    public const int PROMPT_MSG = int.MaxValue;
}
