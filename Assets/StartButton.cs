using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Text playerCount;
    public Text RoundCount;
    public Game manager;

    public GameObject introScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTheThing()
    {
        if (string.IsNullOrWhiteSpace(playerCount.text) || string.IsNullOrWhiteSpace(RoundCount.text))
        {
            return;
        }

        if (int.TryParse(playerCount.text, out var i) && int.TryParse(RoundCount.text, out var j))
        {
            manager.launch(i, j);
            introScreen.SetActive(false);
            return;
        }
//error

    }
}
