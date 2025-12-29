using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNames : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pteamname;
    [SerializeField] private TextMeshProUGUI cteamname;



    public void setName()
    {
        pteamname.text = GameController.pName;
        cteamname.text = GameController.cName;
    }
}
