using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutCards : MonoBehaviour
{
    void Awake()
    {
        UIController.UIObj.SpawnCards();
        UIController.UIObj.SpawnOpps();
    }
}
