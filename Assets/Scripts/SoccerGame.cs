using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SoccerGame : MonoBehaviour
{
    [SerializeField] private AudioClip whistle; // drag your music file here
    private AudioSource whistleAudio;
    [SerializeField] private AudioClip crowd; // drag your music file here
    private AudioSource crowdAudio;
    [SerializeField] private AudioClip cheer; // drag your music file here
    private AudioSource cheerAudio;


    // time for each game gets reset to 0
    int time;
    // when game ends
    int finalTime = -1;
    // player score
    int playerScore;
    // computer score
    int computerScore;

    float timer = 0f;

    public Player pTeam;
    public Player cTeam;

    // all stats of current player
    int pAttack;
    int pDefense;
    int pSave;


    // all stats of computer player
    int cAttack;
    int cDefense;
    int cSave;

    // multiplier for when something happens
    int multiplierP = 1;
    int multiplierC = 1;

    private bool gameOver = false;

    // message being printed
    [SerializeField] private TextMeshProUGUI gameLog;
    // score of game
    [SerializeField] private TextMeshProUGUI scoreLog;
    // time of game
    [SerializeField] private TextMeshProUGUI timeLog;


    public void Initialize(Player p, Player c)
    {
        whistleAudio = gameObject.AddComponent<AudioSource>();
        whistleAudio.clip = whistle;
        whistleAudio.playOnAwake = false; // don't auto-play
        whistleAudio.volume = 0.5f;    // optional, set volume

        crowdAudio = gameObject.AddComponent<AudioSource>();
        crowdAudio.clip = crowd;
        crowdAudio.playOnAwake = false; // don't auto-play
        crowdAudio.volume = 0.1f;    // optional, set volume
        crowdAudio.Play();

        cheerAudio = gameObject.AddComponent<AudioSource>();
        cheerAudio.clip = cheer;
        cheerAudio.playOnAwake = false; // don't auto-play
        cheerAudio.volume = 0.5f;    // optional, set volume




        pTeam = p;
        cTeam = c;

        time = 0;
        finalTime = Random.Range(90, 97);

        pAttack = pTeam.attack;
        pDefense = pTeam.defense;
        pSave = pTeam.save;

        cAttack = cTeam.attack;
        cDefense = cTeam.defense;
        cSave = cTeam.save;

        // reset all variables from prior games
        gameOver = false;
        multiplierC = 1;
        multiplierP = 1;
        playerScore = 0;
        computerScore = 0;
        resetLog();
        for (int i = 0; i < 6; i++)
        {
            GameController.Instance.playerCards[i].yellowCardReset();
            GameController.Instance.computerCards[i].yellowCardReset();
        }


        Debug.Log("Game started!");
        AddScore();
    }


    

    void Update()
    {


        if (gameOver || finalTime < 0) return; // don’t run until initialized
        
        timer += Time.deltaTime;
        if (timer >= 0.25f)
        {
            timer = 0f;
            time++;
            AddTime();

            SimulateMinute();
        }

        if (time >= finalTime)
        {
            crowdAudio.Stop();
            whistleAudio.Play();
            gameOver = true;
            Debug.Log("Game over");

            if (playerScore > computerScore)
            {
                PlayCheerForSeconds(3f);
                AddToLog($"{pTeam.playerName} wins");
                GameController.Instance.incrementLevel();
                SceneManager.LoadScene("NextLevel");
            }
            else if (computerScore > playerScore)
            {
                AddToLog($"{cTeam.playerName} wins");
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                AddToLog("Tie Game");
                SceneManager.LoadScene("GameScene");
            }
                
        }
    }


    public void SimulateMinute()
        {
        Debug.Log(time);

        // random for if a goal is scored
        float randGoal = Random.Range(0f, 100f);
        int pScore = -1;

        // check attack score
        // this alogrithm takes attack rating subtracts other defense rating and adds one to multiply to
        // check if it is more to use algo
        if (pAttack > cDefense)
        {
            float pAttackAlgo = ((pAttack - cDefense) / 100f);
            if (Random.Range(0f, 100f) < 1 + pAttackAlgo * multiplierP)
            {
                PlayCheerForSeconds(3f);
                playerScore++;

                // for who scored the goal 
                
                if (randGoal > 70) pScore = 5;
                else if (randGoal > 50) pScore = 4;
                else if (randGoal > 30) pScore = 3;
                else if (randGoal > 15) pScore = 2;
                else if (randGoal > 0.1) pScore = 1;
                else { pScore = 0; }

                AddToLog($"{time}: {GameController.Instance.playerCards[pScore].cardName} scored!");
                GameController.Instance.playerCards[pScore].goalScored();
                AddScore();

            }

        }
        else
        {
            if (Random.Range(0f, 100f) < 1 * multiplierP)
            {
                PlayCheerForSeconds(3f);
                playerScore++;

                // for who scored the goal 

                if (randGoal > 70) pScore = 5;
                else if (randGoal > 50) pScore = 4;
                else if (randGoal > 30) pScore = 3;
                else if (randGoal > 15) pScore = 2;
                else if (randGoal > 0.1) pScore = 1;
                else { pScore = 0; }

                AddToLog($"{time}: {GameController.Instance.playerCards[pScore].cardName} scored!");
                GameController.Instance.playerCards[pScore].goalScored();
                AddScore();

            }
        }


        // same code but for computer
        if (cAttack > pDefense)
        {
            float cAttackAlgo = ((cAttack - pDefense) / 100f);
            if (Random.Range(0f, 100f) < 1 + cAttackAlgo * multiplierC)
            {
                computerScore++;

                // for who scored the goal 

                if (randGoal > 70) pScore = 5;
                else if (randGoal > 50) pScore = 4;
                else if (randGoal > 30) pScore = 3;
                else if (randGoal > 15) pScore = 2;
                else if (randGoal > 0.1) pScore = 1;
                else { pScore = 0; }

                AddToLog($"{time}: {GameController.Instance.computerCards[pScore].cardName} scored!");
                GameController.Instance.computerCards[pScore].goalScored();
                AddScore();

            }

        }
        else
        {
            if (Random.Range(0f, 100f) < 1 * multiplierC)
            {
                computerScore++;

                // for who scored the goal 

                if (randGoal > 70) pScore = 5;
                else if (randGoal > 50) pScore = 4;
                else if (randGoal > 30) pScore = 3;
                else if (randGoal > 15) pScore = 2;
                else if (randGoal > 0.1) pScore = 1;
                else { pScore = 0; }

                AddToLog($"{time}: {GameController.Instance.computerCards[pScore].cardName} scored!");
                GameController.Instance.computerCards[pScore].goalScored();
                AddScore();

            }
        }


        // out for a corner kick
        if (Random.Range(0f, 2000f) < 1 + pAttack * multiplierP)
        {
            
            AddToLog($"{time}: Corner Kick for {pTeam.playerName}'s team");
        }
        else if (Random.Range(0f, 2000f) < 1 + cAttack * multiplierC)
        {
            
            AddToLog($"{time}: Corner Kick for {cTeam.playerName}'s team");
        }
        // yellow cards
        else if (Random.Range(0f, 5000f) < 100 - pDefense)
        {
            whistleAudio.Play();
            int rand = Random.Range(0, 5);
            AddToLog($"{time}: Yellow Card for {GameController.Instance.playerCards[rand].cardName}");
            GameController.Instance.playerCards[rand].yellowCard();

            // if 2 yellows implement multiplier
            if (GameController.Instance.playerCards[rand].yellowCards == 2)
            {
                AddToLog($"{time}: Red Card for {GameController.Instance.playerCards[rand].cardName} via double yellow");
                multiplierP++;
                
            }
        }

        else if (Random.Range(0f, 5000f) < 100 - cDefense)
        {
            whistleAudio.Play();
            int rand = Random.Range(0, 5);
            AddToLog($"{time}: Yellow Card for {GameController.Instance.computerCards[rand].cardName}");
            GameController.Instance.computerCards[rand].yellowCard();

            // if 2 yellows implement multiplier
            if (GameController.Instance.computerCards[rand].yellowCards == 2)
            {
                AddToLog($"{time}: Red Card for {GameController.Instance.computerCards[rand].cardName} via double yellow");
                multiplierC++;

            }
        }
        // save by keeper
        else if (Random.Range(0f, 100f) < 1 + (pSave / 100f)) {
            AddToLog($"{time}: Great save by {GameController.Instance.playerCards[0].cardName}");
        }
        else if (Random.Range(0f, 100f) < 1 + (cSave / 100f)) {
            AddToLog($"{time}: Great save by {GameController.Instance.computerCards[0].cardName}");
        }


    }

    // add to the message being printed on screen
    void AddToLog(string message)
    {
        gameLog.text += message + "\n";
    }
    // reset message log
    void resetLog()
    {
        gameLog.text = "";
    }
    // add to time
    void AddTime()
    {
        timeLog.text = $"{time}'";
    }
    // add to score
    void AddScore()
    {
        scoreLog.text = $"{pTeam.playerName}: {playerScore} | {computerScore} :{cTeam.playerName}";
    }
    public void PlayCheerForSeconds(float seconds)
    {
        StartCoroutine(PlayAudioForSeconds(seconds));
    }

    private IEnumerator PlayAudioForSeconds(float seconds)
    {
        cheerAudio.Play();
        yield return new WaitForSeconds(seconds);
        cheerAudio.Stop();
    }

}
