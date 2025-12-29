using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentLevel;
    void Awake()
    {
        if (GameController.Instance != null)
        {
            currentLevel.text = $"Current Level: {GameController.level}";
        }
        else
        {
            currentLevel.text = $"Current Level: 1";
        }
    }
}
