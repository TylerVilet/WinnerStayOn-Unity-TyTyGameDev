using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighestLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highLevel;
    void Awake()
    {
        if (GameController.Instance  != null)
        {
            highLevel.text = $"Highest Level: {GameController.highLevel}";
        }
        else
        {
            highLevel.text = $"Highest Level: 0";
        }
    }
}
