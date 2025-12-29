using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomButton : MonoBehaviour
{
    [SerializeField] private GameObject information;

    private bool firstClick = false;
    
    void OnMouseDown()
    {
        if (!firstClick) {
            Debug.Log("button clicked");
            TeamNameManager.Instance.Done();

            // set the game controller to make it's team
            // GameController.Instance.GeneratePlayerTeam();
            UIController.UIObj.SpawnCards();
            firstClick = true;
            information.SetActive(true);
        }
        // run the game
        else
        {
            GameController.Instance.Initialize();
            SceneManager.LoadScene("GameScene");
            
        }


    }


}
