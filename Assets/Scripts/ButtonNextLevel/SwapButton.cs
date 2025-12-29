using UnityEngine;

public class SwapButton : MonoBehaviour
{
    public int index;
    public bool isPlayerTeam;

    void OnMouseDown()
    {
        SwapController.Instance.Select(this);
    }
}
