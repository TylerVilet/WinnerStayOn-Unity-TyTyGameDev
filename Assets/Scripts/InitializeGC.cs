using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGC : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Generate player team");
        GameController.Instance.GeneratePlayerTeam();
    }
}
