using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds = new GameObject[5];
    private GameObject[] spawnedClouds;
    private Vector3[] positions =
    {
        new Vector3 (-6f, 3f, 0.5f),
        new Vector3 (-10f, 1f, 0.5f),
        new Vector3 (11.5f, -0.42f, 0.5f),
        new Vector3 (10f, 4f, 0.5f),
        new Vector3 (4.8f, 3f, 0.5f)
    };

    void Awake()
    {
        spawnedClouds = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            spawnedClouds[i] = Instantiate(clouds[i], positions[i], Quaternion.identity);
        }
        
    }

    void Update()
    {
        moveClouds();
    }

    void moveClouds()
    {
        spawnedClouds[0].transform.position += Vector3.right * 0.2f * Time.deltaTime;
        spawnedClouds[1].transform.position += Vector3.right * 0.3f * Time.deltaTime;
        spawnedClouds[2].transform.position += Vector3.left * 0.4f * Time.deltaTime;
        spawnedClouds[3].transform.position += Vector3.left * 0.2f * Time.deltaTime;
        spawnedClouds[4].transform.position += Vector3.right * 0.33f * Time.deltaTime;

        Vector3 pos0 = spawnedClouds[0].transform.position;
        Vector3 pos1 = spawnedClouds[1].transform.position;
        Vector3 pos2 = spawnedClouds[2].transform.position;
        Vector3 pos3 = spawnedClouds[3].transform.position;
        Vector3 pos4 = spawnedClouds[4].transform.position;
        if (pos0.x > 12f) pos0.x = -12f; spawnedClouds[0].transform.position = pos0;
        if (pos1.x > 12f) pos1.x = -12f; spawnedClouds[1].transform.position = pos1;
        if (pos2.x < -12f) pos2.x = 12f; spawnedClouds[2].transform.position = pos2;
        if (pos3.x < -12f) pos3.x = 12f; spawnedClouds[3].transform.position = pos3;
        if (pos4.x > 12f) pos4.x = -12f; spawnedClouds[4].transform.position = pos4;
    }
}
