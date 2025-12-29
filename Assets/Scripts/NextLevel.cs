using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnMouseDown()
    {
        // get new computer team
        GameController.Instance.GenerateComputerTeam();

        SceneManager.LoadScene("GameScene");
    }
}
