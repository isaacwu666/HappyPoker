

using System.Collections.Generic;
using System.IO;

namespace Model
{
    //用户信息
    public class Player
    {
        public string id { get; set; }
        public string phone { get; set; }
        public string pwd { get; set; }
        public string salt { get; set; }
        public string nickName { get; set; }
        public string token { get; set; }
        public int douNum { get; set; }
    }

    public class GameRoom
    {
        //我的索引
        public int meIdx { get; set; }
        public string meId { get; set; }
        public int leftIdx { get; set; }
        public string leftId { get; set; }
        public int rightIdx { get; set; }

        public List<Model.dto.PokerDTO> mePokers { get; set; }
        public string rightId { get; set; }

        //游戏状态。1等待中，5抢地主，10翻倍中，15发牌中，20开始游戏，30结算中，40退出游戏
        public int status { get; set; }

        //当前可以执行命令的玩家下标，在抢地主，翻倍，发牌 状态中有效
        public int cmdPIdx { get; set; }
        
        //当前的步数，用于保证时序
        public int idxStep { get; set; }


        public Players[] players { get; set; }
        public bool[] onLine { get; set; }
        public bool[] ready { get; set; }
        public string roomId { get; set; }
        public object command { get; set; }


        public class Players
        {
            public string id { get; set; }
            public Player player { get; set; }
            public bool isLogin { get; set; }
            public string roomId { get; set; }
        }

        public class Player
        {
            public string id { get; set; }
            public string phone { get; set; }
            public string nickName { get; set; }
        }

        public class FightStatus
        {
            public const int FightStatusWait = 1; //1等待中
            public const int FightStatusLandowner = 5; //5抢地主
            public const int FightStatusDouble = 10; //10翻倍中
            public const int FightStatusDealing = 15; //15发牌中
            public const int FightStatusInGame = 20; //20开始游戏
            public const int FightStatusInSettlement = 30; //30结算中
            public const int FightStatusExit = 40; //40退出游戏
        }
    }
};