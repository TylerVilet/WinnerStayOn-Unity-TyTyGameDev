using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    

    // stats
    public int attack;
    public int defense;
    public int save;

    public string playerName;

    public PlayerCard[] playerArray; 

    public Player(string name, PlayerCard[] playerCards)
    {
        playerName = name;

        playerArray = new PlayerCard[6];

        // generate attack
        int totalA = 0;
        for (int i = 1; i < 6; i++)
        {
            totalA += playerCards[i].attack;
        }
        int totalD = 0;
        for (int i = 1; i < 6; i++)
        {
            totalD += playerCards[i].defense;
        }

        for (int i = 0;  i < 6; i++)
            playerArray[i] = playerCards[i];

        attack = totalA / 5; defense = totalD / 5; save = playerCards[0].save;
    }

    // add player to team
    public void AddPlayer(GameObject playerOut, GameObject playerIn)
    {
        for (int i = 0; i < 6; i++)
        {
            if (playerOut == playerArray[i])
            {
                playerArray[i] = playerIn.GetComponent<PlayerCard>(); ; break;
            }
        }
    }
}
