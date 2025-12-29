using UnityEngine;

public class SwapController : MonoBehaviour
{
    public static SwapController Instance;

    private SwapButton selectedPlayer;
    private SwapButton selectedComputer;
    public static bool haveSwapped = false;

    void Awake()
    {
        Instance = this;
    }

    public void Select(SwapButton button)
    {
        if (button.isPlayerTeam)
        {
            selectedPlayer = button;
            Debug.Log("Selected player index " + button.index);
            Debug.Log(GameController.Instance.playerCards[button.index].gameObject.transform.position);
        }
        else if (selectedPlayer != null)
        {
            Debug.Log("Selected Computer index " + button.index);
            Debug.Log("haveSwapped = " + haveSwapped);
            selectedComputer = button;
            DoSwap();
        }
    }

    void DoSwap()
    {
        int i = selectedPlayer.index;
        int j = selectedComputer.index;

        if (!haveSwapped)
        {
            // swap transforms
            Vector3 tempPos = UIController.UIObj.playerGameObjects[i].transform.position;
            UIController.UIObj.playerGameObjects[i].transform.position = UIController.UIObj.computerGameObjects[j].transform.position;
            UIController.UIObj.computerGameObjects[j].transform.position = tempPos;

            // swap references
            PlayerCard temp =
                GameController.Instance.playerCards[i];

            GameController.Instance.playerCards[i] =
                GameController.Instance.computerCards[j];

            GameController.Instance.computerCards[j] = temp;

            Debug.Log("Swap complete");

            selectedPlayer = null;
            selectedComputer = null;
            haveSwapped = true;
        }
        
    }
}
