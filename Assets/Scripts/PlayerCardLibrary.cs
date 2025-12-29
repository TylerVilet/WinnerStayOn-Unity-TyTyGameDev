using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class PlayerCardLibrary : MonoBehaviour
{



    public static PlayerCardLibrary pLibrary;

    [SerializeField] private PlayerCard[] playerLibrary = new PlayerCard[100];
    // first 10 is goalies
    // 10 - 40 defenders
    // 40 - 100 offense

    void Awake()
    {
        if (pLibrary == null)
            pLibrary = this;
        else
            Destroy(gameObject);
    }

    public PlayerCard GetCard(int index)
    {
        return playerLibrary[index];
    }



}
