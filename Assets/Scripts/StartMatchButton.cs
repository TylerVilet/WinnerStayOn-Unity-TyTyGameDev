using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMatchButton : MonoBehaviour
{

    [SerializeField] private SoccerGame soccerGame;
    [SerializeField] private SetNames setNames;

    void OnMouseDown()
    {
        Destroy(gameObject);


        // make players appear
        UIController.UIObj.SpawnCards();
        UIController.UIObj.SpawnOpps();
        setNames.setName();

        // reset player swap if win
        SwapController.haveSwapped = false;


        soccerGame.Initialize(GameController.Instance.pTeam, GameController.Instance.cTeam);


        
    }
}
