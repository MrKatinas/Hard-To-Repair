using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    int[] PlayerScores;
    int PlayerCount;
    int CurrentPlayer;
    int turn;
    int maxTurns = 5;

    int MainheartHealth = 0;
    int MainHeartRequiredHealth;

    public GameObject player;
    public GameObject heart;
    public GameObject IntermissionScreen;
    public Text IntermissionText;

    public GameObject LooseScreen;
    public Text LooseText;
    public Text ScoreTable2;

    public GameObject WinScreem;
    public Text ScoreTable;
    public Text WinText;

    float intermissiontimer = 0.0f;
    public float IntermissionDelay = 2.0f;
    bool actionTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = 0;
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (actionTaken)
        {
            intermissiontimer += Time.deltaTime;
        }

        if (intermissiontimer >= IntermissionDelay)
        {
            intermissiontimer = 0.0f;
            actionTaken = false;
            Intermission();
        }
    }

    public void Take()
    {
        PlayerScores[CurrentPlayer] += 1;
        actionTaken = true;
    }

    public void Give()
    {
        MainheartHealth += 1;
        actionTaken = true;
    }

    public void launch(int playerCount)
    {
        PlayerCount = playerCount;
        PlayerScores = new int[PlayerCount];
        MainHeartRequiredHealth = 3 * PlayerCount;
        IntermissionText.text = "Next Turn: Player " + (CurrentPlayer + 1);
        IntermissionScreen.SetActive(true);
        player.SetActive(false);
        heart.SetActive(false);
    }

    void Intermission()
    {
        ++CurrentPlayer;
        if (CurrentPlayer >= PlayerCount)
        {
            CurrentPlayer = 0;
            ++turn;
            if (turn >= 5)
            {
                EndScreen();
                return;
            }
        }
        IntermissionText.text = "Next Turn: Player " + (CurrentPlayer + 1);
        IntermissionScreen.SetActive(true);
        player.SetActive(false);
        heart.SetActive(false);
    }

    void EndScreen()
    {
        if (MainheartHealth < MainHeartRequiredHealth)
        {
            player.SetActive(false);
            heart.SetActive(false);
            LooseText.text = "Health of the Main Heart: " + MainheartHealth + "/" + MainHeartRequiredHealth;
            ScoreTable2.text = "Player Scores:\n";
            for (int i = 0; i < PlayerCount; ++i)
            {
                ScoreTable2.text = ScoreTable2.text + GetScoreLine();
            }
            LooseScreen.SetActive(true);
        }
        else
        {
            player.SetActive(false);
            heart.SetActive(false);
            WinText.text = "Health of the Main Heart: " + MainheartHealth + "/" + MainHeartRequiredHealth;
            WriteScore();
            WinScreem.SetActive(true);
        }
    }

    void WriteScore()
    {
        ScoreTable.text = "Player Scores:\n";
        for (int i = 0; i < PlayerCount; ++i)
        {
            ScoreTable.text = ScoreTable.text + GetScoreLine();
        }
    }

    string GetScoreLine()
    {
        int Player = 0;
        int Score = PlayerScores[0];

        for(int i = 1; i < PlayerCount; ++i)
        {
            if (PlayerScores[i] > Score)
            {
                Player = i;
                Score = PlayerScores[i];
            }
        }

        PlayerScores[Player] = -1;

        return "Player " + (Player + 1) + " - " + Score + "/5" + "\n";
    }

    public void StartTurn()
    {
        IntermissionScreen.SetActive(false);
        player.SetActive(true);
        heart.SetActive(true);
    }
}
