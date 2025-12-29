using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    // stats for this character

    [SerializeField] public int attack;
    [SerializeField] public int defense;
    [SerializeField] public int save;
    [SerializeField] public string cardName;
    public int yellowCards;
    public int goals;

    void Start()
    {
        yellowCards = 0;
        goals = 0;
    }

    public void yellowCard() { yellowCards++; }
    public void yellowCardReset() { yellowCards = 0; } 
    public void goalScored() { goals++; }


}
