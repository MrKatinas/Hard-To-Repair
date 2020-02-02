using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Text playerCount;
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
        if (string.IsNullOrWhiteSpace(playerCount.text))
        {
            return;
        }

        if (int.TryParse(playerCount.text, out var i))
        {
            if (i < 2) { return; }
            manager.launch(i, 5);
            introScreen.SetActive(false);
            return;
        }
//error

    }
}
