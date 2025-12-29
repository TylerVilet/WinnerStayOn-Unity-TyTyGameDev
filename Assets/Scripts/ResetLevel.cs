using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    void Awake()
    {
        GameController.level = 1;
    }
}
