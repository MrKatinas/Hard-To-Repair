using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    int[] PlayerScores;
    int PlayerCount;
    int CurrentPlayer;
    int turn;
    int maxTurns;

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

    public Sprite Heart0;
    public Sprite Heart1;
    public Sprite Heart2;
    public Sprite Heart3;
    public Sprite Heart4;
    public Sprite Heart5;

    public SpriteRenderer playerHeart;

    public Button giveButton;
    public Button takeButton;

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
        if (PlayerScores[CurrentPlayer] == 0)
        {
            playerHeart.sprite = Heart0;
        }
        else if (PlayerScores[CurrentPlayer] == 1)
        {
            playerHeart.sprite = Heart1;
        }
        else if (PlayerScores[CurrentPlayer] == 2)
        {
            playerHeart.sprite = Heart2;
        }
        else if (PlayerScores[CurrentPlayer] == 3)
        {
            playerHeart.sprite = Heart3;
        }
        else if (PlayerScores[CurrentPlayer] == 4)
        {
            playerHeart.sprite = Heart4;
        }
        else if (PlayerScores[CurrentPlayer] == 5)
        {
            playerHeart.sprite = Heart5;
        }
        actionTaken = true;
        takeButton.interactable = false;
        giveButton.interactable = false;
    }

    public void Give()
    {
        MainheartHealth += 1;
        actionTaken = true;
        takeButton.interactable = false;
        giveButton.interactable = false;
    }

    public void launch(int playerCount, int roundCount)
    {
        PlayerCount = playerCount;
        maxTurns = roundCount;
        PlayerScores = new int[PlayerCount];
        MainHeartRequiredHealth = (int)(0.6 * maxTurns * PlayerCount);
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
            if (turn >= maxTurns)
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
            LooseText.text = "Gary's Health: " + MainheartHealth + "/" + MainHeartRequiredHealth;
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
            WinText.text = "Gary's health: " + MainheartHealth + "/" + MainHeartRequiredHealth;
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

        return "Player " + (Player + 1) + " - " + Score + "/" + maxTurns + "\n";
    }

    public void StartTurn()
    {
        IntermissionScreen.SetActive(false);
        if (PlayerScores[CurrentPlayer] == 0)
        {
            playerHeart.sprite = Heart0;
        }
        else if (PlayerScores[CurrentPlayer] == 1)
        {
            playerHeart.sprite = Heart1;
        }
        else if (PlayerScores[CurrentPlayer] == 2)
        {
            playerHeart.sprite = Heart2;
        }
        else if (PlayerScores[CurrentPlayer] == 3)
        {
            playerHeart.sprite = Heart3;
        }
        else if (PlayerScores[CurrentPlayer] == 4)
        {
            playerHeart.sprite = Heart4;
        }
        else if (PlayerScores[CurrentPlayer] == 5)
        {
            playerHeart.sprite = Heart5;
        }
        player.SetActive(true);
        heart.SetActive(true);
        takeButton.interactable = true;
        giveButton.interactable = true;
    }

    public void Rest()
    {
        Scene s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
}
