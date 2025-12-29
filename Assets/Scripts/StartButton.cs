using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("Start Game");
        GameController.Instance.GeneratePlayerTeam();
        // UIController.UIObj.SpawnCards(); 

        // SoccerGame game = FindObjectOfType<SoccerGame>();
        // game.Initialize(GameController.Instance.pTeam, GameController.Instance.cTeam);
        
    }

}
