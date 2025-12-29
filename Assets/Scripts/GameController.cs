using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public PlayerCard[] playerCards = new PlayerCard[6];
    [SerializeField] public PlayerCard[] computerCards = new PlayerCard[6];
    [SerializeField] public GameObject[] playerGameObjects = new GameObject[6];
    [SerializeField] private AudioClip backgroundMusic; // drag your music file here
    private AudioSource audioSource;

    // player name
    public static string pName = "";
    public static string pAbr = "";
    public static string cName = "Computer";

    // each players team
    public Player pTeam;
    public Player cTeam; 

    public static GameController Instance;

    // level player is on
    public static int level = 1;
    public static int highLevel = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;      // loop it forever
        audioSource.playOnAwake = false; // don't auto-play
        audioSource.volume = 0.05f;    // optional, set volume
        audioSource.Play();


        GenerateComputerTeam();
        GeneratePlayerTeam();
        Debug.Log("GC initialized");

    }

    void Update()
    {
        if (level > highLevel) { highLevel = level; }
    }

    public void Initialize()
    {
        // GeneratePlayerTeam();
        GenerateComputerTeam();

        pTeam = new Player(pAbr, playerCards);
        cTeam = new Player("Com", computerCards);
    }

    public void GeneratePlayerTeam()
    {
        int rand0 = Random.Range(0, 5);
        int rand1 = Random.Range(6, 18);
        int rand2 = Random.Range(6, 18);
        int rand3 = Random.Range(6, 18);
        int rand4 = Random.Range(19, 28);
        int rand5 = Random.Range(19, 28);
        playerCards[0] = PlayerCardLibrary.pLibrary.GetCard(rand0);
        playerCards[1] = PlayerCardLibrary.pLibrary.GetCard(rand1);
        playerCards[2] = PlayerCardLibrary.pLibrary.GetCard(rand2);
        playerCards[3] = PlayerCardLibrary.pLibrary.GetCard(rand3);
        playerCards[4] = PlayerCardLibrary.pLibrary.GetCard(rand4);
        playerCards[5] = PlayerCardLibrary.pLibrary.GetCard(rand5);
        /*
        playerCards[0].tag = "MyTeam";
        playerCards[1].tag = "MyTeam";
        playerCards[2].tag = "MyTeam";
        playerCards[3].tag = "MyTeam";
        playerCards[4].tag = "MyTeam";
        playerCards[5].tag = "MyTeam";
        */
    }

    public void GenerateComputerTeam()
    {
        int rand0 = Random.Range(0, 5);
        int rand1 = Random.Range(6, 18);
        int rand2 = Random.Range(6, 18);
        int rand3 = Random.Range(6, 18);
        int rand4 = Random.Range(19, 28);
        int rand5 = Random.Range(19, 28);


        computerCards[0] = PlayerCardLibrary.pLibrary.GetCard(rand0);
        computerCards[1] = PlayerCardLibrary.pLibrary.GetCard(rand1);
        computerCards[2] = PlayerCardLibrary.pLibrary.GetCard(rand2);
        computerCards[3] = PlayerCardLibrary.pLibrary.GetCard(rand3);
        computerCards[4] = PlayerCardLibrary.pLibrary.GetCard(rand4);
        computerCards[5] = PlayerCardLibrary.pLibrary.GetCard(rand5);
        /*
        computerCards[0].tag = "ComputerTeam";
        computerCards[1].tag = "ComputerTeam";
        computerCards[2].tag = "ComputerTeam";
        computerCards[3].tag = "ComputerTeam";
        computerCards[4].tag = "ComputerTeam";
        computerCards[5].tag = "ComputerTeam";
        */
    }

    public void ResetGame()
    {
        for (int i = 0; i < 6; i++)
        {
            playerCards[i] = null;
            computerCards[i] = null;
        }

        GeneratePlayerTeam();
        GenerateComputerTeam();
    }


    public void SetTeamName(string name, string abr) { pName = name; pAbr = abr; }
    public string GetTeamName() {  return pName; }
    public string GetComputerName() { return cName; }
    public void incrementLevel() { level++; }
}
