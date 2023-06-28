using System.Collections.Generic;
using Model;
using Model.dto;
using Unity.VisualScripting;
using UnityEngine;

public class GameCache
{
    public static volatile Player player;

    //游戏房间对象
    public static volatile GameRoom gameRoom;


    public static void initRoom()
    {
        if (player == null || gameRoom == null)
        {
            return;
        }

        for (var i = 0; i < gameRoom.players.Length; i++)
        {
            if (gameRoom.players[i].id == player.id)
            {
                gameRoom.meIdx = i;
                gameRoom.meId = gameRoom.players[i].id;
                continue;
            }

            if (string.IsNullOrEmpty(gameRoom.leftId))
            {
                gameRoom.leftIdx = i;
                gameRoom.leftId = gameRoom.players[i].id;
                continue;
            }

            if (string.IsNullOrEmpty(gameRoom.rightId))
            {
                gameRoom.rightIdx = i;
                gameRoom.rightId = gameRoom.players[i].id;
                continue;
            }
        }
    }

    public static void loadResource()
    {
        otherPocker ??= Resources.Load("Prefabs/OtherPocker").GameObject();
        mePoker ??= Resources.Load("Prefabs/MePoker").GameObject();
        CardBack ??= CardBack = Resources.Load<Sprite>("Poker/CardBack");
    }

    public static List<Model.dto.PokerDTO> mePokers()
    {
        gameRoom ??= new GameRoom();
        if (gameRoom.mePokers != null) return gameRoom.mePokers;
        lock (gameRoom)
        {
            gameRoom.mePokers ??= new List<PokerDTO>();
        }

        return gameRoom.mePokers;
    }


    public static Sprite CardBack;

    public static Sprite GetCardBack()
    {
        if (CardBack == null)
        {
            CardBack = Resources.Load<Sprite>("Poker/CardBack");
        }

        return CardBack;
    }

    public static GameObject otherPocker { get; set; }

    public static GameObject mePoker { get; set; }
}