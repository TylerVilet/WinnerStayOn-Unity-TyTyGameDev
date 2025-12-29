using TMPro;
using UnityEngine;

public class TeamNameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField teamNameInput;
    [SerializeField] private TextMeshProUGUI questionName;
    [SerializeField] private TMP_InputField teamAbrInput;
    [SerializeField] private TextMeshProUGUI questionAbr;
  

    public static TeamNameManager Instance; // singleton reference

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Done()
    {
        string playerTeamName = teamNameInput.text;
        string playerAbr = teamAbrInput.text;
        Debug.Log("Player team name: " + playerTeamName);
        Debug.Log("Player abr name: " + playerAbr);

        // Save it somewhere, e.g., GameController
        GameController.Instance.SetTeamName(playerTeamName, playerAbr);

        // Remove the input field and its placeholder/text
        Destroy(teamNameInput.gameObject);
        Destroy(questionName.gameObject);
        Destroy(teamAbrInput.gameObject);
        Destroy(questionAbr.gameObject);
    }
}
