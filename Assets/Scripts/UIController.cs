using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController UIObj;

    public bool mainMenu;

    void Awake()
    {
        if (UIObj == null)
            UIObj = this;
        else
            Destroy(gameObject);

        mainMenu = true;
    }
    // allign cards when game is player

    public GameObject[] playerGameObjects = new GameObject[6];
    public GameObject[] computerGameObjects = new GameObject[6];

    public void SpawnCards()
    {
        Debug.Log("Spawn Cards");
        Vector3[] position =
        {
        new Vector3(-7.75f, 3f, 0f),
        new Vector3(-7.75f, 0f, 0f),
        new Vector3(-7.75f, -3f, 0f),
        new Vector3(-5.5f, 3f, 0f),
        new Vector3(-5.5f, 0f, 0f),
        new Vector3(-5.5f, -3f, 0f),
    };

        for (int i = 0; i < 6; i++)
        {
            playerGameObjects[i] = Instantiate(GameController.Instance.playerCards[i].gameObject, position[i], Quaternion.identity);
        }
    }

    public void SpawnOpps()
    {
        Debug.Log("Spawn Opps");
        Vector3[] position =
        {
        new Vector3(7.75f, 3f, 0f),
        new Vector3(7.75f, 0f, 0f),
        new Vector3(7.75f, -3f, 0f),
        new Vector3(5.5f, 3f, 0f),
        new Vector3(5.5f, 0f, 0f),
        new Vector3(5.5f, -3f, 0f),
    };

        for (int i = 0; i < 6; i++)
        {
            computerGameObjects[i] = Instantiate(GameController.Instance.computerCards[i].gameObject, position[i], Quaternion.identity);
        }
    }

}
