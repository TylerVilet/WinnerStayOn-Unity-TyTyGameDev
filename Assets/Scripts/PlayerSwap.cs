using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    private GameObject selectedMyPlayer = null;
    private GameObject selectedOtherPlayer = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject clicked = hit.collider.gameObject;

                if (clicked.CompareTag("MyTeam"))
                {
                    selectedMyPlayer = clicked;
                    Debug.Log("Selected my player: " + clicked.name);
                }
                else if (clicked.CompareTag("ComputerTeam") && selectedMyPlayer != null)
                {
                    selectedOtherPlayer = clicked;
                    Debug.Log("Selected other player: " + clicked.name);

                    SwapPlayers(selectedMyPlayer, selectedOtherPlayer);

                    // reset selection
                    selectedMyPlayer = null;
                    selectedOtherPlayer = null;

                    // delete this gameobject for no more swaps
                    Destroy(gameObject);
                }
            }
        }
    }

    void SwapPlayers(GameObject myPlayer, GameObject otherPlayer)
    {
        // swap positions
        Vector3 tempPos = myPlayer.transform.position;
        myPlayer.transform.position = otherPlayer.transform.position;
        otherPlayer.transform.position = tempPos;

        // optional: swap references in your Player arrays if needed
        Debug.Log($"Swapped {myPlayer.name} with {otherPlayer.name}");

        // code of swapping them in the array
        GameController.Instance.pTeam.AddPlayer(myPlayer, otherPlayer);
    }
}
