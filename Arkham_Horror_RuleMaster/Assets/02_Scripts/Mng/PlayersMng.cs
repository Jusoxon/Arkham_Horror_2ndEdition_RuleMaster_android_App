using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//조사자들의 순서 등 활용
public static class PlayersMng
{
    public static List<int> lPlayers;
    public static int firstTurnPlayer;

    public static int turnIndex = 0;

    public static void Init()
    {
        lPlayers = new List<int>();
    }

    public static void AddPlayers(int _nID)
    {
        lPlayers.Add(_nID);
    }

    public static void NextFirstPlayer()
    {
        turnIndex++;
        if (turnIndex > lPlayers.Count - 1)
            turnIndex = 0;

        firstTurnPlayer = lPlayers[turnIndex];
    }
}
